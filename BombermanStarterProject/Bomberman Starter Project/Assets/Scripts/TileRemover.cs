using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileRemover : MonoBehaviour
{

    public Tilemap tilemap;
    public Tile wallTile;
    public Tile destructibleTile;
    public GameObject explosionPrefab;
    public PlayerController player;
    public BombSpawner bombspawner;
    public Vector3 pos;

    public void Explosion(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        BlastRadius(originCell);

        if (BlastRadius(originCell + new Vector3Int(1, 0, 0)))
        {
            BlastRadius(originCell + new Vector3Int(2, 0, 0));
        }

        if (BlastRadius(originCell + new Vector3Int(0, 1, 0)))
        {
            BlastRadius(originCell + new Vector3Int(0, 2, 0));
        }

        if (BlastRadius(originCell + new Vector3Int(-1, 0, 0)))
        {
            BlastRadius(originCell + new Vector3Int(-2, 0, 0));
        }

        if (BlastRadius(originCell + new Vector3Int(0, -1, 0)))
        {
            BlastRadius(originCell + new Vector3Int(0, -2, 0));
        }
    }
    private bool BlastRadius(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        Vector3 playerPos = player.transform.position;
        Vector3Int playerCell = tilemap.WorldToCell(playerPos);

        if (tile == wallTile)
        {
            return false;
        }

        if (tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
            Instantiate(explosionPrefab, pos, Quaternion.identity);
            return false;
        }

        if (cell == playerCell)
        {
            player.ExplodePlayer();
        }

        if (bombspawner.ListOfBombs.Count > 1)
        {
            for (int i = 0; i < bombspawner.ListOfBombs.Count; i++)
            {
                Bomb currBomb = bombspawner.ListOfBombs[i].GetComponent<Bomb>();

                if (!currBomb.detonated)
                {
                    Vector3 currBombPos = bombspawner.ListOfBombs[i].transform.position;
                    Vector3Int currBombCell = tilemap.WorldToCell(currBombPos);

                    if (cell == currBombCell)
                    {
                        Debug.Log("Boom!");
                        currBomb.Detonate();
                    }
                }
            }

        }
        pos = tilemap.GetCellCenterWorld(cell);
        Instantiate(explosionPrefab, pos, Quaternion.identity);

        return true;
    }
}

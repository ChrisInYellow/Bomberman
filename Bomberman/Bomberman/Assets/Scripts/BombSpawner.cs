
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BombSpawner : MonoBehaviour
{

    public Tilemap tilemap;
    public GameObject player;
    public Vector2 spawningPos;
    public Vector3Int cell;
    public Vector3 cellCenter;

    public GameObject bomb;
    public List<GameObject> ListOfBombs;

    public void SpawnBomb()
    {
        spawningPos = player.transform.position;
        cell = tilemap.WorldToCell(spawningPos);
        cellCenter = tilemap.GetCellCenterWorld(cell);

        var newBomb = Instantiate(bomb, cellCenter, Quaternion.identity);
        ListOfBombs.Add(newBomb);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int x;
    public int y;
    public float acceleration;
    public Tilemap tilemap;
    public Tilemap overlayMap;
    public TileBase overlayTile;
    private Rigidbody2D rigidbody;
    public GameObject explosionPrefab;
    private BombSpawner bombspawner;
    private TileRemover tileRemover; 

    // Use this for initialization
    void Start()
    {
        x = 0;
        y = 0;
        transform.position = new Vector3(x, y, 0);
        Overlay(new Vector3Int(x, y, 0));
        rigidbody = GetComponent<Rigidbody2D>();
        bombspawner = FindObjectOfType<BombSpawner>();
        tileRemover = FindObjectOfType<TileRemover>();
    }

    // Update is called once per frame
    void Update()
    { 
        Movement();

        if(Input.GetButtonDown("Jump"))
        {
            bombspawner.SpawnBomb();
        }
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 tilePos = tilemap.WorldToCell(mousePos);
            Vector3Int intPos = new Vector3Int((int)tilePos.x, (int)tilePos.y, 0);

            if (overlayMap.GetTile(intPos) != null)
            {
                x = intPos.x;
                y = intPos.y;
                transform.position = tilemap.CellToWorld(new Vector3Int(x, y, 0));
                Overlay(intPos);

            }

        }
    }
    private void Overlay(Vector3Int PlayerPos)
    {
        overlayMap.ClearAllTiles();
        overlayMap.SetTile(PlayerPos, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.up *2, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.down * 2, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.left * 2, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.right *2, overlayTile);
    }

    public void ExplodePlayer()
    { 
            overlayMap.ClearAllTiles();
            Destroy(gameObject); 
    }

}

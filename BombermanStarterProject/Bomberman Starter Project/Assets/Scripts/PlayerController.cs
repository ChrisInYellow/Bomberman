using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int x;
    public int y;
    public int numberOfSteps;

    public Vector3 oldPos;
    public Vector3 currPos; 
    public Tilemap tilemap;
    public Tilemap overlayMap;
    public TileBase overlayTile;
    public GameObject ghostImage; 

    private Rigidbody2D rigidbody;
    private Ghosting ghost; 
    public GameObject explosionPrefab;
    public BombSpawner bombspawner;
    public TileRemover tileRemover;


    public bool BombDropped;


    // Use this for initialization
    void Start()
    {
        x = 0;
        y = 0;
        transform.position = new Vector3(x, y, 0);
        Overlay(new Vector3Int(x, y, 0));
        rigidbody = GetComponent<Rigidbody2D>();
        ghost = GetComponent<Ghosting>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Jump"))
        {
            bombspawner.SpawnBomb();
        }
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPos = transform.position; 

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 tilePos = tilemap.WorldToCell(mousePos);
            Vector3Int intPos = new Vector3Int((int)tilePos.x, (int)tilePos.y, 0);

            if (overlayMap.GetTile(intPos) != null)
            {
                Debug.Log(tilemap.GetTile(intPos));
                if (tilemap.GetTile(intPos) != tileRemover.wallTile && tilemap.GetTile(intPos) != tileRemover.destructibleTile)
                {
                    x = intPos.x;
                    y = intPos.y;
                    transform.position = tilemap.CellToWorld(new Vector3Int(x, y, 0));
                    currPos = transform.position; 
                    Overlay(intPos);
                    ghost.enabled = true; 
                    //Instantiate(ghostImage, transform.position, transform.rotation); 
                }
            }
        }
    }
    private void Overlay(Vector3Int PlayerPos)
    {
        overlayMap.ClearAllTiles();
        overlayMap.SetTile(PlayerPos, overlayTile);

        for (int i = 1; i < numberOfSteps; i++)
        {
            if (tilemap.GetTile(PlayerPos + Vector3Int.up * i) != tileRemover.wallTile &&
                tilemap.GetTile(PlayerPos + Vector3Int.up * i) != tileRemover.destructibleTile)
            {
                overlayMap.SetTile(PlayerPos + Vector3Int.up * i, overlayTile);
            }
            else
            {
                i = numberOfSteps; 
            }
        }

        for (int j = 1; j < numberOfSteps; j++)
        {
            if (tilemap.GetTile(PlayerPos + Vector3Int.down * j) != tileRemover.wallTile &&
                tilemap.GetTile(PlayerPos + Vector3Int.down * j) != tileRemover.destructibleTile)
            {
                overlayMap.SetTile(PlayerPos + Vector3Int.down * j, overlayTile);
            }
            else
            {
                j = numberOfSteps;
            }
        }

        for (int k = 1; k < numberOfSteps; k++)
        {
            if (tilemap.GetTile(PlayerPos + Vector3Int.left * k) != tileRemover.wallTile &&
                tilemap.GetTile(PlayerPos + Vector3Int.left * k) != tileRemover.destructibleTile)
            {
                overlayMap.SetTile(PlayerPos + Vector3Int.left * k, overlayTile);
            }
            else
            {
                k = numberOfSteps;
            }
        }

        for (int l = 1; l < numberOfSteps; l++)
        {
            if (tilemap.GetTile(PlayerPos + Vector3Int.right * l) != tileRemover.wallTile &&
                tilemap.GetTile(PlayerPos + Vector3Int.right * l) != tileRemover.destructibleTile)
            {
                overlayMap.SetTile(PlayerPos + Vector3Int.right * l, overlayTile);
            }
            else
            {
                l = numberOfSteps; 
            }
        }
    }
    public void ExplodePlayer()
        {
            overlayMap.ClearAllTiles();
            Destroy(gameObject);
        }

    }


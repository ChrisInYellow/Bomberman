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

    // Use this for initialization
    void Start()
    {
        x = 0;
        y = 0; 
        transform.position = new Vector3(x, y, 0);
        Overlay(new Vector3Int(x, y, 0)); 
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Movement(); 
    }

    private void Movement()
    {


        if(Input.GetMouseButtonDown(0))
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
        overlayMap.SetTile(PlayerPos+Vector3Int.up, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.down, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.left, overlayTile);
        overlayMap.SetTile(PlayerPos + Vector3Int.right, overlayTile);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Explosion")
        {
            Invoke("Death", 2.80f); 
        }
    }
    public void Death()
    {
        Destroy(gameObject); 
    }

}

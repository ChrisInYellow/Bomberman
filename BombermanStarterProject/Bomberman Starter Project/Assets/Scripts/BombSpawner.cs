
using UnityEngine;
using UnityEngine.Tilemaps; 

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;
    public GameObject player;

    public GameObject bomb; 

    public void SpawnBomb()
    {
            Vector3 spawningPos = player.transform.position;
            Vector3Int cell = tilemap.WorldToCell(spawningPos);
            Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);

            Instantiate(bomb, cellCenter, Quaternion.identity); 
    }
}

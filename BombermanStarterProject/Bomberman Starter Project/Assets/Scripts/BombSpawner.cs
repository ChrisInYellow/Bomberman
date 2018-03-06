
using UnityEngine;
using UnityEngine.Tilemaps; 

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;

    public GameObject bomb; 
	
	// Update is called once per frame
	void Update () {
        SpawnBomb(); 
	}

    public void SpawnBomb()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 spawningPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(spawningPos);
            Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);

            Instantiate(bomb, cellCenter, Quaternion.identity); 
        }
    }
}

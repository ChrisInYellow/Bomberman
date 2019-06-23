using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;
    public bool detonated;
    private BombSpawner bombSpawner;

    private void Start()
    {
        bombSpawner = FindObjectOfType<BombSpawner>();
        detonated = false;
        Invoke("Detonate", countdown);
    }

    public void Detonate()
    {
        CancelInvoke("Detonate");
        detonated = true;
        FindObjectOfType<TileRemover>().Explosion(transform.position);
        bombSpawner.ListOfBombs.Remove(gameObject);
        Destroy(gameObject);
    }
}

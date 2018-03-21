using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public float countdown = 2f;

    private void Start()
    {

        Invoke("Detonate", countdown); 
        
    }
    public void Detonate()
    {
            FindObjectOfType<TileRemover>().Explosion(transform.position);
            Destroy(gameObject);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostImage : MonoBehaviour {
    SpriteRenderer sprite;
    public float timer;
    private PlayerController player;

	// Use this for initialization
	void Start () {

        sprite = GetComponent<SpriteRenderer>(); 
        player = FindObjectOfType<PlayerController>();

        transform.position = player.transform.position;
        transform.localScale = player.transform.localScale;

        sprite.sprite = player.GetComponent<SpriteRenderer>().sprite;
        sprite.color = new Vector4(50, 50, 50, 0.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime; 
       
        if(timer<=0)
        {
            Destroy(gameObject); 
        }
	}

    public void GhostImageSpawn()
    {

    }
}

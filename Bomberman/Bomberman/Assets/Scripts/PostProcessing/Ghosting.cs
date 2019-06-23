using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosting : MonoBehaviour {

    List<GameObject> ghostImages = new List<GameObject>();
    public float ghostrate;
    public float ghostLifetime;
    private float timer = 0;

    private void OnEnable()
    {
        timer = 0; 
    }
    private PlayerController player; 
	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnGhostImage", 0, ghostrate);
        player = GetComponent<PlayerController>(); 
	}


    void SpawnGhostImage()
    {
            timer += Time.deltaTime;
            GameObject ghostImage = new GameObject();
            SpriteRenderer ghostImageRenderer = ghostImage.AddComponent<SpriteRenderer>();
            ghostImageRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
            ghostImageRenderer.sortingOrder = 2;
            ghostImage.transform.position = Vector3.Lerp(player.oldPos, player.currPos, timer * 40);
            ghostImage.transform.localScale = transform.localScale;
            ghostImages.Add(ghostImage);

            StartCoroutine(FadeGhostImage(ghostImageRenderer));
            Destroy(ghostImage, ghostLifetime);
       
        this.enabled = false; 
    }
    IEnumerator FadeGhostImage(SpriteRenderer ghostImageRenderer)
    {
        Color color = ghostImageRenderer.color;
        color.a = 0.5f;
        ghostImageRenderer.color = color;
        Debug.Log("Alpha is currently:" + color.a);

        yield return new WaitForEndOfFrame(); 
    }
}

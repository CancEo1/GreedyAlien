using System;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class diamondCollection : MonoBehaviour
{
    public int rotationSpeed;
    // public GameObject onCollectEffect;
    public AudioClip collectSound;
    public GameObject diamond;

    // TextMeshPro UI to hold score
    public TextMeshPro scoreText;

    private ResourceSpawn resourceSpawn;

    void Start()
    {
        resourceSpawn = FindAnyObjectByType<ResourceSpawn>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // check if the collision is with a Player and not a random object
            // Instantiate particle effect
            // Instantiate(onCollectEffect, transform.position, transform.rotation);

            // Play audio clip on collection
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            // Destroy upon collection
            Destroy(this.gameObject);

            // updateScore();
            // Debug to see if it's colliding
            ResourceSpawn.DiamondCollected();
            Debug.Log("Diamond Collected");
        }
    }

    private void updateScore()
    {
        if (this.gameObject)
        {
            // scoreText.text = "Score:" + diamond.ToString();
        }
    }

    private void FixedUpdate()
    {
        // Rotate diamond while idle
        transform.Rotate(0, 0, rotationSpeed);
    }
}
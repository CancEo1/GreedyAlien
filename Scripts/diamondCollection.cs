using System;
using UnityEngine;

public class diamondCollection : MonoBehaviour
{
    // setting the value to 0
    private static int diamond = 0;
    public int rotationSpeed;
    // public GameObject onCollectEffect;
    // public AudioClip collectSound;

    // TextMeshPro UI to hold score
    // public TextMeshProGUI scoreText;

    private ResourceSpawn spawn;
    private int maxSpawnCount = 5;

    void Start()
    {
        //spawn = GetComponent<ResourceSpawn>;
    }

    private void onTriggerEnter()
    {
        // check if the collision is with a Player and not a random object
        // Instantiate particle effect
        // Instantiate(onCollectEffect, transform.position, transform.rotation);

        // Play audio clip on collection
        // AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Destroy upon collection
        // Destroy(this.GameObject);

        // updateScore;
    }

    private void updateScore()
    {
        if (this.gameObject)
        {
            // scoreText.text = "Score:" + diamond.ToString();
            Debug.Log("Diamond Collected");
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
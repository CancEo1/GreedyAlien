using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    public float speed = 5.0f;
    public float rotationSpeed = 120.0f;

    private Rigidbody rb;


    void Start()
    {
        // Do we use gravity and physics if it's in space?
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // button inputs for additional actions
    }

    // What needs to be called per frame
    private void FixedUpdate()
    {
        // Vertical movement based on movement
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * speed * Time.deltaTime * transform.forward;
        rb.MovePosition(rb.position + movement);

        // Horizontal movement and rotation
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        // rb.MoveRotation(rb.rotation + turnRotation);
    }

}

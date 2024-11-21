using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlTest : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = moveSpeed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
        
        print($"xxxxxxxxxxxxx--{controller.isGrounded}--xxxxxxxxxxxxx");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=100f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Control of object's physic properties
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space)) //Press space key 
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)) //Press A key 
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)) //Press D key 
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame) //Change object's rotation
    {
        rb.freezeRotation = true; //Freezing rotation so we can manually rotate

        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); //z axis

        rb.freezeRotation = false; // Unfreezing rotation so the physic system can take over
    }
}

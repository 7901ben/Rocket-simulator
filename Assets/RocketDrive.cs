using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDrive : MonoBehaviour

{
   [SerializeField] float rotationThisFrame;
    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidbody;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();  //typed first
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // print("collided");
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                {
                    print("ok");
                    break;
                }
            case "Fuel":
                {
                    print("ok");
                    break;
                }
            default:
                {
                    print("no");
                    break;
                }
        }
    }
    private void ProcessInput()
    {
        float rcsThrust = 100f;
       if (Input.GetKey(KeyCode.Space)) {
            rigidbody.AddRelativeForce(Vector3.up*mainThrust);
            if (!audioSource.isPlaying)//so it doestnt layer
            {
                audioSource.Play();
            }
        }else
        {
            audioSource.Stop();
        }
        if (Input.GetKey("a"))
        {
           rotationThisFrame= rcsThrust * Time.deltaTime;
            rigidbody.freezeRotation = true;  //take manual control of rotation while tipping
            transform.Rotate(-Vector3.forward*rotationThisFrame);
        }else if (Input.GetKey("d"))
        {
             rotationThisFrame = rcsThrust * Time.deltaTime;
            rigidbody.freezeRotation = true;  //take manual control of rotation while tipping
            transform.Rotate(Vector3.forward);
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        rigidbody.freezeRotation = false;
    }
}

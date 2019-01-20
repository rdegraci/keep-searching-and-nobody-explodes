﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


    public Transform controller;
    public Transform controllerBody;
    public  GameObject objectInRange;
    private GameObject objectHeld;
    public GrabController grabControl;
    public bool isPlayerTwo;
    Vector3 controllerPosition;

        void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (objectHeld != null && !grabControl.triggerPressed)
        {
            ReleaseObject();
        }
        else if(objectInRange != null)
        {
            if (objectInRange.tag == "object" && grabControl.triggerPressed)
            {
                HoldObject(objectInRange);
            }
            if (objectInRange.tag == "wirecutters")
            {
                // TODO: inherit object into controller hierarchy and signal defusing mode
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        print("Collided object: " + collision.gameObject.name);
        //objectInRange = true;
        //objectHeld = collision.gameObject;
    }

   
     void OnTriggerEnter(Collider collision)
    {
        print("Trigger collided object: " + collision.gameObject.name);
        objectInRange = collision.gameObject;
    }

    //Checks if controller is separated from object
    void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject == objectInRange)
        {
            // TODO: handle multiple objects in range
            objectInRange = null;
            print("Trigger exited object: " + collision.gameObject.name);

        }
    }

    //Create Vector 3 for controller position that keeps object at certain distance from controller
    void HoldObject(GameObject obj)
    {
        if (objectHeld == null)
        {
            objectHeld = obj;
        }
        Rigidbody rb  = objectHeld.GetComponent<Rigidbody>();
        float speed = 100.0f;
        rb.drag = 10f;
        rb.useGravity = false;
        rb.AddForce((controller.position - objectHeld.transform.position) * speed);
        objectHeld.transform.LookAt(controllerBody);

    }

    void ReleaseObject()
    {
        if (objectHeld != null)
        {
            Rigidbody rb = objectHeld.GetComponent<Rigidbody>();
            //rb.useGravity = true;
            objectHeld = null;
        }
    }
}
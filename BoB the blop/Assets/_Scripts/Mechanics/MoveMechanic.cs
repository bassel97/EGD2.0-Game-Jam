using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMechanic : MonoBehaviour
{

    //**************************** Private Vars *******************************//
    Rigidbody rb;

    //**************************** Serialized Vars *******************************//
    [SerializeField] float moveSpeed = 1;

    void Start()
    {
        //Setup
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float direction = 0;
        direction = Input.GetAxisRaw("Horizontal");

        float y = rb.velocity.y;
        rb.velocity = Vector3.right * direction * moveSpeed + Vector3.up * y;
    }

    public void Move(float Direction)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMechanic : MonoBehaviour
{

    //**************************** Private Vars *******************************//
    Rigidbody rb;
    ConstantForce cf;

    float jumpVelocity;
    bool isGrounded = false;

    //**************************** Serialized Vars *******************************//
    [SerializeField] float jumpHeight = 1;
    [SerializeField] float characterHeight = 1;

    //**************************** Public Vars *******************************//


    float CalculateJumpForce(float acc, float disp)
    {
        float eqRes1, eqRes2;

        eqRes1 = (1 + Mathf.Sqrt(1 - 4 * 2 * acc * disp)) / 2;
        eqRes2 = (1 - Mathf.Sqrt(1 - 4 * 2 * acc * disp)) / 2;

        if (eqRes1 > 0)
            return eqRes1;
        return eqRes2;
    }

    void Start()
    {
        //Setup
        rb = GetComponent<Rigidbody>();
        cf = GetComponent<ConstantForce>();


        jumpVelocity = CalculateJumpForce(cf.force.y, jumpHeight);
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, characterHeight / 2 + 0.15f);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity += Vector3.up * jumpVelocity;
        }
    }
}

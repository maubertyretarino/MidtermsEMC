using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

    //References
    public Rigidbody Rb;
    //automatic force; used to make the car run automatically
    public float forwardForce = 2000f;
    public float sideForce = 100;
    // Update is called once per frame
    void FixedUpdate()
   
    {
        //Player Movement
        Rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            Rb.AddForce(100 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            Rb.AddForce(-100 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
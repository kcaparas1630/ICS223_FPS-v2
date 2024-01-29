using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //private Rigidbody rb;
    float horizInput;
    float vertInput;
    int speed = 5;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput) * speed * Time.deltaTime * 100;
        transform.Translate(movement);

    }
    private void FixedUpdate()
    {
        
        //rb.velocity = movement;
    }
}

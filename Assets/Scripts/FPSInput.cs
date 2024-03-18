using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    private float speed = 9.0f;
    [SerializeField]
    private CharacterController characterController;
    private float horizInput;
    private float vertInput;
    private float pushForce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        //Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        //apply gravity to player
        movement.y = gravity;
        //take speed into account
        movement *= speed;
        //make movement processor independent
        movement *= Time.deltaTime;

        //Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
        }
        {
            
        }
    }
}

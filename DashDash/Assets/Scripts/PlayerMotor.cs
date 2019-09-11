using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravityForce = 12.0f;

    private float animationDuration = 1f;
    private float startTime;

    private bool isDead = false;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
	}

    // Update is called once per frame
    void Update() {

        if (isDead)
        {
            return;
        }

        if (Time.time - startTime < animationDuration)
        {
            controller.Move(moveVector * Time.deltaTime);
            moveVector.z = speed;
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravityForce * Time.deltaTime;
        }

        // X - Moving left or right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            // Are we holding touch on the right side?
            if(Input.mousePosition.x > Screen.width / 2)
            {
                moveVector.x = speed;
            }else
            {
                moveVector.x = -speed;
            }
        }

        // Y - We are only applying gravity in this direction.
        moveVector.y = verticalVelocity;

        // Z - Forward or backward (only moving forward.
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

	}

    public void setSpeed(float modifier)
    {
        speed = speed + modifier;
    }

    // It is being called every time our capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if (hit.point.z > transform.position.z + controller.radius)
        {
            death();
        }
    }

    private void death()
    {
        isDead = true;
        GetComponent<Score>().onDeath();
    }
}

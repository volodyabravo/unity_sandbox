using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator> ();
    }

    void CharacterMove()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        AnimationController(deltaX, deltaZ);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    void AnimationController(float deltaX, float deltaZ)
    {
        float current_speed;

        bool move_forward = false;
        bool move_backward = false;
        bool move_right = false;
        bool move_left = false;


        if (Math.Abs(deltaZ) > Math.Abs(deltaX)) 
        {
            current_speed = Math.Abs(deltaZ); 
            if (deltaZ > 0)
            {
                move_forward = true;
            } else {
                move_backward = true;
            }
        } 
        else 
        {
            current_speed = Math.Abs(deltaX);
            if (deltaX > 0)
            {
                move_right = true;
            } else {
                move_left = true;
            }
        } 

        Debug.Log(current_speed);

        animator.SetBool("move_forward", move_forward);
        animator.SetBool("move_backward", move_backward);
        animator.SetBool("move_right", move_right);
        animator.SetBool("move_left", move_left);

        animator.SetFloat("speed", current_speed);
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }
}

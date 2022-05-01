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
        bool move_forward = Math.Round(deltaZ, 2) > 0f;
        bool move_backward = Math.Round(deltaZ, 2) < 0f;
        bool move_left = Math.Round(deltaX, 2) < 0f;
        bool move_right = Math.Round(deltaX, 2) > 0f;

        bool move_bl = move_backward & move_left;
        if (move_bl) {
            move_backward = false;
            move_left = false;
        }

        bool move_br = move_backward & move_right;
        if (move_br) {
            move_backward = false;
            move_right = false;
        }

        animator.SetBool("move_forward", move_forward);
        animator.SetBool("move_backward", move_backward);
        animator.SetBool("move_right", move_right);
        animator.SetBool("move_left", move_left);
        animator.SetBool("move_bl", move_bl);
        animator.SetBool("move_br", move_br);
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion : MonoBehaviour
{
    CharacterController characterController;
    Transform playerContainer, cameraContainer;

    public float speed = 6.0f;
    public float jumpSpeed = 10f;
    public float mouseSensitivity = 2f;
    public float gravity = 20.0f;
    public float lookUpClamp = -30f;
    public float lookDownClamp = 60f;
    public bool isGrounded;

    private Vector3 moveDirection = Vector3.zero;
    float rootateX, rotateY;

    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Locomotion();
        
    }

    void Locomotion()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

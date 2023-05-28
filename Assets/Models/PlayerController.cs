using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

public class PlayerController : MonoBehaviour
{
    public Vector3 playerVelocity;
    [AutoProperty] public CharacterController controller;

    public Vector3 velocity;
    public Vector3 head;

    public Transform headTransform;

    public float gravity = -9.81f;

    public bool isFlying = false;
    public bool isGround = false;
    public bool isJumping = false;

    void Start()
    {
        StartCoroutine(DoubleTapCoroutine());
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2f;
        float mouseY = Input.GetAxis("Mouse Y") * 2f;

        transform.Rotate(Vector3.up * mouseX);

        head -= Vector3.right * mouseY;

        head.x = Mathf.Clamp(head.x, -90f, 90f);

        headTransform.localRotation = Quaternion.Euler(head);
    }

    void FixedUpdate()
    {
        velocity.x = Input.GetAxis("Horizontal") * 2f;
        velocity.z = Input.GetAxis("Vertical") * 2f;

        if (isFlying)
        {
            velocity.y = 0f;

            if (Input.GetKey(KeyCode.Space)) velocity.y = 2f;
            if (Input.GetKey(KeyCode.LeftShift)) velocity.y = -2f;
        }
        else
        {
            if (!controller.isGrounded) velocity.y += gravity * Time.fixedDeltaTime;
            else velocity.y = 0;
        }

        controller.Move(velocity * Time.fixedDeltaTime);
    }

    IEnumerator DoubleTapCoroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump();

                yield return null;

                float count = 0f;

                while (count < 0.2f)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        OnDoubleJump();
                        break;
                    }
                    count += Time.deltaTime;
                    yield return null;
                }
            }
            yield return null;
        }
    }

    public void OnJump()
    {
        Debug.Log("Jump");

        velocity.y = gravity * 5f;
    }

    public void OnDoubleJump()
    {
        isFlying = !isFlying;

        Debug.Log("Double Jump");
    }
}

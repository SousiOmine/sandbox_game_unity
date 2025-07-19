using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int Health { get; private set; } = 20;
    [SerializeField] Camera playerCamera;
    [SerializeField] private float moveSpeed = 1f;
    
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction moveAction;

    private Rigidbody rb;
    private bool isJumping = false;

    private void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //前後左右移動
        Vector2 move2d = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(move2d.x, 0, move2d.y) * moveSpeed;
        transform.position += transform.rotation * move * Time.deltaTime;

        //視点移動
        Vector2 look2d = lookAction.ReadValue<Vector2>();
        Vector3 player_move = new Vector3(0, look2d.x, 0) * 0.1f;
        transform.Rotate(player_move);

        float nowCameraXRotation = playerCamera.transform.eulerAngles.x;
        if (nowCameraXRotation > 180) nowCameraXRotation -= 360;
        float newCameraXRotation = nowCameraXRotation - look2d.y * 0.1f;
        newCameraXRotation = Mathf.Clamp(newCameraXRotation, -80f, 80f);
        playerCamera.transform.eulerAngles = new Vector3(newCameraXRotation, playerCamera.transform.eulerAngles.y, playerCamera.transform.eulerAngles.z);

        //ジャンプ
        if(jumpAction.IsPressed())
        {
            Jump();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isJumping)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
            }
        }
    }

    private void Jump()
    {
        if(isJumping) return;
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        isJumping = true;
    }
}

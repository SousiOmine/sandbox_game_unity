using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour, IPlayer
{
    public Vector3 Position { get; set; } = new Vector3(0, 11, 0);
    public Vector3 Rotation { get; set; } = Vector3.zero;
    public int Health { get; set; } = 20;
    
    [SerializeField] Camera playerCamera;
    [SerializeField] private float moveSpeed = 1f;
    
    private InputAction jumpAction;
    private InputAction lookAction;
    private InputAction moveAction;

    private Rigidbody rb;
    private bool isJumping = false;

    private void Awake()
    {

    }

    private void Start()
    {
        transform.position = Position;
        transform.rotation = Quaternion.Euler(Rotation);
        
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("Look");
        moveAction = InputSystem.actions.FindAction("Move");

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //int blockLayer = LayerMask.GetMask("Block");
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, 10f))
        {
            BlockBehaviorBase block = rayHit.collider.GetComponentInParent<BlockBehaviorBase>();
            if (block is not null && block.Block is not null)
            {
                Debug.Log(block.Block.Id);
            }
            else
            {
                Debug.Log(rayHit.collider.gameObject.name);
            }
            //Debug.Log(block.Block.Id);
        }
        
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

        Position = transform.position;
        Rotation = transform.rotation.eulerAngles;
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

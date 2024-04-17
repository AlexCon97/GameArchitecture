using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed=1;
    private Rigidbody rb;
    private Vector3 newVelocity;
    private Vector3 MoveDelta => newVelocity * Time.deltaTime;

    [HideInInspector] public bool IsMovingForward;
    [HideInInspector] public bool IsMovingBackward;
    [HideInInspector] public bool IsMovingRight;
    [HideInInspector] public bool IsMovingLeft;

    public static PlayerController Instance;

    private void Start()
    {
        if (Instance != null) return;
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate() => rb.velocity = MoveDelta;

    private void PlayerMove()
    {
        if (IsMovingForward) MoveForward();
        else StopMoveForward();
    }

    public void MoveForward() => newVelocity.z = speed;
    public void StopMoveForward() => newVelocity.z = 0;

    public void MoveBackward() => newVelocity.z = -speed;
    public void StopMoveBackward() => newVelocity.z = 0;

    public void MoveRight() => newVelocity.x = -speed;
    public void StopMoveRight() => newVelocity.x = 0;

    public void MoveLeft() => newVelocity.x = speed;
    public void StopMoveLeft() => newVelocity.x = 0;
}

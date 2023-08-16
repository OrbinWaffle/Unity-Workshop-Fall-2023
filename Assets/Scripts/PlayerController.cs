using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour{
    [SerializeField] float moveSpeed = 0.25f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float groundCheckDistance = 0.01f;
    [SerializeField] float groundCheckRadius = 1f;
    [SerializeField] LayerMask groundMask;
    float groundCheckDelay = 0.1f;
    Vector2 moveVector;
    CharacterController CC;
    Animator anim;
    bool isGrounded;
    float verticalVelocity = 0f;
    float nextGroundCheckTime = 0f;
    public bool freeze;

    Vector3 spawnPos;

    // Start is called before the first frame update

    void Start(){
        CC = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        spawnPos = transform.position;
    }

    void UpdateAnimations(){
        anim.SetFloat("absMoveSpeed", moveVector.magnitude);
        anim.SetFloat("verticalVelocity", verticalVelocity/jumpSpeed);
        anim.SetBool("isGrounded", isGrounded);
    }
    void OnDrawGizmosSelected()
    {
        if(Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position + (CC.center + transform.up * -CC.height/2) + (transform.up * CC.radius) + (transform.up * (groundCheckRadius-1)), CC.radius * groundCheckRadius);
        }
    }
    void Update()
    {
        if(freeze)
        {
            return;
        }
        UpdateAnimations();
        MovementHandler();
        RotationHandler();
    }
    public void MovementHandler()
    {
        if(Time.time > nextGroundCheckTime && verticalVelocity <= 0)
        {
            isGrounded = Physics.CheckSphere
            (
                transform.position + (CC.center + transform.up * (-CC.height/2 + CC.radius - groundCheckDistance)) 
                + (transform.up * (groundCheckRadius-1)), CC.radius * groundCheckRadius, groundMask, QueryTriggerInteraction.Ignore);
        }

        if(isGrounded && Time.time > nextGroundCheckTime){
            verticalVelocity = 0f;
        }
        else{
            verticalVelocity -= gravity * Time.deltaTime;
        }

        CC.Move(
            new Vector3(moveVector.x, 0, moveVector.y) * moveSpeed * Time.deltaTime
            + Vector3.up * verticalVelocity * Time.deltaTime
        );
    }
    public void RotationHandler()
    {
        if(moveVector != Vector2.zero){
            RotatePlayer(new Vector3(moveVector.x, 0, moveVector.y));
        }
    }
    public void UpdateMoveVector(Vector2 newVec){
        moveVector = newVec;
    }
    public void RotatePlayer(Vector3 vectorToRotateTowards){
        Quaternion targetRotation = Quaternion.LookRotation(vectorToRotateTowards, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void Jump(){
        if(!isGrounded)
        {
            return;
        }
        isGrounded = false;
        nextGroundCheckTime = Time.time + groundCheckDelay;
        verticalVelocity = jumpSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KillZone"))
        {
            transform.position = spawnPos;
            Physics.SyncTransforms();
        }
    }
    public void Freeze(bool doFreeze)
    {
        freeze = doFreeze;
        anim.enabled = !doFreeze;
    }
    public void ResetPlayer()
    {
        moveVector = Vector3.zero;
        verticalVelocity = 0;
        isGrounded = true;
        anim.Rebind();
        anim.Update(0);
    }
}
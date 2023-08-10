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
    [SerializeField] LayerMask groundMask;
    float groundCheckDelay = 0.1f;
    Vector2 moveVector;
    CharacterController CC;
    Animator anim;
    bool isGrounded;
    float verticalVelocity = 0f;
    float nextGroundCheckTime = 0f;

    // Start is called before the first frame update

    void Start(){
        CC = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update(){
        UpdateAnimations();
    }

    void UpdateAnimations(){
        anim.SetFloat("absMoveSpeed", moveVector.magnitude);
        anim.SetFloat("verticalVelocity", verticalVelocity/jumpSpeed);
        anim.SetBool("isGrounded", isGrounded);
    }
    void FixedUpdate()
    {
        if(Time.time > nextGroundCheckTime)
        {
            isGrounded = Physics.CheckBox(transform.position, new Vector3(CC.radius, .1f, CC.radius), Quaternion.identity, groundMask);
        }

        if(isGrounded && Time.time > nextGroundCheckTime){
            verticalVelocity = 0f;
        }
        else{
            verticalVelocity -= gravity * Time.fixedDeltaTime;
        }

        CC.Move(
            new Vector3(moveVector.x, 0, moveVector.y) * moveSpeed * Time.fixedDeltaTime
            + Vector3.up * verticalVelocity * Time.fixedDeltaTime
        );
    }
    public void UpdateMoveVector(Vector2 newVec){
        moveVector = newVec;

        if(newVec != Vector2.zero){
            RotatePlayer(new Vector3(moveVector.x, 0, moveVector.y));
        }
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
        nextGroundCheckTime = Time.time + groundCheckDelay;
        verticalVelocity = jumpSpeed;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class InputController : MonoBehaviour{
    PlayerController PC;
    CameraController CC;
    bool canMove = true;

    // Start is called before the first frame update
    void Start(){
        PC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update(){
        if(canMove == false)
        {
            PC.UpdateMoveVector(Vector2.zero);
            return;
        }
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        PC.UpdateMoveVector(moveVector);
        if (Input.GetButtonDown("Jump")){
            PC.Jump();
        }
        Vector2 lookVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //CC.lookVector = lookVector;
    }
}
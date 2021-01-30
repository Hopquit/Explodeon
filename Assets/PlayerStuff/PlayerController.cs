using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveVec;
    public float speed = 5;
    public CharacterController2D character;
    bool jump = false;
    void Start()
    {
        character = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVec.x * speed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        moveVec = new Vector2(inputVec.x, 0);
    }
    public void OnJump(InputValue input)
    {
        jump = true;
    }
}

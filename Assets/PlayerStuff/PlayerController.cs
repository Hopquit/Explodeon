using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 moveVec;
    public float speed = 5;
    public CharacterController2D character;
    bool jump = false;
    public Transform grenade;
    Vector2 aimVec;
    public float launchSpeed = 500;
    public float grenadeCooldown = 3;
    float currentCooldown;
    public CooldownBar cooldownBar;
    //public Slider mySlider;
    void Start()
    {
        character = GetComponent<CharacterController2D>();
        cooldownBar.slider = GameObject.Find("CooldownBar").GetComponent<Slider>();
        cooldownBar.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (currentCooldown <= 0)
        {
            character.Move(moveVec.x * speed * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
    private void Update()
    {
        //Debug.DrawRay(transform.position, new Vector3(aimVec.x, aimVec.y, 0) * 5);
        currentCooldown -= Time.deltaTime;
        cooldownBar.slider.value = currentCooldown / grenadeCooldown;
 
        // cooldownBar.slider.enabled = currentCooldown >= 0;
        if (currentCooldown >= 0)
        {
            cooldownBar.gameObject.SetActive(true);
            //cooldownBar.slider.enabled = true;
        }
        else
        {
            cooldownBar.gameObject.SetActive(false);
            //cooldownBar.slider.alpha = false;
        }
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
    public void OnFire(InputValue input)
    {
        if (currentCooldown <= 0)
        {
            var launchForce = aimVec * launchSpeed;
            var clone = Instantiate(grenade, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().AddForce(launchForce);
            currentCooldown = grenadeCooldown;
        }
    }
    public void OnAim(InputValue input)
    {
        var inputVec = input.Get<Vector2>();
        if (inputVec != Vector2.zero)
        {
            aimVec = inputVec;
            aimVec.Normalize();
        }
    }
    public void OnPoint(InputValue input)
    {
        var inputVec = input.Get<Vector2>();
        var playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var playerScreenPositionVec2 = new Vector2(playerScreenPosition.x, playerScreenPosition.y);
        aimVec = inputVec - playerScreenPositionVec2;
        aimVec.Normalize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillBox"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("ExplosionBlast"))
        {
            var collisionPosition = new Vector2(collision.transform.position.x, collision.transform.position.y);
            var playerPosition = new Vector2(transform.position.x, transform.position.y);
            var blastForce = playerPosition - collisionPosition;
            
            blastForce.Normalize();
            blastForce *= 2200;

            var rigidbody = GetComponent<Rigidbody2D>();

            rigidbody.AddForce(blastForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float arrowSpeed = 10;
    public Transform explosion;
    public Vector2 arrowDirection;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(arrowDirection.x, arrowDirection.y) * arrowSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        float angle = Mathf.Atan2(arrowDirection.y, arrowDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

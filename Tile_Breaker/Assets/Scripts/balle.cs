using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 _initialVelocity;
    public float _ballSpeed;
    public bool _forceNewVelocity;
    public bool _debugVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = _initialVelocity.normalized * _ballSpeed;
    }

    private void FixedUpdate()
    {
        if (_forceNewVelocity)
            ForceNewVelocity();

        if (_debugVelocity)
            DebugVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInParent<TileBehaviour>() != null)
        {
            collision.gameObject.GetComponentInParent<TileBehaviour>().Break();
        }
    }


    void ForceNewVelocity()
    {
        _forceNewVelocity = false;
        rb.velocity = _initialVelocity.normalized * _ballSpeed;
    }

    void DebugVelocity()
    {
        _debugVelocity = false;
        Debug.Log("Ball Velocity (" + rb.velocity.normalized.x + ", " + rb.velocity.normalized.y + "), current Speed : " + rb.velocity.magnitude);
    }
}

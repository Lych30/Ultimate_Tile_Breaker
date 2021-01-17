using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 _initialVelocity;
    public float _ballSpeed;
    public bool _laser;

    [Space(10)]
    [HideInInspector] public bool _forceNewVelocity;
    [HideInInspector] public bool _debugVelocity;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = _initialVelocity.normalized * _ballSpeed;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude != _ballSpeed)
            rb.velocity = rb.velocity.normalized * _ballSpeed;

        if (CheckForZeroInVelocity())
            rb.velocity = new Vector2(rb.velocity.normalized.x + 0.025f, rb.velocity.normalized.x + 0.025f) * _ballSpeed;

        /*if (_forceNewVelocity)
            ForceNewVelocity();

        if (_debugVelocity)
            DebugVelocity();*/

        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOnScreen()
    {
        if (transform.position.y <= -5.5)
        {
            return false;
        }
        else return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInParent<TileBehaviour>() != null)
        {
            if (!(collision.gameObject.GetComponentInParent<TileBehaviour>()._unbreakable && !_laser))
                collision.gameObject.GetComponentInParent<TileBehaviour>().Break();
        }

        if (collision.gameObject.GetComponentInParent<PlayerMovement>() != null)
        {
            rb.velocity += collision.gameObject.GetComponent<Rigidbody2D>().velocity * 0.5f;
        }
    }

    bool CheckForZeroInVelocity()
    {
        if (rb.velocity.normalized.x == 0 || rb.velocity.normalized.y == 0)
            return true;
        else return false;
    }

    private void OnDestroy()
    {
        LifesSystem.GetInstance().LoseLife();
        GameManager.GetInsatnce().RespawnLaBabale();
        //Debug.Log("LaBabal Destoy");
    }


    /// Debug ///
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

    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (Vector2)transform.position + (rb.velocity.normalized * _ballSpeed * 0.15f));
        }
    }
}

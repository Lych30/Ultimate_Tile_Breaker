using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balle : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-5.0f, 5.0f), 5.0f);
    }
}

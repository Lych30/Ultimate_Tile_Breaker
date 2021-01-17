using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public GameObject _breakParticles;
    public bool _unbreakable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        ScoreSysteme.GetInstance().AddScore(10);
        GameObject instancePart = Instantiate(_breakParticles, transform.position, Quaternion.identity);
        instancePart.GetComponent<ParticleSystem>().startColor = GetComponentInChildren<SpriteRenderer>().color;

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesSystem : MonoBehaviour
{
    private static LifesSystem instance;

    private int lifes = 3;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static LifesSystem GetInstance()
    {
        return instance;
    }

    public void LoseLife()
    {
        lifes--;
    }
}

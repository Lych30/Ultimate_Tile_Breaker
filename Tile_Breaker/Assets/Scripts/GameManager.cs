using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private static GameManager instance;
    [SerializeField]
    private GameObject LaBabale;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager GetInsatnce()
    {
        return instance;
    }

    public void RespawnLaBabale()
    {
        if (LifesSystem.GetInstance().GetLife() > 0)
        {
            Instantiate(LaBabale, new Vector3(0, -3, 0), Quaternion.identity);
        }
    }

}

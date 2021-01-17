using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesSystem : MonoBehaviour
{
    private static LifesSystem instance;

    private int lifes = 3;
    private GameObject[] children;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        children = GetAllChildren();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static LifesSystem GetInstance()
    {
        return instance;
    }

    private void UpdateUi()
    {
        if (lifes == 2)
        {
            children[2].SetActive(false);
        }
        else if (lifes == 1)
        {
            children[1].SetActive(false);
        }
        else if (lifes <= 0)
        {
            children[0].SetActive(false);
        }
    }

    private GameObject[] GetAllChildren()
    {
        GameObject[] allChildren = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            allChildren[i] = transform.GetChild(i).gameObject;
        }

        return allChildren;
    }

    public void LoseLife()
    {
        lifes--;
        UpdateUi();
    }

    public int GetLife()
    {
        return lifes;
    }
}

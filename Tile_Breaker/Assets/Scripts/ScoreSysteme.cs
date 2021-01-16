using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSysteme : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private static ScoreSysteme instance;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        RefreshScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddScore(100);
        }
    }

    public static ScoreSysteme GetInstance()
    {
        return instance;
    }

    private void RefreshScore()
    {
        scoreText.text = scoreText.text.Remove(7) + " " + score;
    }


    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        RefreshScore();
    }
}

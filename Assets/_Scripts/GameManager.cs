using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int PLAYER_SCORE = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        PLAYER_SCORE += score;
        Debug.Log("Player Score: " + PLAYER_SCORE);
    }

    public int GetScore()
    {
        return PLAYER_SCORE;
    }
}

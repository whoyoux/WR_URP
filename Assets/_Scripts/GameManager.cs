using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int PLAYER_SCORE = 0;

    const float PLAYER_MAX_HEALTH = 100f;

    private float PLAYER_HEALTH = PLAYER_MAX_HEALTH;
    

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
        //Debug.Log("Player Score: " + PLAYER_SCORE);
    }

    public int GetScore()
    {
        return PLAYER_SCORE;
    }

    public float GetHealth()
    {
        return PLAYER_HEALTH;
    }

    public void SetHealth(float health)
    {
        PLAYER_HEALTH = health;
        CanvasManager.instance.RenderHealth();
    }

    public void AddHealth(float health)
    {
        PLAYER_HEALTH += health;
        if (PLAYER_HEALTH > PLAYER_MAX_HEALTH)
            PLAYER_HEALTH = PLAYER_MAX_HEALTH;

        CanvasManager.instance.RenderHealth();

        if (PLAYER_HEALTH <= 0)
        {
            PLAYER_HEALTH = 0;
            GAME_OVER();
        }
            
    }

    private void GAME_OVER()
    {
        Debug.Log("Game Over");
        Debug.Log("Game Over");
        Debug.Log("Game Over");
        Debug.Log("Game Over");
        Debug.Log("Game Over");
        Debug.Log("Game Over");
        Time.timeScale = 0f;
    }


}

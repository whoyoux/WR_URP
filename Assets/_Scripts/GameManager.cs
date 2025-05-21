using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int PLAYER_SCORE = 0;

    const float PLAYER_MAX_HEALTH = 100f;

    private float PLAYER_HEALTH = PLAYER_MAX_HEALTH;

    private bool IS_PAUSED = false;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
            
    }

    private void Start()
    {
        //CanvasManager.instance.HideUI();
        //WaitForAcceptTutorial();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IS_PAUSED)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }
        }
    }

    public void LockCursor()
    {
        // Ukrycie i zablokowanie kursora w centrum ekranu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        // Odblokowanie kursora
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void WaitForAcceptTutorial()
    {
        CanvasManager.instance.ShowTutorialPanel();
        PauseGame();
    }
    public void TutorialAccepted()
    {
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        CanvasManager.instance.HideUI();
        CanvasManager.instance.ShowMenu();

        UnlockCursor();

        IS_PAUSED = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        CanvasManager.instance.HideMenu();
        CanvasManager.instance.ShowUI();

        LockCursor();

        IS_PAUSED = false;
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
        PauseGame();
        //CanvasManager.instance.ShowGameOverPanel();
        SceneManager.LoadScene(0);

        //TODO: Przycisk restartu
    }

    public void RenderSwitchesActivated()
    {
        CanvasManager.instance.RenderSwitchesText();
    }

    public void ResetCoins()
    {
        PLAYER_SCORE = 0;
        CanvasManager.instance.RenderCoinsText();
    }

}

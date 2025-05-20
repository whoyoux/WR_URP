using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public Slider healthSlider;

    public List<InvUISlot> invUI = new();

    public GameObject tutorialGameObject;

    public GameObject gameOverGameObject;

    public List<GameObject> uiToHideWhileMenu = new();

    public TextMeshProUGUI switchesText;

    // Singleton pattern
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        RenderScore();
        RenderPlayerInventory();
        RenderSwitchesText();
    }

    public void RenderScore()
    {
        // Aktualizacja tekstu z wynikiem na podstawie danych z GameManagera
        scoreText.text = GameManager.instance.GetScore() + " coins collected";
    }

    public void RenderHealth()
    {
        // Aktualizacja paska zdrowia na podstawie danych z GameManagera
        healthSlider.value = GameManager.instance.GetHealth();
    }

    public void ShowTutorialPanel()
    {
        tutorialGameObject.SetActive(true);
    }

    public void HideUI()
    {
        for (int i = 0; i < uiToHideWhileMenu.Count; i++)
        {
            //Debug.Log("Hiding UI: " + uiToHideWhileMenu[i].name);
            uiToHideWhileMenu[i].SetActive(false);
        }
    }

    public void ShowUI()
    {
        for (int i = 0; i < uiToHideWhileMenu.Count; i++)
        {
            //Debug.Log("Showing UI: " + uiToHideWhileMenu[i].name);
            uiToHideWhileMenu[i].SetActive(true);
        }
    }

    public void AcceptTutorial()
    {
        tutorialGameObject.SetActive(false);
        GameManager.instance.TutorialAccepted();
    }

    public void RenderPlayerInventory()
    {
        // Renderowanie zawartoœci ekwipunku w UI
        for (int i = 0; i < invUI.Count; i++)
        {
            if (i < PlayerInventory.instance.GetInv().Count)
            {
                invUI[i].RenderItem(PlayerInventory.instance.GetInv()[i]);
            }
            else
            {
                invUI[i].RenderItem(null);
            }
        }
    }

    public void ShowGameOverPanel()
    {
        gameOverGameObject.SetActive(true);
    }

    public void RenderSwitchesText()
    {
        int allSwitches = LevelManager.instance.GetSwitchesCount();
        int activatedSwitchesCount = LevelManager.instance.GetActivitedSwitchesCount();
        switchesText.text = activatedSwitchesCount + "/" + allSwitches + " aktywowanych kluczy";
    }
}

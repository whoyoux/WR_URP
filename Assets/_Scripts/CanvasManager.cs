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
}

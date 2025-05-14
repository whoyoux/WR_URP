using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public List<InvUISlot> invUI = new();

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
        scoreText.text = GameManager.instance.GetScore() + " coins collected";
    }

    public void RenderPlayerInventory()
    {
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

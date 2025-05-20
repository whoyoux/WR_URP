using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Switch> switches = new();
    public List<Coin> coins = new();

    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetAllCoinsCount()
    {
        return coins.Count;
    }

    public int GetSwitchesCount()
    {
        return switches.Count;
    }

    public int GetActivitedSwitchesCount()
    {
        int activated = 0;
        for (int i = 0; i < switches.Count; i++)
        {
            if (switches[i].isActivated())
            {
                activated++;
            }
        }

        return activated;
    }

    public bool AreAllSwitchesActivated()
    {
        // Sprawdzanie czy wszystkie switche sa aktywowane
        bool isOk = true;
        for(int i = 0; i < switches.Count; i++)
        {
            if (!switches[i].isActivated())
            {
                isOk = false;
                break;
            }
        }

        return isOk;
    }

    public bool AreAllCoinsTaken()
    {
        if (GetAllCoinsCount() == GameManager.instance.GetScore())
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool CanOpenDoor()
    {
        if(AreAllSwitchesActivated() && AreAllCoinsTaken())
        {
            return true;
        }

        return false;
    }

    public void LevelZeroEndAction()
    {
        //Todo: load level 1
    }
}

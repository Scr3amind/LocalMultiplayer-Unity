using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    [SerializeField] private PlayerUIController playerUIController = null;
    [SerializeField] private Color playerColor = Color.white;
    private string playerName;

    private int currentWins = 0;

    private void Start() 
    {
        playerColor = Color.HSVToRGB(Random.Range(0,1.0f),0.5f,1.0f);
        playerUIController?.setUIColor(playerColor);
    }
    public void setName(string name)
    {
        playerName = name;
        playerUIController?.setPlayerNameText(playerName);
    }

    public string getName()
    {
        return playerName;
    }

    public void addWin()
    {
        currentWins++;
    }

    public int getWins()
    {
        return currentWins;
    }

}

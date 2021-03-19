using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    [SerializeField] private PlayerUIController playerUIController = null;
    [SerializeField] private Color playerColor = Color.white;
    private string playerName;

    private int currentWins = 0;

    public void setPlayerColor(Color color)
    {
        playerColor = color;
        playerUIController?.setUIColor(playerColor);
    }
    

    public Color getPlayerColor()
    {
        return playerColor;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerScreenController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private ParticleSystem pSystem = null;
    private GameObject winnerPlayer;
    private PlayerStatsController playerStats;
    private int totalRounds = 0;
    private UIController uiController;

    private void Start() 
    {
        totalRounds = GameManager.instance.totalRounds;
        uiController = GameManager.instance.GetUIController();
        winnerPlayer = GameManager.instance.getWinnerPlayer();
        playerStats = winnerPlayer.GetComponent<PlayerStatsController>();
        winnerPlayer.transform.position = spawnPoint.position;
        setParticleSystem();
        uiController.showGameOverUI(playerStats.getName(), totalRounds);
    }

    private void setPlayerPosition()
    {
        winnerPlayer.transform.position = spawnPoint.position;
    }

    private void setParticleSystem()
    {
        var main = pSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(Color.white, playerStats.getPlayerColor());
    }
}

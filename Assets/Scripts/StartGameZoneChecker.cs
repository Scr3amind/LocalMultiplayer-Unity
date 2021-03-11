using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameZoneChecker : MonoBehaviour
{
    [SerializeField] private int startNumberForCountDown;
    [SerializeField] private string nextLevelName;
    private int readyPlayers;
    private Coroutine countDownCoroutine = null;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        readyPlayers++;
        if(readyPlayers == GameManager.instance.numOfPlayers && readyPlayers >= GameManager.instance.minPlayers)
        {
            countDownCoroutine = GameManager.instance.startCountDownToNextLevel(startNumberForCountDown);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        readyPlayers--;
        if(countDownCoroutine != null)
        {
            GameManager.instance.stopCountDown(countDownCoroutine);
            countDownCoroutine = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameZoneChecker : MonoBehaviour
{
    [SerializeField] private int startNumberForCountDown;
    [SerializeField] private GameObject startZoneCanvas;
    [SerializeField] private int readyPlayers = 0;
    private Coroutine countDownCoroutine = null;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        readyPlayers++;
        if(readyPlayers == GameManager.instance.numOfTotalPlayers && readyPlayers >= GameManager.instance.minPlayers)
        {
            startZoneCanvas.SetActive(false);
            countDownCoroutine = GameManager.instance.startCountDownToNextLevel(startNumberForCountDown);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        readyPlayers--;
        startZoneCanvas.SetActive(true);
        if(countDownCoroutine != null)
        {
            GameManager.instance.stopCountDown(countDownCoroutine);
            countDownCoroutine = null;
        }
    }
}

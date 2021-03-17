using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text jointText;
    [SerializeField] private TMP_Text countDownText;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private TMP_Text finalWinnerText;

    [SerializeField] private GameObject roundOverUi;
    [SerializeField] private GameObject gameOverUi;
    
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    public void enableJoinText(bool option)
    {
        jointText.gameObject.SetActive(option);
    }

    public void enableCountDownText(bool option)
    {
        countDownText.gameObject.SetActive(option);
    }

    public void setCountDownText(int number) 
    {
        countDownText.text = number.ToString();
    }

    public void setRoundOverUIenabled(bool option)
    {
        roundOverUi.SetActive(option);
    }

    public void setWinnerText(string winner)
    {
        winnerText.text = winner + " Wins!";
    }

    public void showGameOverUI(string winner, int totalRounds)
    {
        finalWinnerText.text = $"{winner} wins! in {totalRounds} rounds!";
        gameOverUi.SetActive(true);
    }

}

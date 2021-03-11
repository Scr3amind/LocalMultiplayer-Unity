using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text jointText;
    [SerializeField] private TMP_Text countDownText;
    
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
}

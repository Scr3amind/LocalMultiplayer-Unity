using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private Canvas playerUICanvas;
    [SerializeField] private float disableTime = 3.0f;
    private Color uiColor = Color.white;

    private void OnEnable() {
        playerUICanvas.gameObject.SetActive(true);
        Invoke("disableUI",disableTime);
    }

    public void setUIColor(Color color)
    {
        uiColor = color;
        playerNameText.color = uiColor;
    }

    public void setPlayerNameText (string playerName)
    {
        playerNameText.text = playerName;
    }

    private void disableUI()
    {
        playerUICanvas.gameObject.SetActive(false);
    }

    private void LateUpdate() {
        // dont flip text
        playerUICanvas.gameObject.transform.localScale = new Vector3(transform.localScale.x, 1.0f,1.0f);
    }
}

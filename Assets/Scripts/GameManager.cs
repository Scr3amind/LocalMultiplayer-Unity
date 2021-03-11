using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int _minPlayers;
    [SerializeField] private int _numOfPlayers;
    [SerializeField] private UIController uIController;
    [SerializeField] private bool playersCanDamage = true;
    [SerializeField] private string nextLevel;
    [SerializeField] private List<GameObject> players;
    public int numOfPlayers
    {get => _numOfPlayers;}
    public int minPlayers
    {get => _minPlayers;}

    private delegate void callback();
    
    private void Awake() {
        if( instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void addPlayer(GameObject player)
    {
        if(numOfPlayers < minPlayers) {
            player.GetComponent<PlayerHealthController>().isInvincible = !playersCanDamage;
            players.Add(player);
            _numOfPlayers++;
        }
        if(numOfPlayers == minPlayers) {
            prepareToStart();
        }
    }

    public void initializePlayers()
    {
        playersCanDamage = true;
        foreach (GameObject player in players)
        {
            player.SetActive(true);
            player.GetComponent<PlayerHealthController>().initializeHealth();
        }
    }

    private void gotoNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public Coroutine startCountDownToNextLevel(int startNumber) 
    {
        uIController.enableCountDownText(true);
        return StartCoroutine(CountDown(startNumber, gotoNextLevel));
    }

    public void stopCountDown(Coroutine countDownToStop)
    {
        StopCoroutine(countDownToStop);
        uIController.enableCountDownText(false);
    }
    IEnumerator CountDown(int startNumber, callback endingAction) 
    {
        int currentNumber = startNumber;
        while(currentNumber >= 0) {
            uIController.setCountDownText(currentNumber);
            currentNumber--;
            yield return new WaitForSeconds(0.5f);
        }
        endingAction();
    }


    private void prepareToStart() {
        uIController.enableJoinText(false);
    }

    

    
}

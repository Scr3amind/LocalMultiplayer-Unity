using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Color[] playerColors = new Color[4];
    [SerializeField] private int _minPlayers;
    [SerializeField] private int _numOfActivePlayers = 0;
    [SerializeField] private int _numOfTotalPlayers;
    [SerializeField] private int currentRound = 0;
    [SerializeField] private int roundsToWin = 3;
    [SerializeField] private bool playersCanDamage = true;
    [SerializeField] private UIController uIController;
    [SerializeField] private List<GameObject> players;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private AudioClip countDownSound;
    private GameObject currentWinner;
    public int numOfActivePlayers
    {get => _numOfActivePlayers;}
    public int minPlayers
    {get => _minPlayers;}
    public int numOfTotalPlayers
    {get => _numOfTotalPlayers;}
    public int totalRounds
    {get => currentRound - 1;}

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
        if(numOfActivePlayers < minPlayers) {
            player.GetComponent<PlayerHealthController>().isInvincible = !playersCanDamage;
            players.Add(player);
            player.GetComponent<PlayerStatsController>().setPlayerColor(playerColors[_numOfTotalPlayers]);
            _numOfTotalPlayers++;
            player.GetComponent<PlayerStatsController>().setName($"Player {_numOfTotalPlayers}");
        }
        if(numOfTotalPlayers == minPlayers) {
            prepareToStart();
        }
    }

    public void reducePlayersAlive()
    {
        _numOfActivePlayers--;
        if(_numOfActivePlayers == 1)
        {
            endRound();
        }
    }

    public void initializePlayers()
    {
        _numOfActivePlayers = 0;
        playersCanDamage = true;
        foreach (GameObject player in players)
        {
            _numOfActivePlayers++;
            player.SetActive(false);
            player.SetActive(true);
            player.GetComponent<PlayerHealthController>().emptyHealth();
            player.GetComponent<PlayerHealthController>().initializeHealth();
        }
    }

    private void endRound()
    {
        findWinner();
        PlayerStatsController winner = currentWinner.GetComponent<PlayerStatsController>();
        winner.addWin();
        uIController.setWinnerText(winner.getName());
        uIController.setRoundOverUIenabled(true);

        if(winner.getWins() >= roundsToWin)
        {
            startCountDownToWinScreen(3);
        }
        else
        {
            startCountDownToNextLevel(5);
        }

    }


    private void findWinner()
    {
        foreach(GameObject player in players)
        {
            if( player.activeInHierarchy)
            {
                currentWinner = player;
            }
        }
    }

    public GameObject getWinnerPlayer()
    {
        return currentWinner;
    }

    public UIController GetUIController()
    {
        return uIController;
    }

    public void setPlayersPositions(List<Vector3> positions)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = positions[i];
        }
    }

    private void gotoWinScreen()
    {
        uIController.setRoundOverUIenabled(false);
        levelManager.loadWinScreen();
        currentRound++;
    }
    private void gotoNextLevel()
    {
        uIController.setRoundOverUIenabled(false);
        levelManager.loadNextLevel(currentRound);
        currentRound++;
    }

    private void prepareToStart() {
        uIController.enableJoinText(false);
    }

    public Coroutine startCountDownToNextLevel(int startNumber) 
    {
        uIController.enableCountDownText(true);
        return StartCoroutine(CountDown(startNumber, gotoNextLevel));
    }

    public Coroutine startCountDownToWinScreen(int startNumber) 
    {
        uIController.enableCountDownText(true);
        return StartCoroutine(CountDown(startNumber, gotoWinScreen));
    }
    public void stopCountDown(Coroutine countDownToStop)
    {
        uIController.enableCountDownText(false);
        StopCoroutine(countDownToStop);
    }
    IEnumerator CountDown(int startNumber, callback endingAction) 
    {
        int currentNumber = startNumber;
        while(currentNumber >= 0) {
            uIController.setCountDownText(currentNumber);
            currentNumber--;
            AudioManager.instance.playSound(countDownSound);
            yield return new WaitForSeconds(1.0f);
        }
        uIController.enableCountDownText(false);
        endingAction();
    }
}

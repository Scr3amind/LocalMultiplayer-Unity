using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private int _minPlayers;
    [SerializeField] private int _numOfActivePlayers;
    [SerializeField] private UIController uIController;
    [SerializeField] private bool playersCanDamage = true;
    [SerializeField] private string nextLevelName;
    [SerializeField] private List<GameObject> players;
    public int numOfActivePlayers
    {get => _numOfActivePlayers;}
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
        if(numOfActivePlayers < minPlayers) {
            player.GetComponent<PlayerHealthController>().isInvincible = !playersCanDamage;
            players.Add(player);
            _numOfActivePlayers++;
        }
        if(numOfActivePlayers == minPlayers) {
            prepareToStart();
        }
    }

    public void reducePlayersAlive()
    {
        _numOfActivePlayers--;
        if(_numOfActivePlayers <= 1)
        {
            endRound();
        }
    }

    public void setNextLevel(string levelName)
    {
        nextLevelName = levelName;
    }
    public void initializePlayers()
    {
        playersCanDamage = true;
        foreach (GameObject player in players)
        {
            player.SetActive(true);
            player.GetComponent<PlayerHealthController>().emptyHealth();
            player.GetComponent<PlayerHealthController>().initializeHealth();
        }
    }

    private void endRound()
    {
        GameObject winner = findWinner();
        Debug.Log("Ended Round");
    }

    private GameObject findWinner()
    {
        foreach(GameObject player in players)
        {
            if( player.activeInHierarchy)
            {
                return player;
            }
        }
        return null;
    }

    public void setPlayersPositions(List<Vector3> positions)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = positions[i];
        }
    }

    private void gotoNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void prepareToStart() {
        uIController.enableJoinText(false);
    }

    public Coroutine startCountDownToNextLevel(int startNumber) 
    {
        uIController.enableCountDownText(true);
        return StartCoroutine(CountDown(startNumber, gotoNextLevel));
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
            yield return new WaitForSeconds(0.5f);
        }
        uIController.enableCountDownText(false);
        endingAction();
    }
}

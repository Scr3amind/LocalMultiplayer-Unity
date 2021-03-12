using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    private void Awake() 
    {
        GameManager.instance.initializePlayers();
        randomizePlayerPositions();
    }

    private void randomizePlayerPositions()
    {
        if(spawnPoints.Count < GameManager.instance.numOfActivePlayers)
        {
            Debug.LogWarning("Insuficient SpawnPoints");
            return;
        }
        else
        {
            List<Vector3> randomPositions = new List<Vector3>();
            for (int i = 0; i < GameManager.instance.numOfActivePlayers; i++)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                randomPositions.Add(randomSpawnPoint.position);
                spawnPoints.Remove(randomSpawnPoint);
            }
            GameManager.instance.setPlayersPositions(randomPositions);
        }
        
    }
}

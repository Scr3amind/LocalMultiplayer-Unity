using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<PowerUp> powerUps;
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private float minSpawnTime = 5.0f;
    [SerializeField] private float maxSpawnTime = 10.0f;

    private void Start() 
    {
        Invoke("spawnPowerUp", Random.Range(minSpawnTime, maxSpawnTime));

    }

    private void spawnPowerUp()
    {
        int index = Random.Range(0, powerUps.Count);
        AudioManager.instance.playSound(spawnSound);
        Instantiate<GameObject>(powerUps[index].gameObject, getSpawnPosition(), Quaternion.identity );
    }
    
    private Vector3 getSpawnPosition()
    {
        if(spawnPoints.Count == 0)
        {
            return new Vector2(Random.Range(-15, 15), Random.Range(-6, 6));
        }
        else{
            return spawnPoints[Random.Range(0, spawnPoints.Count)].position;
        }
    }



}

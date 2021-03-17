using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string[] allLevelNames;
    [SerializeField] private string winScreen;
    [SerializeField] private List<string> shuffledLevelNames = new List<string>();
    void Start()
    {
        generateSuffledLevelList();
    }

    private void generateSuffledLevelList()
    {
        List<int> alreadyAdded = new List<int>();
        while(alreadyAdded.Count != allLevelNames.Length)
        {
            int levelIndex = Random.Range(0, allLevelNames.Length);
            if(!alreadyAdded.Contains(levelIndex))
            {
                alreadyAdded.Add(levelIndex);
                shuffledLevelNames.Add(allLevelNames[levelIndex]);
            }
        }
    }

    public void loadNextLevel(int index)
    {
        int cyclicIndex = index % shuffledLevelNames.Count;
        SceneManager.LoadScene(shuffledLevelNames[cyclicIndex]);
    }

    public void loadWinScreen()
    {
        SceneManager.LoadScene(winScreen);
    }

}

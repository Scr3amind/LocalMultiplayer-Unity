using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    private void Awake() 
    {
        GameManager.instance.initializePlayers();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;

    public Player player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Lose()
    {

    }

    public void Restart()
    {

    }
}

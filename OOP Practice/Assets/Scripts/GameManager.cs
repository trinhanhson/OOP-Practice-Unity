using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] Text scoreText;

    [SerializeField] GameObject UIIngame;
    [SerializeField] GameObject UILose;

    private int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;

            scoreText.text = "Score: " + score;
        }
    }

    private bool isLoss;

    public Player player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (isLoss && Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    public void Lose()
    {
        UIIngame.SetActive(false);

        UILose.SetActive(true);

        isLoss = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

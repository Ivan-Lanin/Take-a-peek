using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private UI uiManager;

    private int difficulty = 1;
    private string currentWord;
    private float score;

    private void Awake()
    {
        TextGenerator.onTextGenerated += SetCurrentWord;
        UI.onInputReceived += AnswerCheck;
        Tile.onSelected += DecreaseScore;
        score = 20f;
    }

    private int GetDifficulty()
    {
        return difficulty;
    }

    private void SetCurrentWord(string word)
    {
        currentWord = word;
    }

    private void AnswerCheck(string answer)
    {
        if (answer == currentWord)
        {
            Debug.Log("Correct!");
            RestartLevel();
        }
    }

    private void DecreaseScore()
    {
        score -= 2f;
        uiManager.SetScoreText(score);
        if (score <= 0)
        {
            Debug.Log("Game Over!");
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        Debug.Log("Restarting Level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

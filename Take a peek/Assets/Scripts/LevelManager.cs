using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private UI uiManager;
    [SerializeField] private GameObject correctPopupTextPrefab;
    [SerializeField] private GameObject wrongPopupTextPrefab;
    [SerializeField] private GameObject pointsAreOutPopupTextPrefab;

    private int difficulty = 1;
    private string currentWord;
    private float score;

    private void Awake()
    {
        SubscribeEvents();
        score = 10f;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
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
        if (answer == "")
            return;
        if (answer == currentWord)
        {
            GameObject correctPopupText = Instantiate(correctPopupTextPrefab, transform);

            RestartLevel();
        }
        else
        {
            GameObject wrongPopupText = Instantiate(wrongPopupTextPrefab, transform);
        }
    }

    private void DecreaseScore()
    {
        score -= 1f;
        uiManager.SetScoreText(score);
        if (score <= 0)
        {
            GameObject pointsAreOutPopupText = Instantiate(pointsAreOutPopupTextPrefab, transform);
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        UnsubscribeEvents();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SubscribeEvents()
    {
        TextGenerator.onTextGenerated += SetCurrentWord;
        UI.onInputReceived += AnswerCheck;
        Tile.onSelected += DecreaseScore;
    }

    private void UnsubscribeEvents()
    {
        TextGenerator.onTextGenerated -= SetCurrentWord;
        UI.onInputReceived -= AnswerCheck;
        Tile.onSelected -= DecreaseScore;
    }
}

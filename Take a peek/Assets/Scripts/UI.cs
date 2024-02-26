using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField inputField;

    public static Action<string> onInputReceived;

    private void Awake()
    {
        inputField.onSubmit.AddListener(OnInputReceived);
        inputField.Select();
    }

    private void OnInputReceived(string input)
    {
        onInputReceived?.Invoke(input);
        inputField.text = "";
    }

    public void SetScoreText(float score)
    {
        scoreText.text = score.ToString();
    }
}

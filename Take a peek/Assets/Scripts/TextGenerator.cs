using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextGenerator : MonoBehaviour
{
    private string[] words = new string[] { "Hello", "World", "Unity", "Game", "Development", "Baka", "Something", "Hopper", "Summertime", 
        "Pineapple", "Watermelon", "Strawberry", "Banana", "Apple", "Orange", "Grape", "Cherry", "Blueberry", "Raspberry", "Blackberry", 
        "Peach", "Plum", "Pear", "Mango", "Papaya", "Coconut", "Kiwi", "Lemon", "Lime", "Grapefruit", "Cantaloupe", "Honeydew", "Mapping",
        "Second", "Delivery", "Taxi", "Terra", "Dragon"};
    private TMP_Text tmpText;

    public static Action<string> onTextGenerated;

    private void OnEnable()
    {
        tmpText = GetComponent<TMP_Text>();
        SetRandomText();
    }

    private void SetRandomText()
    {
        tmpText.text = words[UnityEngine.Random.Range(0, words.Length)];
        onTextGenerated?.Invoke(tmpText.text);
    }
}

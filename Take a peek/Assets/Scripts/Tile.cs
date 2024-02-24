using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Action onSelected;

    private void OnDestroy()
    {
        Debug.Log("Tile Destroyed!");
        onSelected?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Action onSelected;

    public void DestroyByPlayer()
    {
        onSelected?.Invoke();
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class token : MonoBehaviour, items
{
    public static event Action<int> OnTokenCollect;
    public int value = 0;
    public void Collect()
    {
        OnTokenCollect?.Invoke(value);
        Destroy(gameObject);
    }
    public static void ResetEvents()
    {
        OnTokenCollect = null;
    }
}

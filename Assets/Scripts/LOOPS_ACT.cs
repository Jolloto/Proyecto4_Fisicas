using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOPS_ACT : MonoBehaviour
{
    
    private void Start()
    {
        for (int i = 1; i <= 100; i++)
        {
            Debug.Log($"{i}");
        }

        for (int i = 1; i % 2 <= 100; i++)
        {
            Debug.Log($"{i}");
        }
    }
}

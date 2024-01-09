using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    
    private void Start()
    {
        for (int i = 1; i <= 10; i++) 
        {
            Debug.Log(message: "Hola");
        }
    }

}

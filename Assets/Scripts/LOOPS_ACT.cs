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

        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log($"{i}");
            }
        }

        for (int i = 1; i <= 100; i+=2)
        {
            Debug.Log($"{i}");
        }

        int suma = 0, numero = 1;
        while (numero <= 10)
        {
           suma += numero;
           numero++;
        }
        Debug.Log($"{suma}");

        int suma2 = 0, tope = 5;
        while (tope >= 0)
        {
           suma2 += tope;
           tope--;
        }
        Debug.Log($"{suma2}");

        int producto = 0, valor = 1;
        while (valor <= 20)
        {
           producto *= valor;
           valor++;
        }
        Debug.Log($"{producto}");

        int productous = 0, cosa = 5;
        while (cosa >= 0)
        {
           productous *= cosa;
           cosa--;
        }
        Debug.Log($"{productous}");

        int AstonMartin = 11;
        for (int i = 1; i <= 20; i++)
        {
            int result = AstonMartin * i;
            Debug.Log(AstonMartin + " x " + i + " = " + result);
        } 
       

    }
}

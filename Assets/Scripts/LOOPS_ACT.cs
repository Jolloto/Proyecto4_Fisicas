using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOPS_ACT : MonoBehaviour
{
    
    private void ACT1() 
    {
        for (int i = 1; i <= 100; i++)
        {
            Debug.Log($"{i}");
        }
    }

    private void ACT2() 
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log($"{i}");
            }
        }
    }

    private void ACT3()
    {
        for (int i = 1; i <= 100; i += 2)
        {
            Debug.Log($"{i}");
        }
    }

    private void ACT4() 
    {
        int suma = 0, numero = 1;
        while (numero <= 10)
        {
            suma += numero;
            numero++;
        }
        Debug.Log($"{suma}");
    }

    private void ACT5()
    {
        int suma2 = 0, tope = 5;
        while (tope >= 0)
        {
            suma2 += tope;
            tope--;
        }
        Debug.Log($"{suma2}");
    }

    private void ACT6()
    {
        int producto = 0, valor = 1;
        while (valor <= 20)
        {
            producto *= valor;
            valor++;
        }
        Debug.Log($"{producto}");
    }

    private void ACT7()
    {
        int productous = 0, cosa = 5;
        while (cosa >= 0)
        {
            productous *= cosa;
            cosa--;
        }
        Debug.Log($"{productous}");
    }

    private void ACT8()
    {

    }

    private void Start()
    {
        ACT1();

        ACT2();

        ACT3();

        ACT4();

        ACT5();

        ACT6();
        
        ACT7();

        ACT8();






        int AstonMartin = 11;
        for (int i = 1; i <= 20; i++)
        {
            int result = AstonMartin * i;
            Debug.Log(AstonMartin + " x " + i + " = " + result);
        }

        int number=11;
        for (int i = 1; i <= 20; i++)
        {
            Debug.Log(number + "x" + i + "=" + number * i);
        }

        //Las tablas (1,2,3,4,5,6,7,8,9,10,11)  dentro de la tabla (1 al 11)
    }
}

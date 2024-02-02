using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// level Brain and components
/// </summary>
public class SpawnManager : MonoBehaviour
{
    [SerializeField] int fibonocic1 = 1;
    [SerializeField] int fibonocic2 = 1;
    [SerializeField] int fibonocic3 = 1;

    [SerializeField] int stepsFor1 = 1;
    [SerializeField] int stepsFor2 = 1;
    [SerializeField] int stepsFor3 = 1;
    private void Start()
    { 

    }

    /// <summary>
    /// Getting 1st Variation
    /// </summary>
    private void GetSoldierCount1() 
    {
        fibonocic1 = Fibonacci(stepsFor1);
        stepsFor1++;
    }
    /// <summary>
    /// Getting 2nd Variation
    /// </summary>
    private void GetSoldierCount2()
    {
        fibonocic2 = Fibonacci(stepsFor2);
        stepsFor2++;
    }
    /// <summary>
    /// Getting 3d variation
    /// </summary>
    private void GetSoldierCount3()
    {
        fibonocic3 = Fibonacci(stepsFor3);
        stepsFor3++;
    }
    /// <summary>
    /// Generating Fibonacci numbers
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    private int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

}

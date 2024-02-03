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

    [SerializeField] float time1 = 2f;
    [SerializeField] float time2 = 3f;
    [SerializeField] float time3 = 5f;

    [SerializeField] SoldierRequester requester;
    public SoldierRequester Requester { get { return requester; } }

    [SerializeField] bool auto;
    [SerializeField] Health health;
    /// <summary>
    /// Destroyed
    /// </summary>
    private void OnEnable()
    {

        health.death += OnBaseDestroyed;
        if (requester.GetBaseType == SoldierBaseType.Enemy) 
        {
            GameManager.Instance.GetLevelMange.levelStarted += LevelStarted;
        }
    }

    private void OnDisable()
    {
        health.death -= OnBaseDestroyed;
        if (requester.GetBaseType == SoldierBaseType.Enemy)
        {
            GameManager.Instance.GetLevelMange.levelStarted -= LevelStarted;
        }
    }

    private void OnBaseDestroyed(Health baseHealth) 
    {
        if (requester.GetBaseType == SoldierBaseType.Player)
        {
            Debug.Log("Player base destroyed");
            GameManager.Instance.GetLevelMange.OnLevelLose();
            StopAllCoroutines();
        }
        else 
        {
            GameManager.Instance.GetLevelMange.OnLevelWIN();
            StopAllCoroutines();
        }
    }




    private void LevelStarted(int level) 
    {
        StartLoop();
    }

    public void StartLoop() 
    {
        StartCoroutine(FibonocicCaller());
    }

    IEnumerator FibonocicCaller() 
    {
        yield return new WaitForSeconds(time1);
        Debug.Log("Setp1 :" + stepsFor1);
        GetSoldierCount1();
        if (stepsFor1 > 5) 
        {
            yield return new WaitForSeconds(time2);
            Debug.Log("Setp2 :" + stepsFor2);
            GetSoldierCount2();
        }
        if (stepsFor2 > 5) 
        {
            yield return new WaitForSeconds(time3);
            Debug.Log("Setp1 :" + stepsFor3);
            GetSoldierCount3();
        }
        StartLoop();
        
    }







    /// <summary>
    /// Getting 1st Variation
    /// </summary>
    private void GetSoldierCount1() 
    {
        fibonocic1 = Fibonacci(stepsFor1);
        stepsFor1++;
        for (int i = 0; i < fibonocic1; i++)
        {
            requester.GetSoldier(SolderType.Ground);
        }
    }
    /// <summary>
    /// Getting 2nd Variation
    /// </summary>
    private void GetSoldierCount2()
    {
        fibonocic2 = Fibonacci(stepsFor2);
        stepsFor2++;
        for (int i = 0; i < fibonocic2; i++)
        {
            requester.GetSoldier(SolderType.Thrower);
        }
    }
    /// <summary>
    /// Getting 3d variation
    /// </summary>
    private void GetSoldierCount3()
    {
        fibonocic3 = Fibonacci(stepsFor3);
        stepsFor3++;
        for (int i = 0; i < fibonocic3; i++)
        {
            requester.GetSoldier(SolderType.Knight);
        }

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



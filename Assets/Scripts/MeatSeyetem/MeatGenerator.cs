using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MeatGenerator : MonoBehaviour
{
    public delegate void FoodStatue();
    public FoodStatue StopGenerating;
    public FoodStatue StartGenerating;

    public delegate void MeatStatus(int meatCount);
    public MeatStatus FoodGenerated;
    public MeatStatus CheckFoodUpdate;

    [SerializeField] int meatCount = 2;
    public int GetMeatCount => meatCount;
    LevelManager levelManager;

    private void OnEnable()
    {
        levelManager= GetComponent<LevelManager>();
    }
    private void Start()
    {
       
    }


    /// <summary>
    /// generating meat here
    /// </summary>
    private void GenerateMeat()
    {
        float temp = 1f;

        // accessaing meat generate time from level manager
        //not efficient
        float meatGenerateTime = levelManager.GetMeatGenerateTime;

        DOTween.To(() => temp, x => temp = x, 0f, meatGenerateTime).OnComplete(() =>
        {
            meatCount++;
            FoodGenerated?.Invoke(meatCount);
            GenerateMeat();
#if UNITY_EDITOR
            Debug.Log("MeatCount");
#endif
        }).SetId("FoodGenerator").SetSpeedBased();
    }

    /// <summary>
    /// It will start generating meat
    /// </summary>
    public void StartMeatGeneration()
    {
#if UNITY_EDITOR
        Debug.Log("MeatCount Start");
#endif
        StartGenerating?.Invoke();
        GenerateMeat();
    }

    /// <summary>
    /// it will kill the meatgenerating tween
    /// </summary>
    
    private void StopMeatGeneration() {
        StopGenerating?.Invoke();
#if UNITY_EDITOR
        DOTween.Kill("FoodGenerator");
#endif
    }


    /// requird upgread subscriber
    public void DeductMeat(int cost) 
    {
        if (cost <= meatCount) 
        {
            meatCount -= cost;
            CheckFoodUpdate?.Invoke(meatCount);
        }
    }
}

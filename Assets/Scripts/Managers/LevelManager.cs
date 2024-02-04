using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// responsible for managing levels
/// 
/// Loading Unity UI scene additive mode
/// task
/// take update from game manager from start
/// 
/// keep track of player coin
/// keep track of player point 
/// report will or fail to the game manager 
/// 
/// </summary>
/// 

public class LevelManager : MonoBehaviour
{
    public delegate void LevelStatus(int levelNumber);
    public LevelStatus level;
    public LevelStatus levelStarted;
    public LevelStatus levelWIN;
    public LevelStatus levelFailed;

    [SerializeField] float meatGenerateTime = .2f;
    public float GetMeatGenerateTime => meatGenerateTime;

    [SerializeField] int levelNumber = 1;
    /// <summary>
    /// Runtime
    /// </summary>
    [SerializeField, BoxGroup("Runtime")] private MeatGenerator meatGenerator;
    [SerializeField] List<int> soldierCosts = new List<int>();
    public List<int> GetCosts { get { return soldierCosts;} }
    public MeatGenerator GetMeatGenerator=> meatGenerator;// getter
    private void OnEnable()
    {
        meatGenerator = GetComponent<MeatGenerator>();
    }


    public void StartLevel() 
    {
        meatGenerator.StartMeatGeneration();
        levelStarted?.Invoke(levelNumber);
    }


    public void OnLevelWIN()
    {

        levelWIN?.Invoke(levelNumber);
    }
    public void OnLevelLose()
    {
        GameManager.Instance.GetEnemyBase.gameObject.SetActive(false);
        Debug.Log("Player Lose ==========================================================");
        levelFailed?.Invoke(levelNumber);

    }

}

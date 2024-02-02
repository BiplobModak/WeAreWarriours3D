using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// only for holding all information
/// </summary>
public class GameManager : MonoBehaviour
{
    //singlen tone
    //Game win 
    //game lose 
    //player status
    public static GameManager Instance;


    /// <summary>
    /// manage the level
    /// </summary>
    private LevelManager correnLevelManger;

    /// <summary>
    /// Getting level manager. 
    /// </summary>
    public LevelManager GetLevelMange => correnLevelManger;

    /// <summary>
    /// Player Base
    /// </summary>
    [SerializeField] private SpawnManager playerSpanManager;
    [SerializeField] private SpawnManager enemySpawnManager;

    public SpawnManager GetPlayerBase { get { return playerSpanManager; } }
    public SpawnManager GetEnemyBase { get { return enemySpawnManager; } }
    
   private void Awake()
   {

        ///single tone
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance!= this) 
        {
            Destroy(gameObject);

        }
    }
    private void OnEnable()
    {
        //process havy
        correnLevelManger = GameObject.FindAnyObjectByType<LevelManager>();  
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// resposible for manageing levels
/// 
/// Loading Unity UI scene aditive mode
/// task
/// take update from game manaer fomr start
/// Manageing level porgration
/// keep track of player coin
/// keep track of player point 
/// report will or fail to the game manager 
/// 
/// </summary>
public class LevelManager : MonoBehaviour
{

    [SerializeField] float meatGenerateTime = .2f;
    public float GetMeatGenerateTime => meatGenerateTime;


    [SerializeField] private MeatGenerator meatGenerator;
    public MeatGenerator GetMeatGenerator=> meatGenerator;// getter
    private void OnEnable()
    {
        meatGenerator = GameObject.FindAnyObjectByType<MeatGenerator>();
    }


    public void StartLevel() 
    {
        meatGenerator.StartMeatGeneration();
    }



}

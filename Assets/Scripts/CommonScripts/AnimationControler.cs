using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defining player has only 3 scope of animation 
/// </summary>
public enum BasicAnimationStage 
{
    Idle,Move,Attack,Death
}

/// <summary>
/// only user for stracture data
/// </summary>
[Serializable]
public struct AnimeStage 
{
    [SerializeField] public BasicAnimationStage animatonStage;
    [SerializeField] public int value;    
}

/// <summary>
/// controling animationa and controler
/// </summary>
public class AnimationControler : MonoBehaviour
{
    /// <summary>
    /// for Editor input only
    /// </summary>
    [SerializeField,Tooltip("Soldier Animation Name and value goes here")] List<AnimeStage> states = new List<AnimeStage>();
    /// <summary>
    /// for Easy acccess
    /// </summary>
    [SerializeField] private Dictionary<BasicAnimationStage, int> animationvalue = new Dictionary<BasicAnimationStage, int>();
    /// <summary>
    /// player aniamton
    /// </summary>
    [SerializeField, Required] Animator animator;
    [SerializeField] string bleand = "Bleand";

    private void OnEnable()
    {
        foreach (AnimeStage stage in states)
        {
            animationvalue.Add(stage.animatonStage, stage.value);
        }
        
      
    }
    /// <summary>
    /// playe Attack animation
    /// </summary>
    public void Attack() 
    {
        animator.SetFloat(bleand, animationvalue[BasicAnimationStage.Attack]);
    }

    /// <summary>
    /// playe idel animation
    /// </summary>
    public void Idel()
    {
        animator.SetFloat(bleand, animationvalue[BasicAnimationStage.Idle]);
    }
    /// <summary>
    /// play move animation
    /// </summary>
    public void Move()
    {
        animator.SetFloat(bleand, animationvalue[BasicAnimationStage.Move]);
    }
    /// <summary>
    /// Playing Death Animation
    /// </summary>
    public void Death()
    {
        animator.SetFloat(bleand, animationvalue[BasicAnimationStage.Death]);
    }
}

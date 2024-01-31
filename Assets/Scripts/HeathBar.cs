using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] HealthStatus healthStatus;
    [SerializeField] private Image fillHalth;
    float unit;
    private void OnEnable()
    {
        fillHalth.fillAmount = 1;
        unit = 1 / healthStatus.GetMaxHelath;

        //Health status

        healthStatus.damage += OnGetDamage;
        healthStatus.death += OnGetDamage;
    }



    private void OnDisable()
    {
        healthStatus.damage -= OnGetDamage;
        healthStatus.death -= OnGetDamage;

    }
    private void OnGetDamage(float heath) 
    {
        fillHalth.fillAmount = heath*unit;
    }


    /// <summary>
    /// Looking at camera
    /// </summary>
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}

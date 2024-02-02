using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] Health healthStatus;
    [SerializeField] private Image fillHalth;
    float unit;
    private void OnEnable()
    {
        fillHalth.fillAmount = 1f;
        unit = 1f / healthStatus.GetMaxHelath;

        //Health status
        healthStatus.damageflag += OnGetDamage;
    }

    private void OnDisable()
    {
        healthStatus.damageflag -= OnGetDamage;

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

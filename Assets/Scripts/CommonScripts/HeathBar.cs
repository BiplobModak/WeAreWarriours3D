using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updating the bar and seawall looking at the camera
/// </summary>
public class HeathBar : MonoBehaviour
{
    [SerializeField] Health healthStatus;
    [SerializeField] private Image fillHalth;
    [SerializeField] private TextMeshProUGUI helath;
    float unit;

    private void OnEnable()
    {
        //searching in Roots
        healthStatus = transform.root.gameObject.GetComponent<Health>();
        if (helath != null) 
        {
            helath.text = healthStatus.HealthValue.ToString()+"/"+ healthStatus.GetMaxHelath.ToString();
        }

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
        if(helath!=null)
            helath.text = healthStatus.HealthValue.ToString() + "/" + healthStatus.GetMaxHelath.ToString();
    }


    /// <summary>
    /// Looking at camera
    /// </summary>
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}

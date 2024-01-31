using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    [SerializeField] Image meatfeelIamge;
    [SerializeField] TextMeshProUGUI meatCount;
    float meatGenerateTime = .2f;
    [SerializeField] GameObject startPanal, gamePanal;
    /// <summary>
    /// subscribing everyting
    /// </summary>
    private void Start()
    {
        meatGenerateTime = GameManager.Instance.GetLevelMange.GetMeatGenerateTime;
        Debug.Log("meat Generate Time :   " + meatGenerateTime);

        GameManager.Instance.GetLevelMange.GetMeatGenerator.StartGenerating += UpdateFillImage;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.StopGenerating += StopFilling;
        //meat count
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated += UpdateCount;
    }
    

    /// <summary>
    /// unsubcriving everiyting 
    /// </summary>
    private void OnDestroy()
    {

        GameManager.Instance.GetLevelMange.GetMeatGenerator.StartGenerating -= UpdateFillImage;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.StopGenerating -= StopFilling;
        // meat 
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated -= UpdateCount;

    }



    /// <summary>
    /// updating meat fill image
    /// </summary>
    /// <param name="meatCount"></param>
    private void UpdateFillImage() 
    {
        float temp = 0f;
        DOTween.To(() => temp, x => temp = x, 10f, meatGenerateTime).SetSpeedBased().OnComplete(() =>
        {
            meatfeelIamge.fillAmount = 0f;
            UpdateFillImage();
        }).OnUpdate(() => {
            meatfeelIamge.fillAmount = temp/10f;
        }).SetEase(Ease.Linear);

        /// speed modifier not woring
        //meatfeelIamge.DOFillAmount(1f, meatGenerateTime).OnComplete(() =>
        //{
        //    //looping
        //}).SetEase(Ease.Linear).; 
    }

    /// <summary>
    /// Stop ui animaiton
    /// </summary>
    private void StopFilling() 
    {
        meatfeelIamge.DOKill();
    }
    /// <summary>
    /// updating meat count
    /// </summary>
    /// <param name="count"> Meatgenertor's Meat count</param>
    private void UpdateCount(int count) 
    {
        meatCount.text = count.ToString("00");
    }


    public void StertGame() 
    {
        GameManager.Instance.GetLevelMange.StartLevel();
        gamePanal.SetActive(true);
        startPanal.SetActive(false);
    }
}

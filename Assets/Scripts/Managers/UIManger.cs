using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    [SerializeField] Image meatfeelIamge;
    [SerializeField] TextMeshProUGUI meatCount;
    float meatGenerateTime = .2f;
    [SerializeField] GameObject startPanal, gamePanal, winPanal, losePanal;
    /// <summary>
    /// subscribing everything
    /// </summary>
    private void OnEnable()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(.1f);

        meatGenerateTime = GameManager.Instance.GetLevelMange.GetMeatGenerateTime;
        Debug.Log("meat Generate Time :   " + meatGenerateTime);

        GameManager.Instance.GetLevelMange.GetMeatGenerator.StartGenerating += UpdateFillImage;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.StopGenerating += StopFilling;
        //meat count
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated += UpdateCount;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.CheckFoodUpdate += UpdateCount;

        //Win Lose
        GameManager.Instance.GetLevelMange.levelWIN += OnLevelWin;
        GameManager.Instance.GetLevelMange.levelFailed += OnLevelFailed;
    }
    

    /// <summary>
    /// unsubscribing everything 
    /// </summary>
    private void OnDestroy()
    {

        GameManager.Instance.GetLevelMange.GetMeatGenerator.StartGenerating -= UpdateFillImage;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.StopGenerating -= StopFilling;
        // meat 
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated -= UpdateCount;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.CheckFoodUpdate -= UpdateCount;

        //Win lose
        GameManager.Instance.GetLevelMange.levelWIN -= OnLevelWin;
        GameManager.Instance.GetLevelMange.levelFailed -= OnLevelFailed;
    }



    /// <summary>
    /// updating meat fill image
    /// </summary>
    /// <param name="meatCount"></param>
    private void UpdateFillImage() 
    {
        float temp = 0f;
        DOTween.To(() => temp, x => temp = x, 1f, meatGenerateTime).OnComplete(() =>
        {
            meatfeelIamge.fillAmount = 0f;
            UpdateFillImage();
        }).SetSpeedBased().OnUpdate(() => {
            meatfeelIamge.fillAmount = temp;
        }).SetEase(Ease.Linear);

        /// speed modifier not working
        //meatfeelIamge.DOFillAmount(1f, meatGenerateTime).OnComplete(() =>
        //{
        //    //looping
        //}).SetEase(Ease.Linear).; 
    }

    /// <summary>
    /// Stop ui animation
    /// </summary>
    private void StopFilling() 
    {
        meatfeelIamge.DOKill();
    }
    /// <summary>
    /// updating meat count
    /// </summary>
    /// <param name="count"> Generator's Meat count</param>
    private void UpdateCount(int count) 
    {
        meatCount.text = count.ToString("00");

    }


    public void StartGame() 
    {
        GameManager.Instance.GetLevelMange.StartLevel();
        gamePanal.SetActive(true);
        startPanal.SetActive(false);
        meatCount.text = GameManager.Instance.GetLevelMange.GetMeatGenerator.GetMeatCount.ToString("00");
    }

    public void OnLevelWin(int levelNumber) 
    {
        gamePanal.SetActive(false);
        winPanal.SetActive(true);
    }
    public void OnLevelFailed(int levelNumber)
    {
        gamePanal.SetActive(false);
        losePanal.SetActive(true);
    }
    public void Restart() 
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }
    public void AddMeat() 
    {
        //only for testing purpose
        GameManager.Instance.GetLevelMange.GetMeatGenerator.GetMeatCount = 200;
    }
}

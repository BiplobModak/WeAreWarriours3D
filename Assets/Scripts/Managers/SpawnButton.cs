using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnButton : MonoBehaviour
{
    [SerializeField] SolderType soldier;
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void OnEnable()
    {
        int t = (int)soldier;
        textMeshProUGUI.text = t.ToString("00");

        StartCoroutine(DelayCall());
        
    }

    IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.Instance.GetLevelMange.GetMeatGenerator.CheckFoodUpdate += OnMeatUpdate;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated += OnMeatCreate;
    }

    private void OnDisable()
    {
        GameManager.Instance.GetLevelMange.GetMeatGenerator.CheckFoodUpdate -= OnMeatUpdate;
        GameManager.Instance.GetLevelMange.GetMeatGenerator.FoodGenerated -= OnMeatCreate;

    }
    
    private void OnMeatCreate(int meatCount) 
    {
        if (meatCount >= (int)soldier )
        {
            ActivateButton();
        }
    }


    private void ActivateButton() 
    {
        button.enabled = true;
        //enabled
        image.color = new Color(1f, 1f, 1f, 1f);
    }
    private void DeactivateButton()
    {
        button.enabled = false;
        //enabled
        image.color =  new Color(1f, 1f, 1f, .5f);
    }

    private void OnMeatUpdate(int meatCount) 
    {
        if (meatCount >= (int)soldier)
        {
            ActivateButton();
        }
        else 
        {
            DeactivateButton();
            //disable stage
        }
    }

    public void OnButtonClicked() 
    {
        //update meat count
        // check meat cost
        GameManager.Instance.GetLevelMange.GetMeatGenerator.DeductMeat((int)soldier);
        
        GameManager.Instance.GetPlayerBase.Requester.GetSoldier(soldier);
    }
}

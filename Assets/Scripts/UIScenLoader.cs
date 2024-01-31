
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScenLoader : MonoBehaviour
{
    [SerializeField, Tooltip("Must Improt UI scen to BuildSetting")] int uIsceneBuildIndex = 1;

    private void OnEnable()
    {
       
        SceneManager.LoadScene(uIsceneBuildIndex, LoadSceneMode.Additive);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int fps = Mathf.RoundToInt(1.0f / deltaTime);
        string text = $"FPS: {fps}";

        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 100, 60), text, style);
    }
}

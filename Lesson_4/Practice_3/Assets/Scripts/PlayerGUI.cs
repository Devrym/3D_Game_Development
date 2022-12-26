using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    private float mySlider = 1.0f;
    public Color objectColor;
    public MeshRenderer gameObject;

    void OnGUI()
    {
        objectColor = RGBASlider(new Rect(10, 30, 200, 20), objectColor);
        gameObject.material.color = objectColor;
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height);
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, sliderMinValue, sliderMaxValue);
        return sliderValue;
    }

    Color RGBASlider (Rect screenRect, Color rgba)
    {
        rgba.r = LabelSlider(screenRect, rgba.r, 0.0f, 1.0f, "Red");

        screenRect.y += 20;
        rgba.g = LabelSlider(screenRect, rgba.g, 0.0f, 1.0f, "Green");

        screenRect.y += 20;
        rgba.b = LabelSlider(screenRect, rgba.b, 0.0f, 1.0f, "Blue");

        screenRect.y += 20;
        rgba.a = LabelSlider(screenRect, rgba.a, 0.0f, 1.0f, "Alpha");

        return rgba;
    }    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }

    }
}

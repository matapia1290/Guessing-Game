using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundColorChange : MonoBehaviour
{
    public Slider Rslider;
    public Slider Bslider;
    public Slider Gslider;
    public Camera mainCamera;

   


    // Update is called once per frame
    void Update()
    {
        ColorChange();    
    }
    void Start()
    {
        //ColorChange();
    }

    void ColorChange() 
    {
        float RcolorSlider = Rslider.value;
        float GcolorSlider = Gslider.value;
        float BcolorSlider = Bslider.value;
        



        Color color = new Color(RcolorSlider, GcolorSlider, BcolorSlider);
        mainCamera.backgroundColor = color;

        
        
    }
}

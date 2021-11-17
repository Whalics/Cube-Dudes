using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ForceSliderController : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Slider forceSlider;
    public Animator sliderAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSliderValue(float val){
        forceSlider.value = val;
        fill.color = gradient.Evaluate(forceSlider.normalizedValue);
    }

    public void SliderIn(){
        sliderAnimator.Play("In_TEMP");
    }

    public void SliderOut(){
        sliderAnimator.Play("Out_TEMP");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSliderController : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Slider turnSlider;
    public float sliderVal;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update(){
        if(sliderVal >= 1){
            Debug.Log("Turn");
        }
    }
    public void SetSliderValue(float val){
        turnSlider.value = val;
        //fill.color = gradient.Evaluate(turnSlider.normalizedValue);
    }
    // Update is called once per frame
    public void IncreaseValue(float inc){
        sliderVal+=inc*Time.deltaTime;
        SetSliderValue(sliderVal);
            
    }

    public void ResetSlider(){
        sliderVal = 0;
        SetSliderValue(sliderVal);
    }
}

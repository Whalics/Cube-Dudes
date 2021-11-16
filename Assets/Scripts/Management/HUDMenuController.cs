using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUDMenuController : MonoBehaviour
{
    public EventSystem eventSystem;
    [SerializeField] GameObject abilityButton; 
    [SerializeField] Animator HUDAnimator;
    void Start()
    {
        
    }

    public void OpenMenu(){
        SetSelectedButton(abilityButton);
        HUDAnimator.Play("In_TEMP");
    }

    public void CloseMenu(){
        HUDAnimator.Play("Out_TEMP");
        SetSelectedButton(null);
    }

    public void SetSelectedButton(GameObject btn){
        eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
    }

    
}

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
    [SerializeField] GameObject[] abilityBTNS;
    GameManager gamemanager;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetAbilityButtons();
    }

    public void AssignAbilityButton(){
    abilityButton = abilityBTNS[gamemanager.GetTurn()];
    }

    public void OpenMenu(){
        AssignAbilityButton();
        SetSelectedButton(abilityButton);
        HUDAnimator.Play("In_TEMP");
    }

    void SetAbilityButtons(){
        for(int i = 0; i < gamemanager.GetPlayerCount(); i++)
        abilityBTNS[i].GetComponent<AbilityCardDisplay>().character = gamemanager.GetCharacterClass().character;;
    }

    public void CloseMenu(){
        HUDAnimator.Play("Out_TEMP");
        SetSelectedButton(null);
    }

    public void SetSelectedButton(GameObject btn){
        eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
    }

    
}

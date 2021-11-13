using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, ISelectHandler
{
    public MainMenuController mainmenucontroller;
    Vector3 offset = new Vector3(25,0,0);
    void Start(){
    }

    public void OnSelect(BaseEventData eventData)
        {
            MoveCharacterSelector();

        }

    public GameObject ReturnButtonSelected(){
            return this.gameObject;
        }

    public void MoveCharacterSelector(){
        mainmenucontroller.selectors[PlayerManagerSingleton.Instance.playerSelecting].transform.position = ReturnButtonSelected().transform.position+offset;
    }
}

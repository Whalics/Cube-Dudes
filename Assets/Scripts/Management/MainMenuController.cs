using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _mainThemeAudio;
    public EventSystem eventSystem;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject c1;
    public GameObject[] selectors;
    public GameObject selectorHider;

    public void Start(){
        ShowCursor();
        PlayMainTheme();
    }

    public void StartGame(){
        
    }

    public void QuitGame(){
        Application.Quit();
    }
    
    public void ShowCursor(){
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void SetSelectedButton(GameObject btn){
        eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
    }

    public void SetPlayersButton(){
        if(PlayerManagerSingleton.Instance.playerCount == 2){
            eventSystem.SetSelectedGameObject(p2, new BaseEventData(eventSystem));
        }
        if(PlayerManagerSingleton.Instance.playerCount == 3){
            eventSystem.SetSelectedGameObject(p3, new BaseEventData(eventSystem));
        }
        if(PlayerManagerSingleton.Instance.playerCount == 4){
            eventSystem.SetSelectedGameObject(p4, new BaseEventData(eventSystem));
        }
    }
    
    public void PlayMainTheme(){
        if(_mainThemeAudio != null){
            AudioManagerSingleton.Instance.PlaySong(_mainThemeAudio);
        }
    }

    public void HideCharacterButtons(){
        for(int i = 0; i < 4; i++){
            selectors[i].transform.position = selectorHider.transform.position; 
        }
    }

    public void SetCharacterButton(){
        if(PlayerManagerSingleton.Instance.playerSelecting < PlayerManagerSingleton.Instance.playerCount){
            SetSelectedButton(c1);
        }
    }

    

    public void OnSelect(BaseEventData eventData)
    {
        //MoveCharacterSelector()
         Debug.Log(this.gameObject.name + " was selected");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerSingleton : MonoBehaviour
{
    public static PlayerManagerSingleton Instance = null;
    public int playerCount;
    public int playerSelecting;
    public Character[] playerCharacters;
    public Character[] charactersIndex;
    public string sceneName;
        
    SceneLoader sceneloader;
    MainMenuController mainmenucontroller;
    
    // Start is called before the first frame update
    private void Awake(){
        
        #region Singleton Pattern (Simple)
        
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        #endregion

        sceneloader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        mainmenucontroller = GameObject.Find("MainMenuController").GetComponent<MainMenuController>();
    }

    public void Set2Player(){
        if(playerCount != 2){
            if(mainmenucontroller != null){
               mainmenucontroller.HideCharacterButtons();
           }
            ResetPlayerSelection();
            playerCount = 2;
            playerCharacters = new Character[2];
        }
   }

   public void Set3Player(){
       if(playerCount != 3){
           if(mainmenucontroller != null){
               mainmenucontroller.HideCharacterButtons();
           }
            ResetPlayerSelection();
            playerCount = 3;
            playerCharacters = new Character[3];
       }
   }
    
    public void Set4Player(){
        if(playerCount != 4){
            if(mainmenucontroller != null){
               mainmenucontroller.HideCharacterButtons();
           }
            ResetPlayerSelection();
            playerCount = 4;
            playerCharacters = new Character[4];
        }
   }

   public void ResetPlayerSelection(){
       playerSelecting = 0;
       for(int i = 0; i > playerCharacters.Length; i++){
           playerCharacters[i] = null;
       }
   }
    
    public void SelectCharacter(int index){
        playerSelecting++;
        if(playerSelecting <= playerCount){
            playerCharacters[playerSelecting-1] = charactersIndex[index-1];   
        }
        if(playerSelecting == playerCount && sceneloader != null){
             sceneloader.LoadScene(sceneName);
             }
    }
}

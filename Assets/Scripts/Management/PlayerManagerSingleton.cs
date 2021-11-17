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

        
    SceneLoader sceneloader;
    
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
    }

    public void Set2Player(){
        playerCount = 2;
        playerCharacters = new Character[2];
   }

   public void Set3Player(){
        playerCount = 3;
        playerCharacters = new Character[3];
   }
    
    public void Set4Player(){
        playerCount = 4;
        playerCharacters = new Character[4];
   }
    
    public void SelectCharacter(int index){
        playerSelecting++;
        if(playerSelecting <= playerCount){
            playerCharacters[playerSelecting-1] = charactersIndex[index-1];   
        }
        if(playerSelecting == playerCount && sceneloader != null){
             sceneloader.LoadScene("Prototype");
             }
    }
}

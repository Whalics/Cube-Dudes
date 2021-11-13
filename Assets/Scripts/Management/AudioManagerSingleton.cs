using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManagerSingleton : MonoBehaviour
{
    public static AudioManagerSingleton Instance = null;
    AudioSource _audioSource;

    private void Awake(){
        
        #region Singleton Pattern (Simple)
        
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else{
            Destroy(gameObject);
        }

        #endregion
    }

    public void PlaySong(AudioClip clip){
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PauseSong(){
        _audioSource.Pause();
    }
    
    public void ResumeSong(){
        _audioSource.Play();
    }
}

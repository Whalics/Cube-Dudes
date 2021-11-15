using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerController : MonoBehaviour
{
    public float maxTime;
    public float timer;
    public TMP_Text timerText;
    public bool pausetimer;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = maxTime;
        timerText.text = "Time:" + timer;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pausetimer && !gamemanager.GetControls())
            DecreaseTime();
    }

    public void DecreaseTime(){
        timer-=Time.deltaTime;
        if(Mathf.Round(timer) < 0)
        timer = 60;
        SetTimer();
        if(GetTurnTimer() <= 0){
            gamemanager.EndTurn();
        }
    }

    public void ResetTimer(){
         timer = 60;
         pausetimer = false;
         SetTimer();
    }

    public void PauseTimer(){
        pausetimer = true;
    }

    public void ResumeTimer(){
        pausetimer = false;
    }

    public float GetTurnTimer(){
        return Mathf.Round(timer);
    }

    public void SetTimer(){
        if(Mathf.Round(timer) < 10){
            timerText.text = "00:0" + Mathf.Round(timer);
        }
        else if(Mathf.Round(timer) < 60){
            timerText.text = "00:" + Mathf.Round(timer);
        }
        else if(Mathf.Round(timer) >= 60){
            timerText.text = "1:00";
        }
    }
}

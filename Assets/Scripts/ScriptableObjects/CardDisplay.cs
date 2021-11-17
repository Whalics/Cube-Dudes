using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    public Card card;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image cardImage;

    // void Start(){
    //     UpdateInfo();
    // }

    // void OnEnable(){
    //     UpdateInfo();
    // }

    public void UpdateInfo(){
        descriptionText.text = card.description;
        cardImage.sprite = card.artwork;
    }
}

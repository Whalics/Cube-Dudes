using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNavigation : MonoBehaviour
{
    public Navigation navigation;
    public Button cardButton;

    // void SetNavigation(GameObject[] deck){
    //     for(int i = 0; i < 5; i++){
    //         navigation = deck[i].GetComponentInChildren<Button>().navigation;
    //         if(i < 4)
    //         navigation.selectOnRight = deck[i+1].GetComponentInChildren<Button>();
    //         if(i > 1)
    //         navigation.selectOnLeft = deck[i-1].GetComponentInChildren<Button>();

    //     }
    // }
}

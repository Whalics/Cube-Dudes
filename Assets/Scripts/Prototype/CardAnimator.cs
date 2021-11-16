using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardAnimator : MonoBehaviour
{
    [SerializeField] Animator cardAnimator;

    public void OnSelect(BaseEventData eventData)
    {
        cardAnimator.Play("In_TEMP");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        cardAnimator.Play("Out_TEMP");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickUI : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] PlayerController player;

    public void OnPointerClick(PointerEventData eventData)
    {
        player.Jump();
    }
}

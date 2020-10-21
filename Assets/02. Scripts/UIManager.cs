using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    public void StartButton()
    {
        startUI.SetActive(false);
    }
}

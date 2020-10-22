using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startUI;

    [SerializeField] Text currentScoreText;

    public void StartButton()
    {
        startUI.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void ScoreTextUpdate(int score)
    {
        currentScoreText.text = score.ToString();
    }
}

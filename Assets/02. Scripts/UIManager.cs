using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameOverUI;

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

    public void GameOverUIActive(bool isTrue)
    {
        if (isTrue)
            gameOverUI.SetActive(true);
        else // 다시 실행 눌렀을 때
        {
            gameOverUI.SetActive(false);
            GameManager.instance.ResetGame();
        }
    }
}

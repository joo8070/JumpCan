using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        GAMEREADY,
        GAMESTART,
        GAMEOVER,
    }
    GameState currentState;                 // 현재 게임 상태
    public GameState CurrentState { get { return currentState; } set { currentState = value; } }
    [SerializeField] GameObject blockPrefab;
    
    [SerializeField] Transform startPos;
    [SerializeField] UIManager uiManager;
    public static GameManager instance;     // 싱글톤

    int score = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        currentState = GameState.GAMEREADY;
    }

    public void StartGame()
    {
        currentState = GameState.GAMESTART;
        StartCoroutine(CreateBlock());
    }

    IEnumerator CreateBlock()
    {
        float gap = 0.25f;
        bool isLeft = false;
        while(currentState != GameState.GAMEOVER)
        {
            GameObject go = Instantiate(blockPrefab,
                new Vector3((isLeft == true ? startPos.transform.position.x - 2.5f : startPos.transform.position.x + 2.5f)
                            ,startPos.transform.position.y + gap
                            ,startPos.transform.position.z), Quaternion.identity);
            gap += 0.25f;
            isLeft = !isLeft;
            go.transform.parent = transform;
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void ScoreUp()
    {
        score++;
        uiManager.ScoreTextUpdate(score);
    }
}

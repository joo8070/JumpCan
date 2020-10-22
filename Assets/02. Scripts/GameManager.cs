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

    PlayerController player;
    GameState currentState;                 // 현재 게임 상태
    public GameState CurrentState { get { return currentState; } set { currentState = value; } }
    [SerializeField] GameObject blockPrefab;
    
    [SerializeField] Transform startPos;
    [SerializeField] UIManager uiManager;
    public static GameManager instance;     // 싱글톤

    int score = 0;

    List<GameObject> blocks = new List<GameObject>(); //블록 관리

    void Awake()
    {
        if (instance == null) instance = this;
        currentState = GameState.GAMEREADY;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
            blocks.Add(go);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void ScoreUp()
    {
        score++;
        uiManager.ScoreTextUpdate(score);
    }

    public void GameOver()
    {
        currentState = GameState.GAMEOVER;
        StopAllCoroutines();
        uiManager.GameOverUIActive(true);
    }

    public void ResetGame()
    {
        for(int i = 0; i < blocks.Count; ++i)
        {
            if (blocks[i] != null) Destroy(blocks[i]);
        }
        blocks.Clear();
        score = 0;
        player.resetPos();

        StartGame(); // 다시시작
    }
}

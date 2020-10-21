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


    public static GameManager instance;     // 싱글톤

    void Awake()
    {
        if (instance == null) instance = this;
        currentState = GameState.GAMEREADY;
    }

    public void StartGame()
    {
        currentState = GameState.GAMESTART;

    }

}

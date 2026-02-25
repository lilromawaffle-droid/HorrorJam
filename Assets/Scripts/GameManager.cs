using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("")]
    public static GameManager Instance;


    public GameState gameState;
    public static event Action <GameState> onGameStateChange; 

    void Awake()
    {
        Instance = this;
        gameState = GameState.MAIN_MENU;
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case(GameState.MAIN_MENU):
                break;
            case(GameState.MENU):
                break;
            case(GameState.WIN):
                break;
            case(GameState.LOSE):
                break;
            case(GameState.OPEN_CAMERA):
                break;
            case(GameState.CAMERA):
                break;
            case(GameState.OPEN_NORMAL):
                break;
            case(GameState.NORMAL):
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
            
            
        }
        onGameStateChange?.Invoke(newState);//ngasih tau oge nu nyala na naon
    }

}

    public enum GameState
    {
        MAIN_MENU,
        MENU,
        WIN,
        LOSE,
        OPEN_CAMERA,
        CAMERA,
        OPEN_NORMAL,
        NORMAL
    }
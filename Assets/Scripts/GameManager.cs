using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //event
    public event Action<int> onCompleteStage;

    //inisialisasi
    [Header("KillCount")]
    [SerializeField] public int enemyDeathCounter;
    [SerializeField] public int maxEnemyDeathCounter;

    //state
    public GameState gameState;
    public StagesState currentStage;
    public StagesState previousStage;

    
    //flag

    void Awake()
    {
        instance = this;
        gameState = GameState.MAIN_MENU;
        currentStage = StagesState.Tutorial;
    }

    void Update()
    {
        
        //mastiin cuma di run sekali
        if (currentStage != previousStage)
        {
            previousStage = currentStage;
            OnChangeState(currentStage);
        }

        if (enemyDeathCounter >= maxEnemyDeathCounter)
        {
            currentStage = StagesState.Stage1;
        }
    }


    void OnChangeState(StagesState newState)
    {
        switch (newState)
        {
            case StagesState.Loby:
                break;
            case StagesState.Tutorial:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter =1; 
                onCompleteStage?.Invoke(0);
                break;
            case StagesState.Stage1:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter =2;
                onCompleteStage?.Invoke(1);
                break;
            
        }
    }

    void OnUpdateState()
    {
        
    }



}
    public enum StagesState
{
    Loby,
    Tutorial,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5
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
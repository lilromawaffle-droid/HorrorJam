using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

#region inisialisasi


    public static GameManager instance;

    //event
    public event Action<int> onCompleteStage;
    public event Action<int> onCompleteGame;

    //inisialisasi
    [Header("KillCount")]
    [SerializeField] public int enemyDeathCounter;
    [SerializeField] public int maxEnemyDeathCounter;

    //state
    public GameState gameState;
    public StagesState currentStage;
    public StagesState previousStage;
#endregion
    
#region eksekusi

    void Awake()
    {
        instance = this;
        gameState = GameState.MAIN_MENU;
        currentStage = StagesState.Loby;
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
            NextStages();
        }
    }
#endregion

#region Changing State
    void OnChangeState(StagesState newState)
    {
        switch (newState)
        {
            case StagesState.Loby:
                break;
            case StagesState.Tutorial:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter =5; 
                onCompleteStage?.Invoke(0);
                break;
            case StagesState.Stage1:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter =2;
                onCompleteStage?.Invoke(1);
                break;
            case StagesState.Stage2:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 3;
                onCompleteStage?.Invoke(2);
                break;

            case StagesState.Stage3:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 4;
                onCompleteStage?.Invoke(3);
                break;

            case StagesState.Stage4:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 5;
                onCompleteStage?.Invoke(4);
                break;

            case StagesState.Stage5:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 15; 
                onCompleteStage?.Invoke(5);
                Debug.Log("End");
                break;
            default:
                onCompleteGame?.Invoke(0);
                break;
        }
    }

    void OnUpdateState()
    {
        
    }

    void NextStages()
    {
        StagesState[] stagesInt = (StagesState[])System.Enum.GetValues(typeof(StagesState));
        int currentIndex = System.Array.IndexOf(stagesInt, currentStage);

        if (currentIndex < stagesInt.Length - 1)
        {
            currentStage = stagesInt[currentIndex + 1]; 
            Debug.Log("Stage berubah ke: " + currentStage);
        }
    }
#endregion

#region function
    void AddKillCount()
    {
        
    }
#endregion
}



#region  State
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
    NORMAL
}
#endregion
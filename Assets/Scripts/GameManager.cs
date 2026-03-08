using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

#region inisialisasi


    public static GameManager instance;

    //event
    public event Action<int> onCompleteStage;
    public event Action<int> onCompleteGame;
    public event Action<int> onCompleteStageMaxKillCount;

    //inisialisasi
    [Header("KillCount")]
    [SerializeField] public int enemyDeathCounter;
    [SerializeField] public int maxEnemyDeathCounter;
    [SerializeField] private TextMeshProUGUI killCountText;

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
        killCountText.text=enemyDeathCounter+"/"+maxEnemyDeathCounter;
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
                maxEnemyDeathCounter =82;
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(0);
                onCompleteStageMaxKillCount?.Invoke(82);
                break;
            case StagesState.Stage1:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter =5;
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(1);
                onCompleteStageMaxKillCount?.Invoke(5);
                break;
            case StagesState.Stage2:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 8;
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(2);
                onCompleteStageMaxKillCount?.Invoke(8);
                break;

            case StagesState.Stage3:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 10;
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(3);
                onCompleteStageMaxKillCount?.Invoke(10);
                break;

            case StagesState.Stage4:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 12;
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(4);
                onCompleteStageMaxKillCount?.Invoke(12);
                break;

            case StagesState.Stage5:
                enemyDeathCounter = 0;
                maxEnemyDeathCounter = 100; 
                PlayerStateMachine.instance.PlusBattery(5);
                onCompleteStage?.Invoke(5);
                onCompleteStageMaxKillCount?.Invoke(100);
                Debug.Log("End");
                break;
            default:
                onCompleteGame?.Invoke(0);
                break;
        }
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
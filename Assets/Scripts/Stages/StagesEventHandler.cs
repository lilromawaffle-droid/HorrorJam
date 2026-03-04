using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesEventHandler : MonoBehaviour
{
    public List<GameObject> stageGameObject = new List<GameObject>();

    void Start()
    {
        GameManager.instance.onCompleteStage += spawnStage;
        // simple hela
        // stageGameObject[0].SetActive(false);
        // stageGameObject[1].SetActive(false);
        // stageGameObject[2].SetActive(false);
    }
    void OnDestroy()
    {
        GameManager.instance.onCompleteStage -= spawnStage;
    }

    void spawnStage(int importValue)
    {
        SceneManager.LoadScene(importValue);
        // stageGameObject[importValue].SetActive(true);
        // Destroy(stageGameObject[importValue-1]);    
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesEventHandler : MonoBehaviour
{
    List<GameObject> stageGameObject = new List<GameObject>();

    void Start()
    {
        GameManager.instance.onCompleteStage += spawnStage;
         stageGameObject[1].SetActive(false);
         stageGameObject[2].SetActive(false);
         stageGameObject[3].SetActive(false);
         stageGameObject[4].SetActive(false);
         stageGameObject[5].SetActive(false);
    }
    void OnDestroy()
    {
        GameManager.instance.onCompleteStage -= spawnStage;
    }

    void spawnStage(int importValue)
    {
        stageGameObject[importValue].SetActive(true);
        Destroy(stageGameObject[importValue-1]);
    }
}

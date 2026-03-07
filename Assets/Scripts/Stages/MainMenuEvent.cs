using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    [SerializeField] private GameObject i;
    public void OnClickStart()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickResume(string lastScene)
    {
        SceneManager.LoadScene(lastScene);
    }
    public void OnClickSettings()
    {
        
    }

}

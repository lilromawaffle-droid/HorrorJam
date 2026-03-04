using UnityEngine;

public class DontDestroyOnlLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}

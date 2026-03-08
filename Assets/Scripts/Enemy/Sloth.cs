using UnityEngine;

public class Sloth : MonoBehaviour
{
    [SerializeField] float slowMultiplier = 0.5f;
    bool isDebuff;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isDebuff)
        {
            PlayerStateMachine.instance.EnterSlow(slowMultiplier);
            isDebuff = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStateMachine.instance.ExitSlow();
            isDebuff = false;
        }
    }
}
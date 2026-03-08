using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] float damagePerTick ;
    [SerializeField] float interval ; // tiap berapa detik

    private Coroutine damageCoroutine;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Mulai damage
            damageCoroutine = StartCoroutine(DamageOverTime());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Stop damage saat keluar
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator DamageOverTime()
    {
        while (true)
        {
            PlayerStateMachine.instance.TakeDamage(damagePerTick);
            yield return new WaitForSeconds(interval);
        }
    }
}
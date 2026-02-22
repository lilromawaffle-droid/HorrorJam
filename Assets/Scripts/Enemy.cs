using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Health;

    public void Damage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

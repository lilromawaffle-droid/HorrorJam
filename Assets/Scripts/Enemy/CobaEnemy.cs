using UnityEngine;

public class CobaEnemy : MonoBehaviour
{
    [SerializeField]float Hp;
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if(Hp<=0)
        {
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class DamagebleObject : MonoBehaviour
{
    [SerializeField] int damage;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStatus.instance.TakeDamage(damage);
        }
    }
}

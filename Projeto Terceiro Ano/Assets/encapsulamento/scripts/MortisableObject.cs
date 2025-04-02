using UnityEngine;

public class MortisableObject : MonoBehaviour
{
    [SerializeField] int damage;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStatus.instance.TakeDamage(damage);
            HUD.instance.SetLife();
        }
    }
}

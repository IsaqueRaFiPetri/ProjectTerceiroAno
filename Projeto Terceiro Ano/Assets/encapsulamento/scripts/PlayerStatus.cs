using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField]
    int life;

    [SerializeField]
    int mana;

    private void Awake()
    {
        instance = this;
    }

    public int GetLife()
    {
        return life;
    }

    public int GetMana()
    {
        return mana;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }
}

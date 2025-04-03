using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField]
    int maxMana, maxLife;

    int mana, life;

    public int Mana { get => mana; }
    public int Life { get => life; }
    public int MaxMana { get => maxMana; }
    public int MaxLife { get => maxLife; }

    private void Awake()
    {
        instance = this;
        life = maxLife;
        mana = maxMana;
    }
    
    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    public void LoseMana(int cost)
    {
        mana -= cost;
    }
}

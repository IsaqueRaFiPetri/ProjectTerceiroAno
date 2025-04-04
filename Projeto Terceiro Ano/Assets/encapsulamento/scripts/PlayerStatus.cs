using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField]
    int maxMana, maxLife;

    int mana, life;

    public int Mana { get => mana; set => mana = value; }
    public int Life { get => life; set => life = value; }
    public int MaxMana { get => maxMana; }
    public int MaxLife { get => maxLife; }

    private void Awake()
    {
        instance = this;
        life = maxLife;
        Mana = maxMana;
    }
    
    public void TakeDamage(int damage)
    {
        Life -= damage;
    }

    public void LoseMana(int cost)
    {
        Mana -= cost;
    }
}

using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;

    [SerializeField]
    public int maxMana, maxLife;

    [HideInInspector]
    public int mana, life;

    

    private void Awake()
    {
        instance = this;
        life = maxLife;
        mana = maxMana;
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

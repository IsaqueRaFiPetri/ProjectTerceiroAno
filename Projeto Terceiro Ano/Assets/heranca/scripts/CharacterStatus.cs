using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    int mana, life;

    public int Mana { get => mana; set => mana = value; }
    public int Life { get => life; set => life = value; }

    [SerializeField]
    int maxMana, maxLife;
    public int MaxMana { get => maxMana; }
    public int MaxLife { get => maxLife; }

    [SerializeField] Image hpBar, manaBar;

    private void Awake()
    {
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

    public void SetLife()
    {
        hpBar.fillAmount = (float)Life / MaxLife;
    }
    public void SetMana()
    {
        manaBar.fillAmount = (float)Mana / MaxMana;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Image hpBar, manaBar;
    public static HUD instance;

    void Start()
    {
        instance = this;
        SetLife();
    }

    public void SetLife()
    {
        hpBar.fillAmount = (float)PlayerStatus.instance.life / PlayerStatus.instance.maxLife;
    }
    public void SetMana()
    {
        manaBar.fillAmount = (float)PlayerStatus.instance.mana / PlayerStatus.instance.maxMana;
    }
}

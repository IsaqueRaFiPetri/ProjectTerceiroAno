using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Image hpBar, manaBar;
    public static HUD instance;

    void Start()
    {
        instance = this;
        /*SetLife();
        SetMana();*/
    }

    /*public void SetLife()
    {
        hpBar.fillAmount = (float)PlayerStatus.instance.Life / PlayerStatus.instance.MaxLife;
    }
    public void SetMana()
    {
        manaBar.fillAmount = (float)PlayerStatus.instance.Mana / PlayerStatus.instance.MaxMana;
    }*/
}

using UnityEngine;

public class ManaRegen : MonoBehaviour
{
    [SerializeField] int regenRate; 
    [SerializeField] float regenInterval;

    float regenTimer;

    void Update()
    {
        if(PlayerStatus.instance.Mana < PlayerStatus.instance.MaxMana)
        {
            regenTimer += Time.deltaTime;

            if (regenTimer >= regenInterval)
            {
                Regenerate(regenRate);
                regenTimer = 0f;
            }
        }

        HUD.instance.SetMana();
    }

    void Regenerate(int regenGain)
    {
        PlayerStatus.instance.Mana = Mathf.Min(PlayerStatus.instance.Mana + regenRate, PlayerStatus.instance.MaxMana); //to make Mana be able to read in the first part of the code, it need to have a set.
        regenTimer = 0f;
    }
}

using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    int life;

    [SerializeField] int maxLife;

    public int Life { get => life; set => life = value; }
    public int MaxLife { get => maxLife; }

    private void Awake()
    {
        life = MaxLife;
    }

    public void TakeDamage(int damage)
    {
        Life -= damage;
    }
}

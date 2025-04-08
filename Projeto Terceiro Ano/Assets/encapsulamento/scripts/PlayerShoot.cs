using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float launchVelocity, frontForce;

    [SerializeField]
    int manaCost;

    private void Update()
    {
        /*if (PlayerStatus.instance.Mana >= manaCost)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, frontForce));

                PlayerStatus.instance.LoseMana(manaCost);
                HUD.instance.SetMana();
            }
        }*/
        
    }
}
//https://learn.unity.com/tutorial/using-c-to-launch-projectiles#5fd7ab3bedbc2a7fb11f4e41
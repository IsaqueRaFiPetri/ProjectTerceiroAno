using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float launchVelocity;

    bool readyToShoot;

    [SerializeField]
    int manaCost;

    private void Awake()
    {
        readyToShoot = true;
    }

    private void Update()
    {
        if (PlayerStatus.instance.Mana >= manaCost)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));

                readyToShoot = false;

                PlayerStatus.instance.LoseMana(manaCost);
                Debug.Log(PlayerStatus.instance.Mana);
            }
        }
        
    }
}
//https://learn.unity.com/tutorial/using-c-to-launch-projectiles#5fd7ab3bedbc2a7fb11f4e41
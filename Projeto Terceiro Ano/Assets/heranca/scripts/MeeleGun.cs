using UnityEngine;

public class MeeleGun : GunSystem
{
    [SerializeField] string nameGun;

    private void Update()
    {
        MyInput();
    }

    public override void Shoot()
    {
        readyToShoot = false;

        //RayCast
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                print("acertou");
                rayHit.collider.GetComponent<EnemyStatus>().TakeDamage(damage);
            }
        }
        Invoke("ResetShoot", timeBetweenShooting);
    }
    public override void MyInput()
    {
        if (allowButtonHolds)
        {
            shooting = Input.GetButton("Fire1");
        }
        else
        {
            shooting = Input.GetButtonDown("Fire1");
        }
        
        //SetText
        text.SetText(nameGun);

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
}

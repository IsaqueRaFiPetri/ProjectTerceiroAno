using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
#region variaveis
    [Header("Gun Stats")]
    [SerializeField] protected int damage, magazineSize, bulletsPerTap;
    [SerializeField]  protected float timeBetweenShooting, range, reloadTime, timeBetweenShots;
    protected int bulletsLeft, bulletsShot;

    [Header("Bools")]
    protected bool shooting, readyToShoot, reloading;
    [SerializeField] protected bool allowButtonHolds;

    //References
    protected Camera cam;
    [SerializeField] Transform attackPoint;
    protected RaycastHit rayHit;
    //protected LayerMask whatIsEnemy;

    [SerializeField] protected TextMeshProUGUI text;

    [Header("UI / UX")]
    [SerializeField] GameObject reloadingPainel;
    #endregion variaveis

    private void Awake()
    {
        cam = GetComponentInParent<Camera>();

        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        if (reloading == true)
        {
            reloadingPainel.SetActive(true);
        }
        else
        {
            reloadingPainel.SetActive(false);
        }

        Debug.DrawRay(attackPoint.position, cam.transform.forward * range, Color.red, 1f);

    }
    public virtual void MyInput()
    {
        if (allowButtonHolds)
        {
            shooting = Input.GetButton("Fire1");
        }
        else
        {
            shooting = Input.GetButtonDown("Fire1");
        }
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    public virtual void Shoot()
    {
        readyToShoot = false;

        if (Physics.Raycast(attackPoint.position, cam.transform.forward, out rayHit, range))
        {
            Debug.Log("ACERTOU: " + rayHit.collider.name);

            EnemyStatus enemy = rayHit.collider.GetComponentInParent<EnemyStatus>();

            if (enemy != null)
            {
                Debug.Log("EnemyStatus founded! Dealing damage...");
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("EnemyStatus not found in enemy!");
            }
        }

        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShoot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("ResetShoot", timeBetweenShooting);
        }
    }
    private void ResetShoot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
//https://www.youtube.com/watch?v=bqNW08Tac0Y
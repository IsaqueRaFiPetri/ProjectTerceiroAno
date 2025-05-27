using Photon.Pun;
using UnityEngine;

public class Gun : MonoBehaviour
{
    IShootable target;
    [SerializeField] Transform origin;
    PhotonView phView;

    void Start()
    {
        phView = GetComponentInParent<PhotonView>();

        if (!phView.IsMine)
            this.enabled = false;
    }

    void Update()
    {
        if(Physics.Raycast(origin.position, origin.forward, out RaycastHit hit, 10))
        {
            if(hit.collider.TryGetComponent(out IShootable target))
            {
                this.target = target;
            }
            else
            {
                this.target = null;
            }
        }
        else
        {
            this.target = null;
        }
    }

    public void OnShoot()
    {
        target?.Hit(phView.ViewID);
    }
}

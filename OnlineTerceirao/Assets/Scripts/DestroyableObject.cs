using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class DestroyableObject : MonoBehaviour, IShootable
{
    PhotonView phView;

    void Start()
    {
        phView = GetComponent<PhotonView>();
    }

    public void Hit(int id)
    {
        phView.RPC("RPC_Hit", RpcTarget.AllBuffered, id);
    }

    [PunRPC]
    public void RPC_Hit(int id)
    {
        PhotonNetwork.GetPhotonView(id).GetComponentInChildren<MeshRenderer>().enabled = false;
        gameObject.SetActive(false);
    }
}

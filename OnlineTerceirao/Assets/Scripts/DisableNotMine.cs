using UnityEngine;
using Photon.Pun;

public class DisableNotMine : MonoBehaviour
{
    PhotonView phView;
    void Start()
    {
        phView = GetComponent<PhotonView>();
        if (!phView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
}

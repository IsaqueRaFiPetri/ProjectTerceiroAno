using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        PhotonNetwork.Instantiate(player.name, transform.position, player.transform.rotation);
    }
}

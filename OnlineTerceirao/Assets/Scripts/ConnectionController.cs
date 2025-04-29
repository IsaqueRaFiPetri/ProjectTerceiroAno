using UnityEngine;
using Photon.Pun;

public class ConnectionController : MonoBehaviourPunCallbacks //tudo visto na aula do professor alexandre
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        print("Connected to the Internet!");
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to Photon's Server.");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("Connected to the Lobby!");

        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    public override void OnJoinedRoom()
    {
        print("Acess the Room.");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Fail to join random room!");
    }

    public override void OnCreatedRoom()
    {
        print("room created!");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Failed to join room.");
    }
}
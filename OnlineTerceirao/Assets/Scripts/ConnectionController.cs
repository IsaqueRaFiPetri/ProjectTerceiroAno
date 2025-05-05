using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionController : MonoBehaviourPunCallbacks //tudo visto em aula do professor alexandre
{
    void Start()
    {
        //aciona a conexao
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnected()
    {
        print("Connected to the Internet!");
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to Photon's Server.");
        PhotonNetwork.JoinRandomOrCreateRoom();
        //PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        print("Connected to the Lobby!");

        //PhotonNetwork.JoinRandomOrCreateRoom();
        PhotonNetwork.JoinRoom("terceirao");
    }
    public override void OnJoinedRoom()
    {
        print("Acess the Room.");
        PhotonNetwork.LoadLevel("Playground");
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

        RoomOptions roomOpt = new RoomOptions();
        roomOpt.IsOpen = true; //Esse é padrão
        roomOpt.IsVisible = true; //Esse é padrão
        roomOpt.MaxPlayers = 30; 
        roomOpt.PlayerTtl = 0; //Esse é padrão
        roomOpt.EmptyRoomTtl = 0; //Esse é padrão

        PhotonNetwork.CreateRoom("Room" + Random.Range(0, 100) + Random.Range(0, 100));
    }
}
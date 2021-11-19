using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private NetworkPlayerSpawner networkPlayerSpawner;
    void Start()
    {
        networkPlayerSpawner = this.GetComponent<NetworkPlayerSpawner>();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MenuRoomSelect");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby, waiting for input...");

        //incase username is not applied set guest name.
        PhotonNetwork.NickName = "Guest " + Random.Range(0, 1000).ToString("0000");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined" + PhotonNetwork.CurrentRoom);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("Player joined with nickname: " + newPlayer.NickName);
    }
}

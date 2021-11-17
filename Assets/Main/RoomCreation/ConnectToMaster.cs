using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToMaster : MonoBehaviourPunCallbacks
{
    void Start()
    {
        ConnectToserver();
    }

    void ConnectToserver()
    {
        Debug.Log("Connecting to server...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Sucessfully connected to server");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }
}

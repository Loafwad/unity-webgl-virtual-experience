using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonCreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView playerPV;
    [SerializeField] private string roomName;
    [SerializeField] private string sceneName;
    public void OnClickCreateRoom(Level_Info level)
    {

        roomName = level.roomName;
        sceneName = level.sceneName;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 25;
        PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined" + PhotonNetwork.CurrentRoom);
        PhotonNetwork.LoadLevel(sceneName);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("created room with name: " + roomName);
    }
}

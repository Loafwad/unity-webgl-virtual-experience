using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    [SerializeField] private NetworkManager networkManager;

    public GameObject characterConnectMenu;
    public GameObject chatMenu;

    public void Start()
    {
        characterConnectMenu.SetActive(true);
        /*  SpawnPlayer(); */
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        characterConnectMenu.SetActive(true);
    }

    public void SpawnPlayer()
    {
        chatMenu.SetActive(true);
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);

        spawnedPlayerPrefab.GetComponent<EnableCamOnAwake>().EnableCam();
        characterConnectMenu.SetActive(false);
        /* UpdatePlayersVisible(); */
        spawnedPlayerPrefab.GetComponent<PhotonView>().RPC("UpdatePlayersVisible", RpcTarget.All);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }





}

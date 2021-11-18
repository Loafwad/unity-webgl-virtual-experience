using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using UnityEngine.InputSystem;

public class DestroyRemoteComponents : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            photonView.gameObject.SetActive(false);
        }
    }

    public void StartEnablingPlayers()
    {
        Debug.Log("called this motherc");
        photonView.gameObject.SetActive(true);
        StartCoroutine(En());
    }

    private IEnumerator En()
    {
        yield return new WaitForSeconds(1f);
        photonView.gameObject.SetActive(true);
    }

    [PunRPC]
    public void UpdatePlayersVisible()
    {
        DestroyRemoteComponents[] allPlayers = GameObject.FindObjectsOfType<DestroyRemoteComponents>();
        foreach (DestroyRemoteComponents destroyRemoteComponents in allPlayers)
        {
            destroyRemoteComponents.StartEnablingPlayers();
        }
    }
}

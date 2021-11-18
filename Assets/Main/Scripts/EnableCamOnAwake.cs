using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class EnableCamOnAwake : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] CinemachineVirtualCamera cm;

    public void EnableCam()
    {
        if (photonView.IsMine)
        {
            cm.enabled = true;
            cm.Priority = cm.Priority - PhotonNetwork.PlayerList.Length;
        }
        else
        {
            Debug.LogWarning("Tried to acess cam is not owned by client");
        }
    }
}

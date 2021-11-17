using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class SetNickname : MonoBehaviourPun
{
    // Start is called before the first frame update

    [SerializeField] private PhotonView playerPV;
    [SerializeField] private TMP_Text text;
    public void Start()
    {
        text.text = playerPV.Owner.NickName;
    }
}

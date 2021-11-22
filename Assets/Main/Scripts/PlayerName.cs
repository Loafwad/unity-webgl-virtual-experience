using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerName : MonoBehaviourPun
{
    public TMP_InputField nameInputField;
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            nameInputField.text = PlayerPrefs.GetString("PlayerName");
            return;
        }
        else
        {
            string PlayerName = PlayerPrefs.GetString("PlayerName");
            nameInputField.text = PlayerName;
        }
    }

    public void PlacePlayerName()
    {
        string PlayerNickname = nameInputField.text;
        PhotonNetwork.NickName = PlayerNickname;
        PlayerPrefs.SetString("PlayerName", PlayerNickname);
    }
}

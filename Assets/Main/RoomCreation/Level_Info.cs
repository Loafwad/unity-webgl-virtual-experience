using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class Level_Info : MonoBehaviourPunCallbacks
{
    public string roomName;
    public string sceneName;
    public int playerCount;

    [SerializeField] TMP_Text playerCountText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Button createRoomButton;
    [SerializeField] Button joinRoomButton;

    [Header("Hello")]
    [SerializeField] TMP_Text plc_1;
    [SerializeField] TMP_Text plc_2;
    [SerializeField] TMP_Text plc_3;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var entry in roomList)
        {
            if (roomName == entry.Name)
            {
                Debug.Log(entry.Name + entry.PlayerCount);
                playerCount = entry.PlayerCount;
                UpdatePlayerCount(entry.PlayerCount);
                if (playerCount > 0)
                {
                    UpdateRoomName(entry.Name);
                    RoomAlreadyExists();
                }
                else
                {
                    joinRoomButton.gameObject.SetActive(false);
                    createRoomButton.gameObject.SetActive(true);
                    string hexString = "#B0B0B0";
                    Color grayColor = new Color();
                    ColorUtility.TryParseHtmlString(hexString, out grayColor);
                    Debug.Log("color: " + grayColor);
                    plc_1.color = grayColor;
                    plc_2.color = grayColor;
                    plc_3.color = grayColor;
                    roomNameText.gameObject.SetActive(false);
                }
            }
        }
    }
    private void RoomAlreadyExists()
    {
        joinRoomButton.gameObject.SetActive(true);
        createRoomButton.gameObject.SetActive(false);

    }
    private void UpdateRoomName(string name)
    {
        roomName = name;
        roomNameText.text = roomName;
        roomNameText.color = Color.white;
    }
    private void UpdatePlayerCount(int count)
    {
        plc_1.color = Color.white;
        plc_2.color = Color.white;
        plc_3.color = Color.white;
        playerCount = count;
        playerCountText.text = playerCount.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class ChatManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView playerPV;

    private Button sendChatMessageButton;
    public TMP_Text updatedText;
    public TMP_InputField chatInputField;

    private void Awake()
    {
        chatInputField = GameObject.Find("Canvas").GetComponent<LateReference>().chatInputField;

        updatedText = GameObject.Find("Canvas").GetComponent<LateReference>().updatedText;

        sendChatMessageButton = GameObject.Find("Canvas").GetComponent<LateReference>().sendChatMessageButton;
    }

    private void Start()
    {
        sendChatMessageButton.onClick.AddListener(OnClickSendMessage);
    }

    public void OnClickSendMessage()
    {
        if (chatInputField.text != "" && chatInputField.text.Length >= 1)
        {
            playerPV.RPC("SendMessage", RpcTarget.AllBuffered, chatInputField.text);

            chatInputField.text = "";
        }
    }

    private void Update()
    {
        if (playerPV.IsMine)
        {
            if (chatInputField.isFocused)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    OnClickSendMessage();
                }
            }
        }
    }

    [PunRPC]
    private void SendMessage(string message)
    {
        updatedText.text = message;

        GameObject newTextElement = Instantiate(updatedText.gameObject);
        newTextElement.transform.SetParent(updatedText.transform.parent);
        newTextElement.SetActive(true);
        newTextElement.GetComponent<TMP_Text>().text = playerPV.Owner.NickName + ": " + updatedText.text;
    }
}
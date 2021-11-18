using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class LateReference : MonoBehaviour
{
    [SerializeField] public Slider lookSensitivity;
    [SerializeField] public Slider cameraFOV;

    [SerializeField] public TMP_Text updatedText;
    [SerializeField] public TMP_InputField chatInputField;

    [SerializeField] public Button sendChatMessageButton;

}

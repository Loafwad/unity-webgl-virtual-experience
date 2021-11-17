using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SetLookSensitivity : MonoBehaviour
{
    private Slider lookSensitivity;
    private Slider cameraFOV;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private StarterAssets.FirstPersonController fpc;
    // Start is called before the first frame update
    void Start()
    {
        cameraFOV = GameObject.Find("Canvas").GetComponent<LateReference>().cameraFOV;

        lookSensitivity = GameObject.Find("Canvas").GetComponent<LateReference>().lookSensitivity.GetComponent<Slider>();
    }

    void Update()
    {
        fpc.RotationSpeed = lookSensitivity.value;
        virtualCamera.m_Lens.FieldOfView = cameraFOV.value * 100;
    }
}

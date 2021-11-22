using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverlayHover : MonoBehaviour
{
    [SerializeField] private GameObject overlay;
    private bool isHovering;
    void OnMouseOver()
    {
        isHovering = true;
    }
    void OnMouseExit()
    {
        isHovering = false;
    }

    void Update()
    {
        if (isHovering)
        {
            if (Input.GetMouseButton(1))
            {
                overlay.SetActive(true);
            }
            else
            {
                overlay.SetActive(false);
            }
        }
    }
}

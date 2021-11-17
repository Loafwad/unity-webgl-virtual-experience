using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InspectMenu : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject inspectMenu;

    bool isHovering;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }

    void Update()
    {
        if (isHovering)
        {
            if (Input.GetMouseButton(1))
            {
                inspectMenu.SetActive(true);
            }
            else
            {
                inspectMenu.SetActive(false);
            }
        }
    }
}

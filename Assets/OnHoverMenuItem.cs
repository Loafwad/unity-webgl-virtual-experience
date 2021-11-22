using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject hoverMenu;

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
            hoverMenu.SetActive(true);
        }
        else
        {
            hoverMenu.SetActive(false);
        }
    }
}

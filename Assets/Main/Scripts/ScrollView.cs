using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollView : MonoBehaviour
{
    [SerializeField] float currentScale;
    [SerializeField] float maxScale;
    [SerializeField] float minScale;
    [SerializeField] private GameObject imageToZoom;
    void Update()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment)
    {
        currentScale += increment;
        if (currentScale >= maxScale)
        {
            currentScale = maxScale;
        }
        else if (currentScale <= minScale)
        {
            currentScale = minScale;
        }
        imageToZoom.GetComponent<RectTransform>().localScale = new Vector2(currentScale, currentScale);
    }

}

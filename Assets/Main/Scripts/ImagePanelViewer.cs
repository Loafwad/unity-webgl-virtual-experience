using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePanelViewer : MonoBehaviour
{
    [SerializeField] private List<Sprite> imageArray = new List<Sprite>();
    [SerializeField] private Image currImg;
    [SerializeField] private Image prevImg;
    [SerializeField] private Image inspectPanelPrevImg;
    [SerializeField] private Image inspectPanelCurrImg;
    // Start is called before the first frame update

    public int currIndex;
    void Start()
    {
        prevImg.sprite = imageArray[0];
        currImg.sprite = imageArray[1]
        ;
    }
    public void OnNext()
    {
        if (currIndex + 1 < imageArray.Count - 1)
        {
            currIndex++;
            prevImg.sprite = imageArray[currIndex];
            currImg.sprite = imageArray[currIndex + 1];
            InspectMenuEnable();
        }
    }

    public void OnPrev()
    {
        if (currIndex - 1 >= 0)
        {
            currIndex--;
            prevImg.sprite = imageArray[currIndex];
            currImg.sprite = imageArray[currIndex + 1];
            InspectMenuEnable();
        }
    }

    public void InspectMenuEnable()
    {
        inspectPanelCurrImg.sprite = imageArray[currIndex];
        inspectPanelPrevImg.sprite = imageArray[currIndex + 1];
    }
}

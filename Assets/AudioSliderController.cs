using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AudioSliderController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Slider audioTimeSlider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TMP_Text audioTimeCount;

    bool isHovering;

    void Start()
    {
        audioTimeSlider.maxValue = audioSource.clip.length;
    }
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
        if (Input.GetMouseButton(0) && isHovering)
        {
            audioSource.time = audioTimeSlider.value;
            audioSource.Pause();
        }
        else if (isHovering)
        {
            audioSource.UnPause();
            audioTimeCount.text = FormatTime(audioSource.time);
            audioTimeSlider.value = audioSource.time;
        }
    }

    public string FormatTime(float time)
    {
        int minutes = ((int)time % 3600) / 60;
        int seconds = (int)time % 60;
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}

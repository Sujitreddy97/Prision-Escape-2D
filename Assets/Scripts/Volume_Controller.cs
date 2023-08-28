using UnityEngine;
using UnityEngine.UI;

public class Volume_Controller : MonoBehaviour
{
    [SerializeField] private Slider BG_Slider;
    [SerializeField] private Slider SFX_Slider;


    // Start is called before the first frame update
    void Start()
    {
        BG_Slider.onValueChanged.AddListener(OnBGSliderValueChange);
        SFX_Slider.onValueChanged.AddListener(OnSFXSliderValueChange);
    }

    private void OnBGSliderValueChange(float value)
    {
        Audio_Manager.Instance.SetBGVolume(value);
    }

    private void OnSFXSliderValueChange(float value)
    {
        Audio_Manager.Instance.SetSFXVolume(value);
    }
}

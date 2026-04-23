using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMusic : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _bufferVolume;
    private float _minVolume = 0.0001f;

    public void SetVolume()
    {
        if (_slider.value > _minVolume)
        {
            _bufferVolume = _slider.value;

            _slider.value = _minVolume;
        }
        else if (_slider.value == _minVolume)
        {
            _slider.value = _bufferVolume;
        }
    }
}

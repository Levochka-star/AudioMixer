using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchMusic : MonoBehaviour
{
    private Button _button;

    private float _listenerDefaultVolume;
    private float _listenerMinVolume = 0f;

    private void Awake()
    {
        _listenerDefaultVolume = AudioListener.volume;
        _button = GetComponent<Button>();

        _button.onClick.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetVolume);
    }

    public void SetVolume()
    {
        bool isPlaying = AudioListener.volume > _listenerMinVolume ? true : false;

        if (isPlaying)
        {
            AudioListener.volume = _listenerMinVolume;
        }
        else
        {
            AudioListener.volume = _listenerDefaultVolume;
        }
    }
}

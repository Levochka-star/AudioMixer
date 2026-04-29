using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class ButtonMusic : MonoBehaviour
{
    private Button _button;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(PlayAudio);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayAudio);
    }

    public void PlayAudio()
    {
        _audio.PlayOneShot(_audio.clip);
    }
}

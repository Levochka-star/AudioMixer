using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MixerControler : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _name;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        SetVolume(_name, _slider.value);
    }

    public void SetVolume(float volume)
    {
        SetVolume(_name, volume);
    }

    private void SetVolume(string name, float volume)
    {
        _mixer.SetFloat(name, Mathf.Log10(volume) * 20);
    }
}

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent (typeof (Slider))]
    public class AudioParameterAdjuster : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;

        private string _name;
       
        private Slider _slider;


        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _name = gameObject.name;
            _slider.onValueChanged.AddListener(SetVolume);
        }

        private void Start()
        {
            SetVolume(_name, _slider.value);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(SetVolume);
        }

        private void SetVolume(float volume)
        {
            SetVolume(_name, volume);
        }

        private void SetVolume(string name, float volume)
        {
            _mixer.SetFloat(name, Mathf.Log10(volume) * 20);
        }
    }
}
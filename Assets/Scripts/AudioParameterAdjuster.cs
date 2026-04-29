using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Slider))]
    public class AudioParameterAdjuster : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;

        [SerializeField] private string _name;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
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
            int logMultiple = 20;
            int minValueDB = -80;

            if (volume == 0)
            {
                _mixer.SetFloat(name, minValueDB);
            }
            else
            {
                _mixer.SetFloat(name, Mathf.Log10(volume) * logMultiple);
            }
        }
    }
}
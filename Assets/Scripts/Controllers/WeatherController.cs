using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class WeatherController : MonoBehaviour
    {
        public List<ParticleSystem> ParticleSystemsSnow;
        public List<ParticleSystem> ParticleSystemsRain;

        private static bool _isRain;
        private static bool _isSnow;

        private void Awake()
        {
            foreach (var system in ParticleSystemsSnow) { system.gameObject.SetActive(false); }
            foreach (var system in ParticleSystemsRain) { system.gameObject.SetActive(false); }
        }

        public void OnSnowClick()
        {
            if (_isRain) { _isRain = !_isRain; foreach (var system in ParticleSystemsRain) { system.gameObject.SetActive(false); } }

            if (_isSnow) { _isSnow = !_isSnow; foreach (var system in ParticleSystemsSnow) { system.gameObject.SetActive(false); } return; }
            _isSnow = true; foreach (var system in ParticleSystemsSnow) { system.gameObject.SetActive(true); }
        }
        public void OnRainClick()
        {
            if (_isSnow) { _isSnow = !_isSnow; foreach (var system in ParticleSystemsSnow) { system.gameObject.SetActive(false); } }

            if (_isRain) { _isRain = !_isRain; foreach (var system in ParticleSystemsRain) { system.gameObject.SetActive(false); } return; }
            _isRain = true; foreach (var system in ParticleSystemsRain) { system.gameObject.SetActive(true); }
        }
    }
}

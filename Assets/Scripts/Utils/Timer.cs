using System;
using UnityEngine;

namespace SpaceInvaders.Utils
{
    [Serializable]
    public class Timer
    {
        [SerializeField] private float _value;
        private float _timeUp;
        private float _startTime;

        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public Timer()
        {
            _value = 0;
        }

        public Timer(float value)
        {
            _value = value;
        }

        public void Reset()
        {
            _startTime = Time.time;
            _timeUp = _startTime + _value;
        }

        public void EarlyComplete()
        {
            _timeUp -= _value;
        }

        public bool IsReady => _timeUp <= Time.time;
        public float ReadyProgress => (Time.time - _startTime) / (_timeUp - _startTime);
    }
}
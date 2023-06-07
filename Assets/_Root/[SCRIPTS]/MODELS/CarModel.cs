using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    internal class CarModel  
    {
        private float _defaultSpeed;
        public float Speed { get; set; }

        public CarModel(float speed)
        {
            _defaultSpeed = speed;
            Speed = _defaultSpeed;
        }


    }
}
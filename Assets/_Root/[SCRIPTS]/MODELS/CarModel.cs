using Game.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    internal class CarModel  : IUpgradable
    {
        private float _defaultSpeed;
        public float Speed { get; private set; }
        public float Value { get =>  Speed; set => Speed = value; }

        public CarModel(float speed)
        {
            _defaultSpeed = speed;
            Speed = _defaultSpeed;
        }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }
    }
}
using Configs.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Models
{
    internal class BombGunAbility : IAbility
    {
        private AbilityItemConfig _config;
        public BombGunAbility(AbilityItemConfig config)
        {
            _config = config;
        }

        void IAbility.Apply(IAbilityActivator activator)
        {
            var rb = GameObject.Instantiate(_config.Projectile).GetComponent<Rigidbody2D>();

            Vector3 force = activator.ViewGameObject.transform.right * _config.Value;

            rb.AddForce(force,ForceMode2D.Force);
            GameObject.Destroy(rb.gameObject, 5f);
        }
    }
}
using Configs.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Models
{
    internal class JumpAbility : IAbility
    {
        private AbilityItemConfig _config;
        public JumpAbility(AbilityItemConfig config)
        {
            _config = config;
        }

        void IAbility.Apply(IAbilityActivator activator)
        {
            var rb = activator.ViewGameObject.GetComponent<Rigidbody2D>();

            Vector3 force = activator.ViewGameObject.transform.up * _config.Value;

            rb.AddForce(force,ForceMode2D.Force);
             
        }
    }
}
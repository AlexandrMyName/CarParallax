using System.Collections.Generic;
using UnityEngine;


namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(AbilitiesItemConfigsDataBase), menuName = "Configs/Abilities/" + 
        nameof(AbilitiesItemConfigsDataBase), order = 1)]
    internal class AbilitiesItemConfigsDataBase : ScriptableObject
    {
        [SerializeField] AbilityItemConfig[] _configs; 


        public IReadOnlyList<AbilityItemConfig> Configs => _configs;
    }
}
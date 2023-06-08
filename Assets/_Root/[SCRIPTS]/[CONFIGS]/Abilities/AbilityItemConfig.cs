using Configs.Inventory;
using UnityEngine;

namespace Configs.Inventory
{
    internal interface IAbility
    {
        void Apply(IAbilityActivator activator);
    }
    internal interface IAbilityActivator
    {
        GameObject ViewGameObject {get;}
    }
    internal interface IAbilityItem
    {
        Sprite Icon { get; }
        string Id { get; }
        GameObject Projectile { get; }
        AbilityType Type { get; }
        float Value { get; }
    }

    [CreateAssetMenu(fileName = nameof(AbilityItemConfig), menuName = "Configs/Abilities/" + nameof(AbilityItemConfig), order = 1)]
    internal class AbilityItemConfig : ScriptableObject, IAbilityItem
    {
        [SerializeField] private ItemConfig _itemConfig;

        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
        [field: SerializeField] public AbilityType Type { get; private set; }


        public string Id => _itemConfig.Id;
        public Sprite Icon => _itemConfig.Icon;
    }

    internal enum AbilityType { None, BombGun, Jump }
}

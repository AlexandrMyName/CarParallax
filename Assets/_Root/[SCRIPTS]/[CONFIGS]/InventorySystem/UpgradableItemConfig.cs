using UnityEngine;

namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(UpgradableItemConfig), menuName = "Configs/Inventory/" + nameof(UpgradableItemConfig), order = 1)]
    public class UpgradableItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemConfig Config { get; set; }
        [field: SerializeField] public float Value { get; set; }
        [field: SerializeField] public UpgradeType Type { get; set; }
    }

    public enum UpgradeType {  None, Speed }
}

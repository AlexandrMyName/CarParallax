using UnityEngine;


namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(DataBaseUpgradableItemConfig), menuName = "Configs/Inventory/" + nameof(DataBaseUpgradableItemConfig), order = 1)]
    public class DataBaseUpgradableItemConfig : ScriptableObject
    {
        [field: SerializeField] public UpgradableItemConfig [] Configs { get; set; }
    }
}

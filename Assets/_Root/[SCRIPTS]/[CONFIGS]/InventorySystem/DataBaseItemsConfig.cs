using UnityEngine;


namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(DataBaseItemsConfig), menuName = "Configs/Inventory/" + nameof(DataBaseItemsConfig), order = 1)]
    public class DataBaseItemsConfig : ScriptableObject
    {
        [field: SerializeField] public ItemConfig[] Configs { get; set; }
    }
}

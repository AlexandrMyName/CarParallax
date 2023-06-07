using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Configs.Inventory
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/Inventory/"+ nameof(ItemConfig),order = 1)]
    public class ItemConfig : ScriptableObject
    {
        [field:SerializeField] public string Id { get; set; }
        [field: SerializeField] public string Title { get; set; }
        [field: SerializeField] public Sprite Icon { get; set; }

    }
}
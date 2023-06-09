using UnityEngine;

namespace Configs
{

    [CreateAssetMenu(fileName = nameof(MainConfig), menuName = "Configs/Main/" + nameof(MainConfig), order = 1)]
    public class MainConfig : ScriptableObject
    {
        [field: SerializeField] public float EntrySpeedCar { get; private set; } 
    }
}
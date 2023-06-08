using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    internal class GarageView : MonoBehaviour
    {
        [SerializeField] private Button _buttonApply;


        public void Init(UnityAction methodApply)
        {
            _buttonApply.onClick.AddListener(methodApply);
        }

        private void OnDestroy()
        {
            _buttonApply.onClick.RemoveAllListeners();
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    internal class AbilityButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;

        public void Init(Sprite icon, UnityAction mehod)
        {
            _icon.sprite = icon;
            _button.onClick.AddListener(mehod);
        }
        public void DeInit( )
        {
            _icon.sprite = null;
            _button.onClick.RemoveAllListeners();
        }
        private void OnDestroy() => DeInit();
    }
}
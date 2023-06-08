using Game.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UI
{
    internal class ItemView : MonoBehaviour
    {
        [SerializeField] private GameObject _sellectedBackGround;
        [SerializeField] private GameObject _unSellectedBackGround;

        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private Image _icon;

        public void Init(IItem item, UnityAction methodOnClick)
        {
            _icon.sprite = item.Info.Icon;
            _title.text = item.Info.Title;
            _button.onClick.AddListener(methodOnClick);
        }
        public void DeInit( )
        {
            _icon.sprite = null;
            _title.text = String.Empty;
            _button.onClick.RemoveAllListeners();
        }

        public void Sellect() => SetSelected(true);

        public void UnSellect() => SetSelected(false);

        private void SetSelected(bool isSelect)
        {
            _sellectedBackGround.SetActive(isSelect);
            _unSellectedBackGround.SetActive(!isSelect);
        }
    }
}
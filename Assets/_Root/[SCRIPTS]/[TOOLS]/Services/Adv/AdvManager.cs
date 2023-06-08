using System.Collections.Generic;
using UnityEngine;

namespace Tools.Services
{
    /// <summary>
    /// ћенеджер реклам содержит лист с рекламными сервисами и вызывает первую в колекции ! Ѕудьте осторожны , переопредел€йте переменную currentService
    /// </summary>
    internal class AdvManager : MonoBehaviour
    {
        private List<IAdvService> _adsServeces;
        private int currentService = 0;
        [SerializeField] private bool advForPeopleUnder13Age;
        private IAdvService advService;

        private void Awake()
        {
            _adsServeces = new List<IAdvService>() { new YandexAdvSerice() };
            advService = _adsServeces[currentService];


        }
        public void ShowFullScreenAdv() => advService.RequestInterstitial(advForPeopleUnder13Age);
        public void ShowRewardedAdv() => advService.RequestRewardedAd(advForPeopleUnder13Age);
    }
}
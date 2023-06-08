
namespace Tools.Services
{
    internal interface IAdvService : IService
    {
        void ShowRewardedAdv();
        void ShowFullScreenAdv();

        void RequestInterstitial(bool isUnder13);

        void RequestRewardedAd(bool isUnder13);
    }
}
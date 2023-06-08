using System;
using UnityEngine;
using YandexMobileAds.Base;
using YandexMobileAds;

namespace Tools.Services
{
    internal class YandexAdvSerice : IAdvService
    {
        string _fullAdvID = "R-M-2422649-2";
        string _rewardedAdvID = "R-M-2422649-1";
        public string ID_FullADV => _fullAdvID;

        public string ID_RewardedADV => _rewardedAdvID;

        private Interstitial interstitial;
        private RewardedAd rewardedAd;

        public bool IsLoadedFullAdv => interstitial.IsLoaded();
        public bool IsLoadedRewardedAdv => rewardedAd.IsLoaded();

        public void ShowFullScreenAdv() => interstitial.Show();
        public void ShowRewardedAdv() => rewardedAd.Show();
        private AdRequest CreateAdRequest() => new AdRequest.Builder().Build();

        public void RequestInterstitial(bool under13)
        {
            MobileAds.SetAgeRestrictedUser(under13);
            if (this.interstitial != null)
                this.interstitial.Destroy();

            this.interstitial = new Interstitial(ID_FullADV);

            this.interstitial.OnInterstitialLoaded += this.HandleInterstitialLoaded;
            this.interstitial.OnInterstitialFailedToLoad += this.HandleInterstitialFailedToLoad;
            this.interstitial.OnReturnedToApplication += this.HandleReturnedToApplication;
            this.interstitial.OnLeftApplication += this.HandleLeftApplication;
            this.interstitial.OnAdClicked += this.HandleAdClicked;
            this.interstitial.OnInterstitialShown += this.HandleInterstitialShown;
            this.interstitial.OnInterstitialDismissed += this.HandleInterstitialDismissed;
            this.interstitial.OnImpression += this.HandleImpression;
            this.interstitial.OnInterstitialFailedToShow += this.HandleInterstitialFailedToShow;
            this.interstitial.LoadAd(this.CreateAdRequest());

        }
        public void RequestRewardedAd(bool userAge_Under13)
        {
            MobileAds.SetAgeRestrictedUser(false);

            if (this.rewardedAd != null)
                this.rewardedAd.Destroy();

            this.rewardedAd = new RewardedAd(_rewardedAdvID);
            this.rewardedAd.OnRewardedAdLoaded += this.HandleRewardedAdLoaded;
            this.rewardedAd.OnRewardedAdFailedToLoad += this.HandleRewardedAdFailedToLoad;
            this.rewardedAd.OnReturnedToApplication += this.HandleReturnedToApplication;
            this.rewardedAd.OnLeftApplication += this.HandleLeftApplication;
            this.rewardedAd.OnAdClicked += this.HandleAdClicked;
            this.rewardedAd.OnRewardedAdShown += this.HandleRewardedAdShown;
            this.rewardedAd.OnRewardedAdDismissed += this.HandleRewardedAdDismissed;
            this.rewardedAd.OnImpression += this.HandleImpression;
            this.rewardedAd.OnRewarded += this.HandleRewarded;
            this.rewardedAd.OnRewardedAdFailedToShow += this.HandleRewardedAdFailedToShow;
            this.rewardedAd.LoadAd(this.CreateAdRequest());
        }

        #region Interstitial callback handlers

        public void HandleInterstitialLoaded(object sender, EventArgs args)
        {
            interstitial.Show();
        }

        public void HandleInterstitialFailedToLoad(object sender, AdFailureEventArgs args)
        {
            Debug.Log("HandleInterstitialFailedToLoad event received with message: " + args.Message);
        }

        public void HandleReturnedToApplication(object sender, EventArgs args)
        {
            Debug.Log("HandleReturnedToApplication event received");
        }

        public void HandleLeftApplication(object sender, EventArgs args)
        {
            Debug.Log("HandleLeftApplication event received");
        }

        public void HandleAdClicked(object sender, EventArgs args)
        {
            Debug.Log("HandleAdClicked event received");
        }

        public void HandleInterstitialShown(object sender, EventArgs args)
        {
            Debug.Log("HandleInterstitialShown event received");
        }

        public void HandleInterstitialDismissed(object sender, EventArgs args)
        {
            Debug.Log("HandleInterstitialDismissed event received");
        }

        public void HandleImpression(object sender, ImpressionData impressionData)
        {
            var data = impressionData == null ? "null" : impressionData.rawData;
            Debug.Log("HandleImpression event received with data: " + data);
        }

        public void HandleInterstitialFailedToShow(object sender, AdFailureEventArgs args)
        {
            Debug.Log("HandleInterstitialFailedToShow event received with message: " + args.Message);
        }


        #endregion


        #region Rewarded Ad callback handlers

        public void HandleRewardedAdLoaded(object sender, EventArgs args)
        {
            rewardedAd.Show();
        }

        public void HandleRewardedAdFailedToLoad(object sender, AdFailureEventArgs args)
        {
            Debug.Log(
                "HandleRewardedAdFailedToLoad event received with message: " + args.Message);
        }


        public void HandleRewardedAdShown(object sender, EventArgs args)
        {
            Debug.Log("HandleRewardedAdShown event received");
        }

        public void HandleRewardedAdDismissed(object sender, EventArgs args)
        {
            Debug.Log("HandleRewardedAdDismissed event received");
        }


        public void HandleRewarded(object sender, Reward args)
        {
            Debug.Log("HandleRewarded event received: amout = " + args.amount + ", type = " + args.type);
        }

        public void HandleRewardedAdFailedToShow(object sender, AdFailureEventArgs args)
        {
            Debug.Log(
                "HandleRewardedAdFailedToShow event received with message: " + args.Message);
        }

        #endregion
    }
}

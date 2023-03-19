using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class BottomBanner : MonoBehaviour
{
    private BannerView bannerView;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID    
            // 실전용 공고ID
            // string adUnitId = "ca-app-pub-5504078506585326/5274944577";
            // 데모용 광고ID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        if(this.bannerView != null){
            this.bannerView.Destroy();
        }

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);
        
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    // public void LoadAd()
    // {
    //     if(_bannerView == null)
    //     {
    //         CreateBannerView();
    //     }
    //     // create our request used to load the ad.
    //     var adRequest = new AdRequest.Builder()
    //         .AddKeyword("unity-admob-sample")
    //         .Build();

    //     _bannerView.LoadAd(adRequest);
    // }
}

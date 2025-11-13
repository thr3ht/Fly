using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private BannerView _bannerView;
    private string _bannerUnitId = "ca-app-pub-3940256099942544/6300978111";

    private void Start()
    {
        CreateBanner();
        ShowBanner();
    }

    private void OnDestroy()
    {
        _bannerView?.Destroy();
    }

    public void ShowBanner()
    {
        _bannerView?.Show();
    }

    public void HideBanner()
    {
        _bannerView?.Hide();
    }

    private void CreateBanner()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        _bannerView = new BannerView(_bannerUnitId, AdSize.Banner, AdPosition.Bottom);

        _bannerView.LoadAd(new AdRequest());
    }
}
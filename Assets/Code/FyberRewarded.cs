using UnityEngine;
using System.Collections;
using FyberPlugin;

public class FyberRewarded : MonoBehaviour {

    //appId
    public string appId = "28675"; //we'll be using Android only for now
    public string AppId
    {
        get
        {
            return appId;
        }

        set
        {
            appId = value;
        }
    }

    //userId
    string userId = "unityuser";
    public string UserId
    {
        get
        {
            return userId;
        }

        set
        {
            userId = value;
        }
    }

    //token
    string securityToken = "token";
    public string SecurityToken
    {
        get
        {
            return securityToken;
        }

        set
        {
            securityToken = value;
        }
    }

    //settings
    Settings settings;

    //an ad
    Ad rewardedVideoAd;

    void Start()
    {
        ChangeSettings();
    }

    void OnEnable()
    {
        //handling native exceptions
        FyberCallback.NativeError += OnNativeExceptionReceivedFromSDK;
        // Ad availability
        FyberCallback.AdAvailable += OnAdAvailable;
        //Handling AdErrors
        FyberCallback.AdNotAvailable += OnAdNotAvailable;
        FyberCallback.RequestFail += OnRequestFail;
    }

    void OnDisable()
    {
        //handling native exceptions
        FyberCallback.NativeError -= OnNativeExceptionReceivedFromSDK;
        // Ad availability
        FyberCallback.AdAvailable -= OnAdAvailable;
        //Handling AdErrors
        FyberCallback.AdNotAvailable -= OnAdNotAvailable;
        FyberCallback.RequestFail -= OnRequestFail;
    }

    public void OnNativeExceptionReceivedFromSDK(string message)
    {
        //handle exception
    }

    private void OnAdAvailable(Ad ad)
    {
        switch(ad.AdFormat)
        {
            case AdFormat.REWARDED_VIDEO:
                rewardedVideoAd = ad;
                break;
            //handle other ad formats if needed
        }
    }

    public void ChangeSettings()
    {
        settings = Fyber.With(appId)
            // optional chaining methods
            .WithUserId(userId)
            //.WithParameters(dictionary)
            .WithSecurityToken(securityToken)
            //.WithManualPrecaching()
            .Start();
    }

    public void RequestAdd()
    {
        RewardedVideoRequester.Create()
        // optional method chaining
        //.AddParameter("key", "value")
        //.AddParameters(dictionary)
        //.WithPlacementId(placementId)
        // changing the GUI notification behaviour when the user finishes viewing the video
        //.NotifyUserOnCompletion(true)
        // you can add a virtual currency requester to a video requester instead of requesting it separately
        //.WithVirtualCurrencyRequester(virtualCurrencyRequester)
        // you don't need to add a callback if you are using delegates
        //.WithCallback(requestCallback)
        // requesting the video
        .Request();
    }

    public void ShowVideo()
    {
        if (rewardedVideoAd != null)
        {
            rewardedVideoAd.Start();
            rewardedVideoAd = null;
        }
    }

    private void OnAdNotAvailable(AdFormat adFormat)
    {
        switch(adFormat)
        {
            case AdFormat.REWARDED_VIDEO:
                rewardedVideoAd = null;
                break;
            //handle other ad formats if needed
        }
    }

    private void OnRequestFail(RequestError error)
    {
        // process error
        UnityEngine.Debug.Log("OnRequestError: " + error.Description);
    }
}

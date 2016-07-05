using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUserInfo : MonoBehaviour {

    public InputField uid;
    public InputField appId;
    public InputField token;
    private FyberRewarded fyberRewarded;

    void Start()
    {
        fyberRewarded = GetComponent<FyberRewarded>();
        uid.onValueChanged.AddListener (delegate {UIdValueChangeCheck ();});
        appId.onValueChanged.AddListener (delegate {AppIdValueChangeCheck ();});
        token.onValueChanged.AddListener (delegate {TokenValueChangeCheck ();});
    }

    public void UIdValueChangeCheck()
	{
		Debug.Log ("UID Value Changed");
        fyberRewarded.UserId = uid.text;
        fyberRewarded.ChangeSettings();
	}

    public void AppIdValueChangeCheck()
	{
		Debug.Log ("AppId Value Changed");
        fyberRewarded.AppId = appId.text;
        fyberRewarded.ChangeSettings();
	}

    public void TokenValueChangeCheck()
	{
		Debug.Log (" Token Value Changed");
        fyberRewarded.SecurityToken = token.text;
        fyberRewarded.ChangeSettings();
	}
}

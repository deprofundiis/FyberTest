using UnityEngine;
using System.Collections;

public class ShowVideo : MonoBehaviour {

    FyberRewarded fyberMain;

	// Use this for initialization
	void Start () {
        fyberMain = GetComponent<FyberRewarded>();
	}

    public void RequestVideo()
    {
        fyberMain.RequestAdd();
    }

    public void ShowVideoAdd()
    {
        fyberMain.ShowVideo();
    }
}

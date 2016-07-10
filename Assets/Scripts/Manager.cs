using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	void Start () {

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		Time.captureFramerate = 60;
	}
	
	void Update () {
	
	}
}

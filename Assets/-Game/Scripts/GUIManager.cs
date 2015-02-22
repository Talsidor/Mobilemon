using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	GameObject controlsPanel;

	void Start () {
		controlsPanel = transform.FindChild("ControlsPanel").gameObject;
		if(Application.isMobilePlatform) {

		}
		else
			controlsPanel.SetActive(false);
	}

	void Update () {
	
	}
}
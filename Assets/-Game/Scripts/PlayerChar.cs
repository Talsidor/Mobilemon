using UnityEngine;
using System.Collections;

public class PlayerChar : Character {

	TextMesh tm;

	override protected void Start () {
		base.Start();
		tm = GetComponentInChildren<TextMesh>();
		tm.text = (photonView.viewID / 1000).ToString();
	}

	override protected void Update () {
		if(photonView.isMine) {
				 if(Input.GetKey(KeyCode.W)) BeginMovement(Moving.up);
			else if(Input.GetKey(KeyCode.S)) BeginMovement(Moving.down);
			else if(Input.GetKey(KeyCode.A)) BeginMovement(Moving.left);
			else if(Input.GetKey(KeyCode.D)) BeginMovement(Moving.right);
		}
		base.Update();
	}
}
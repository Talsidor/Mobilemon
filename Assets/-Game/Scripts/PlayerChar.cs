﻿using UnityEngine;
using System.Collections;

public class PlayerChar : Character {

	override protected void Start () {
		base.Start();
	}

	override protected void Update () {

		if(Input.GetKey(KeyCode.W))
			BeginMovement(Moving.up);
		else if(Input.GetKey(KeyCode.S))
			BeginMovement(Moving.down);
		else if(Input.GetKey(KeyCode.A))
			BeginMovement(Moving.left);
		else if(Input.GetKey(KeyCode.D))
			BeginMovement(Moving.right);

		base.Update();
	}
}
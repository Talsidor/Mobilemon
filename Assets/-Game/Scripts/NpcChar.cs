using UnityEngine;
using System.Collections;

public class NpcChar : Character {

	public float timeBetweenMovements;
	public bool moveRandomly;

	float delayBeforeMove;

	override protected void Start () {
		delayBeforeMove = timeBetweenMovements;
		base.Start();
	}

	override protected void Update () {
		if(photonView.isMine) {
			if(moveRandomly) {
				if(delayBeforeMove <= 0) {
					delayBeforeMove = timeBetweenMovements;
					BeginMovement( (Moving)Random.Range(1, 5) );
				}
				else 
					delayBeforeMove -= Time.deltaTime;
			}
		}

		base.Update();
	}
}
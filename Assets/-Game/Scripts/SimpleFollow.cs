using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour {

	public Transform follow;

	void Update () {
		transform.position = follow.position;
	}
}
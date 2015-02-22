using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour {

	public Transform follow;

	void Update () {
		if(follow) transform.position = follow.position;
	}
}
using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	protected enum Moving {none, up, down, left, right}
	protected Moving moving;

	protected Vector3 gridPos, lastPos;
	protected float moveSpeed=5;

	virtual protected void Start () {
		moving = Moving.none;
		SnapToGrid();
		lastPos = gridPos = transform.position;
	}

	virtual protected void Update () {
		switch(moving) 
		{
		case Moving.none: 	SnapToGrid();	break;
		case Moving.up: 	if( MoveTowards ( gridPos + Vector3.forward * 2 ) ) moving = Moving.none;	break;
		case Moving.down: 	if( MoveTowards ( gridPos + Vector3.back * 2 	) ) moving = Moving.none;	break;
		case Moving.left: 	if( MoveTowards ( gridPos + Vector3.left * 2 	) ) moving = Moving.none;	break;
		case Moving.right: 	if( MoveTowards ( gridPos + Vector3.right * 2 	) ) moving = Moving.none;	break;
		}
		transform.forward = Vector3.RotateTowards(transform.forward, transform.position - lastPos, Time.deltaTime * 20, 0);
		lastPos = transform.position;
	}

	protected void BeginMovement (Moving dir) {
		if(moving != Moving.none) return;

		moving = dir;
	}

	protected void SnapToGrid () {
		transform.position = new Vector3( Mathf.Round(transform.position.x / 2) * 2, transform.position.y, Mathf.Round(transform.position.z / 2) * 2 );
		gridPos = transform.position;
	}

	protected bool MoveTowards (Vector3 pos) {
		transform.position = Vector3.MoveTowards( transform.position, pos, moveSpeed * Time.deltaTime );
		if(transform.position == pos) {
			gridPos = pos;
			return true;
		}
		else
			return false;
	}
}
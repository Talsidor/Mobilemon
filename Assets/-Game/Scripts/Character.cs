using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PhotonView))]
public class Character : Photon.MonoBehaviour {

	public enum Moving {none, up, down, left, right}
	protected Moving moving;
	
	protected Vector3 gridPos, lastPos;
	protected float moveSpeed=5, rotSpeed=5;

	// SuperBehaviour Vars
	protected Vector3 pos { get{ return transform.position; } set { transform.position = value; } }
	protected Quaternion rot { get{ return transform.rotation; } set { transform.rotation = value; } }

	// Photon Vars
	protected Vector3 photonPos;
	protected Quaternion photonRot;

	virtual protected void Start () {
		moving = Moving.none;
		SnapToGrid();
		photonPos = lastPos = gridPos = pos;
		photonRot = rot;
	}

	virtual protected void Update () {
		if(photonView.isMine) {
			switch(moving) 
			{
			case Moving.none: 	SnapToGrid();	break;
			case Moving.up: 	if( MoveTowards ( gridPos + Vector3.forward * 2 ) ) moving = Moving.none;	break;
			case Moving.down: 	if( MoveTowards ( gridPos + Vector3.back * 2 	) ) moving = Moving.none;	break;
			case Moving.left: 	if( MoveTowards ( gridPos + Vector3.left * 2 	) ) moving = Moving.none;	break;
			case Moving.right: 	if( MoveTowards ( gridPos + Vector3.right * 2 	) ) moving = Moving.none;	break;
			}

			//transform.forward = Vector3.RotateTowards(transform.forward, pos - lastPos, Time.deltaTime * 5, 0);
			lastPos = pos;
		}
		else {
			pos = Vector3.Lerp( pos, photonPos, Time.deltaTime * moveSpeed);
			rot = Quaternion.Lerp( rot, photonRot, Time.deltaTime * rotSpeed);
		}
	}

	public void BeginMovement (Moving dir) {
		if(moving != Moving.none) return;

		moving = dir;
	}

	protected void SnapToGrid () {
		pos = new Vector3( Mathf.Round(pos.x / 2) * 2, pos.y, Mathf.Round(pos.z / 2) * 2 );
		gridPos = pos;
	}

	protected bool MoveTowards (Vector3 destPos) {
		pos = Vector3.MoveTowards( pos, destPos, Time.deltaTime * moveSpeed );
		rot = Quaternion.Lerp( rot, Quaternion.LookRotation( pos - lastPos ), Time.deltaTime * rotSpeed);
		if(pos == destPos) {
			gridPos = destPos;
			return true;
		}
		else
			return false;
	}

	protected void OnPhotonSerializeView ( PhotonStream stream, PhotonMessageInfo info ) {
		if(stream.isWriting) {
			stream.SendNext( pos );
			stream.SendNext( rot );
		}
		else {
			photonPos = (Vector3)stream.ReceiveNext();
			photonRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
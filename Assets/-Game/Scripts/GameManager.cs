using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	PlayerChar myPlayer;

	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby () {
		PhotonNetwork.JoinOrCreateRoom( Application.loadedLevelName, null, null );
	}

	void OnJoinedRoom () {
		myPlayer = PhotonNetwork.Instantiate ( "PlayerCharacter", Vector3.zero, Quaternion.identity, 0 ).GetComponent<PlayerChar>();
		GameObject.Find("CamRig").GetComponent<SimpleFollow>().follow = myPlayer.transform;
	}

	void Update () {
		
	}

	void OnGUI() {
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		//GUILayout.Label( System.Environment.UserName );
	}

	public void GuiInput_Up () {
		myPlayer.BeginMovement(Character.Moving.up);
	}
	public void GuiInput_Down () {
		myPlayer.BeginMovement(Character.Moving.down);
	}
	public void GuiInput_Left () {
		myPlayer.BeginMovement(Character.Moving.left);
	}
	public void GuiInput_Right () {
		myPlayer.BeginMovement(Character.Moving.right);
	}

}
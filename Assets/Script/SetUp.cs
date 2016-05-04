using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour {

	public GameMgr m_GameMgr = null;
	private NetworkMgr m_Network = null;
	public string name = null;

	// Use this for initialization
	void Start () {
		Debug.Log ("SetUp Start");

		PlayerPrefs.DeleteKey("USER_NAME");

		m_GameMgr = new GameMgr ();
		m_Network = GameObject.Find ("NetworkMgr").GetComponent<NetworkMgr> ();
		m_GameMgr.CreateIns ();

		StartSetUp ();
	}

	private void StartSetUp(){
		//check user existing
		//load first scene f(user_exist);
		m_GameMgr.LoadHomeScene ();
	}
}
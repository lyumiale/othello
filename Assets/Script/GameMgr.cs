using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

	public static GameMgr m_Ins = null;
	private NetworkMgr m_Network = null;
	public static string User_Name = null;
	public GameObject HomeUi = null;

	void Start (){
		m_Network = GameObject.Find ("NetworkMgr").GetComponent<NetworkMgr> ();
	}

	public void CreateIns(){
		m_Ins = new GameMgr ();
	}


	static public GameMgr GetIns()
	{
		return m_Ins;
	}


	public void LoadHomeScene(){
		HomeUi = Instantiate(Resources.Load ("Prefabs/HomeUI") as GameObject);
		Debug.Log (HomeUi.activeSelf);
		HomeUi.SetActive (true);
	}

	public void ChangeText(){
		Text test = HomeUi.transform.FindChild ("Text").GetComponent<Text> ();
		Debug.Log ("get text comp");
		test.text = "Pushed";
	}

	public string Get_User_Name(){
		Debug.Log ("Check_User_Exist");
		User_Name = PlayerPrefs.GetString ("USER_NAME", "");//0 is default num.
		return User_Name;
		//m_Ins.HomeUi.transform.FindChild ("Canvas/MainButton/Text").GetComponent<Text> ().text = "ended!";
	}

	public void Set_User_Name(string name){
		Debug.Log ("set user name");
		PlayerPrefs.SetString ("USER_NAME", name);
		User_Name = PlayerPrefs.GetString ("USER_NAME", "");
		Debug.Log("user name " + User_Name);
		m_Network.Set_User_Name ();
	}

}
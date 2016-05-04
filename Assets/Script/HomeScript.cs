using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeScript : MonoBehaviour {

	private GameMgr m_GameMgr = null;

	public string user_name = null;
	
	void Start (){
		//m_GameMgr = new GameMgr();
		m_GameMgr = GameMgr.GetIns ();
		Debug.Log ("get gamemgr ins");

		user_name = m_GameMgr.Get_User_Name();

		//ユーザー名が登録されていなかったらダイアログを出す
		if (user_name == "") {
			Debug.Log ("user_name is not exist");
			this.transform.FindChild ("NameDialog").gameObject.SetActive (true);
		}
	
	}

	public void PushStart(){
		Debug.Log ("Push Start");
		this.GetComponentInChildren<Text> ().text = "pushed!!";
		Debug.Log (this.transform.FindChild("Canvas/MainButton/Text").GetComponent<Text>().text);
		//Debug.Log( this.transform.FindChild("MainButton").GetComponent<RectTransform>().localPosition);
	}

	//ユーザー名入力後DBに登録
	public void Set_User_Name(){
		m_GameMgr.Set_User_Name (name);
	}

}

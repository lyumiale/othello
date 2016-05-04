using UnityEngine;
using System.Collections;

public class NetworkMgr :MonoBehaviour{

	public string name = null;

	public void Set_User_Name () {
		StartCoroutine ("WWWTest");
	}
	IEnumerator WWWTest () {
		name = "yuta";
		WWWForm form = new WWWForm();
		form.AddField("name", name);
		WWW www = new WWW ("http://localhost/othello/initialise.php/",form);
		yield return www;
		Debug.Log ("WWWTest response: " + www.text);
		//jsonでphpからデータをもらう miniJson というフリープラグインがあるらしい

	}
}

//バトルごとにレコードを作成し、点差、ターン、配列を入れられればボード配列の状態をdbに登録してチェックする


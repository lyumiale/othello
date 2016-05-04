using UnityEngine;
using System.Collections;
using SocketIOClient;

public class SocketIoMgr {
	public SocketIOClient.Client client;//new Client("http://127.0.0.1:8080");

	public void Connect(){
		client = new Client("http://127.0.0.1:8080");

		client.On ("connect", (message) => {
			Debug.Log ("node connect start");
		});
		client.On ("message",(message)=> {
			Debug.Log(message.MessageText);
		});
		client.On ("emit",(message)=> {
			Debug.Log(message.MessageText);
		});
		client.Connect ();
	}

	public void Send(string mes){
		client.Send(mes);
	}

	public void test(){
		Debug.Log ("test");
	}
}

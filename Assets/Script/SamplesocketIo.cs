using UnityEngine;
using SocketIOClient;

public class SamplesocketIo : MonoBehaviour {

	public SocketIOClient.Client client;

	void OnGUI() {
		if (GUILayout.Button("Connect")) {
			client = new Client("http://127.0.0.1:8080");
			client.On("connect", (message) => {
			});
			client.On("message", (message) => {
				Debug.Log(message.MessageText);
			});
			client.On("emit", (message) => {
				Debug.Log(message.MessageText);
			});
			client.Connect();
		}

		if (GUILayout.Button("Send")) {
			client.Send("string");
		}

		if (GUILayout.Button("Emit")) {
			client.Emit("emit", System.DateTime.Now.ToString());
		}

		if (GUILayout.Button("Close")) {
			client.Close();
		}
	}
}
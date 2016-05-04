using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	public SocketIoMgr m_SocketIo = null;

	public NetworkMgr m_Network = null;

	public Dictionary<int,int> board = new Dictionary<int, int>();

	public int current_turn = 1;

	public List<int> leftline	 = new List<int>();
	public List<int> rightline	 = new List<int>();
	public List<int> upline 	 = new List<int>();
	public List<int> downline 	 = new List<int>();
	public List<int> leftup 	 = new List<int>();
	public List<int> leftdown 	 = new List<int>();
	public List<int> rightup 	 = new List<int>();
	public List<int> rightdown 	 = new List<int>();

	// Use this for initialization

	//black:1 white:-1 blank:0 wall:2
	void Start () {
		m_SocketIo = new SocketIoMgr ();
		//m_Network = GameObject.Find ("NetworkMgr").GetComponent<NetworkMgr> ();

		for(int i = 0; i < 100; i++){
			if(i % 10 == 0 || i % 10 == 9 || i/10 < 1 || i/10 > 9){
				board.Add(i,2);
			}else{
				board.Add(i,0);
			}

		}

		CreateCubes();

		// コルーチンに引数に5を渡して実行
		for (int i = 0; i < 5; i++) {
			StartCoroutine ("Sample", i);
		}

		//ネットワーク作業中
		//string res = m_Network.Test ();
		//Debug.Log (res);
		m_SocketIo.Connect ();
	}
	
	// Update is called once per frame
	void Update () {

		//タッチしたオブジェクトの名前を取得
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
		
			if (Physics.Raycast(ray, out hit)){
				GameObject obj = hit.collider.gameObject;
				Debug.Log ("Start set stone");
				//これでタッチしたオブジェクトのstatusが取れる
				int key = int.Parse(obj.name);
				Debug.Log("name:" + obj.name +" status: " + board[key]);
				Debug.Log("before set " + board[51] +" "+board[52] +" "+board[53] +" "+board[54] +" "+board[55] +" "+board[56] +" "+board[57] +" "+board[58] +" "+board[59]);
				if(board[key] == 0){
					SetStone(key);
				}
			}
		}
	}

	public void CreateCubes(){
		float y = 0f;
		float x = 0f;
		int calc = 0;
		int nextcount = 0;
		//ボード配列を回しつつ Cubeを盤面状に生成
		foreach(int key in board.Keys){
			GameObject Cube = Instantiate(Resources.Load("Prefabs/Cube") as GameObject);
			Cube.name = key.ToString();
			calc = Mathf.FloorToInt(key / 10);
			nextcount = calc*10;
			x = 1f*((key-nextcount)-1) + 0.1f*((key-nextcount)-1);
			y = 1f*calc + 0.1f*calc;
			Cube.transform.localPosition = new Vector3(x,y,0f);
		}
		
	}

	public void SetStone(int key){
		ChangeStoneColor (key);
		board[key] = current_turn;
	
		ReverseCheck (key);
		//Debug.Log("after set " + board[51] +" "+board[52] +" "+board[53] +" "+board[54] +" "+board[55] +" "+board[56] +" "+board[57] +" "+board[58] +" "+board[59]);
		leftline.Clear ();
		m_SocketIo.Send (key.ToString ()+"に配置"); 
		current_turn = current_turn * -1;
	}

	public void ReverseCheck(int key){
		//add reversable keys to list
		for(int i=0;i<10; i++){
			int currentkey = key - (i + 1);
			int value = board[currentkey];
			if(value == 0 || value == 2){
				leftline.Clear ();
				break;
			}else if(value == current_turn){
				break;
			}else if(value == current_turn*-1){
				leftline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
				Debug.Log("leftline.Count: " + leftline.Count);
			}else{
				Debug.Log("reverse check value error");
			}
		}

		if(leftline.Count > 0){
			StartReverse();		
		}
	}

	public void StartReverse(){
		Debug.Log ("leftline.Count" + leftline.Count);

		for(int i = 0; i < leftline.Count; i++) {
			int currentkey = leftline[i];
			Debug.Log ("leftline[key] " + leftline [i]);
			board[currentkey] = board[currentkey] * -1;
			ChangeStoneColor(currentkey);
		}
	}


	//sending cube's key and change cube's color
	public void ChangeStoneColor(int key){
		Debug.Log ("called changestonecolor" + current_turn);
		string cubename = key.ToString ();
		if (current_turn == 1){
			GameObject.Find(cubename).GetComponent<Renderer>().material.color = Color.black;
		}else{
			GameObject.Find(cubename).GetComponent<Renderer>().material.color = Color.blue;
		}
	}



	private IEnumerator Sample(int num) {
			Debug.Log ("i:" + num);
			yield return new WaitForSeconds (1f);
			Debug.Log ("next" );
		
	}
}

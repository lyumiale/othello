using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReverseChecker : MonoBehaviour {

	private Main m_Main = new Main();

	public void ReverseCheck(int key){
		//add reversable keys to list
		//####leftline
		//ボードのステータスがblankの場合のみチェック　ここは置けるかどうかの事前チェック
		for(int i=0;i<10; i++){
			int currentkey = key - (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.leftline.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.leftline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####rightline
		for(int i=0;i<10; i++){
			int currentkey = key + (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.rightline.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.rightline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####upline
		for(int i=0;i<10; i++){
			int currentkey = key + 10 * (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.upline.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.upline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####downline
		for(int i=0;i<10; i++){
			int currentkey = key - 10 * (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.downline.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.downline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####leftup
		for(int i=0;i<10; i++){
			int currentkey = key + 9 * (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.leftup.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.leftup.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####rightup
		for(int i=0;i<10; i++){
			int currentkey = key + 11 * (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				m_Main.rightup.Clear();
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.rightup.Count > 0){
					break;
				}else{
					m_Main.rightup.Clear();
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.rightup.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
		//####downline
		for(int i=0;i<10; i++){
			int currentkey = key - 10 * (i + 1);
			int value = m_Main.board[currentkey];
			if(value == 0 || value == 2){
				break;
			}else if(value == m_Main.current_turn){
				if(m_Main.downline.Count > 0){
					break;
				}else{
					break;
				}
			}else if(value == m_Main.current_turn*-1){
				m_Main.downline.Add(currentkey);
				Debug.Log("added key:" + currentkey);
			}else{
				Debug.Log("reverse check value error");
			}
		}
	}
}

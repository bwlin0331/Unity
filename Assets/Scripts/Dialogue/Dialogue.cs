using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	private GameObject triggeringNpc;
	private bool triggering;

	public GameObject npcText;
	public Text changeText;

	void Start(){

	}

	void Update(){
		if (triggering) {
			//print ("Player is triggering with " + triggeringNpc);
			npcText.SetActive (true);
			if(Input.GetKeyDown(KeyCode.T)){
				changeText.text = "Hello hero! Follow me! A mother needs help!";
			}
		} else {
			npcText.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "NPC1") {
			triggering = true;
			triggeringNpc = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "NPC1") {
			triggering = false;
			triggeringNpc = null;
			changeText.text = "Press T to Talk";
		}
	}

}

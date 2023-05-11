using UnityEngine;
using System.Collections;

public class ani_attack: MonoBehaviour {
	
	
	void OnMouseDown() {
//		GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
		ani_run.animator.SetInteger ("stateID",2);
				
	}
	
	void OnMouseUp() {
//		GetComponent<GUITexture>().color = new Color(0.5f,0.5f,0.5f,0.5f);
		ani_run.animator.SetInteger ("stateID",0);
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

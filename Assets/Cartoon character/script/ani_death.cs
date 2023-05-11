using UnityEngine;
using System.Collections;

public class ani_death: MonoBehaviour {
	
	
	void OnMouseDown() {
	//	GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
		ani_run.animator.SetInteger ("stateID",4);
				
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

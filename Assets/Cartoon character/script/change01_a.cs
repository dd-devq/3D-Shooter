using UnityEngine;
using System.Collections;

public class change01_a : MonoBehaviour {
	
	void OnMouseDown() {
//		GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
		playersite.id01++;
		if (playersite.id01 >= 10) {
			playersite.id01 = 0;
		}
				
	}
	
	void OnMouseUp() {
//		GetComponent<GUITexture>().color = new Color(0.5f,0.5f,0.5f,0.5f);
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

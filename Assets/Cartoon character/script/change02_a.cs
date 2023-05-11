using UnityEngine;
using System.Collections;

public class change02_a : MonoBehaviour {
	
	void OnMouseDown() {
//		GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
		playersite.id02++;
		if (playersite.id02 >= 10) {
			playersite.id02 = 0;
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

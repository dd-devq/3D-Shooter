using UnityEngine;
using System.Collections;

public class rotate01 : MonoBehaviour {

    void OnMouseDown()
    {
        zombiesite.rotate = 1;
		playersite.rotate = 1;
//		GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
				
	}
	
	void OnMouseUp() {
        zombiesite.rotate = 0;
		playersite.rotate = 0;
//		GetComponent<GUITexture>().color = new Color(0.71f,0.71f,0.71f,0.5f);
				
	}
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

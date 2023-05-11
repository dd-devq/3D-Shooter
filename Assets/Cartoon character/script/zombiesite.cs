using UnityEngine;
using System.Collections;

public class zombiesite : MonoBehaviour
{
	public static int						rotate;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Vector3.up * rotate);
	
	}
}

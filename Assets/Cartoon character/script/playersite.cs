using UnityEngine;
using System.Collections;

public class playersite: MonoBehaviour {
	public Transform 						bip01weapon;
	public GameObject[]						weapon;
	GameObject								newWeapon;
	public GameObject						body;
	public Texture[]						skin;
	public static int						id01;
	int										id01_b;
	public static int						id02;
	int										id02_b;
	public static float						rotate = 0.5f;
	public Animator animator;
	// Use this for initialization
	void Start () {
		id01 = 0;
		id02 = 0;
		newWeapon = Instantiate(weapon[0], bip01weapon.transform.position, bip01weapon.transform.rotation) as GameObject;
		newWeapon.transform.parent = bip01weapon.transform;
		body.GetComponent<Renderer>().material.mainTexture = skin[0];
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (id01 != id01_b) {
			Destroy (newWeapon);
			newWeapon = Instantiate(weapon[id01],bip01weapon.transform.position,bip01weapon.transform.rotation) as GameObject;
			newWeapon.transform.parent = bip01weapon.transform;
			id01_b = id01;
		}
		if (id02 != id02_b) {
			body.GetComponent<Renderer>().material.mainTexture = skin[id02];
			id02_b = id02;
		}
		gameObject.transform.Rotate(Vector3.up * rotate);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			id01++;
			if (id01 == weapon.Length)
			{
				id01 = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			id02++;
			if (id02 == skin.Length)
			{
				id02 = 0;
			}
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			animator.SetInteger("stateID", 1);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			animator.SetInteger("stateID", 2);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			animator.SetInteger("stateID", 3);
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			animator.SetInteger("stateID", 4);
		}

		if (Input.GetKeyDown(KeyCode.R))
        {
			animator.SetInteger("stateID", 0);
		}
	}
}

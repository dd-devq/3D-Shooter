using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	public GameObject[] 						player;
	GameObject 									newPlayer;
	int											        playerId = 1;
    //public GUITexture                            weaponA,weaponB,weaponC,skinA,skinB,skinC,deathB,combat;
    public Camera                                  mainCamera;
	
	void OnMouseDown() {
		//GetComponent<GUITexture>().color = new Color(1f,1f,1f,0.5f);
		Destroy (newPlayer);
		newPlayer = Instantiate(player[playerId], player[playerId].transform.position, player[playerId].transform.rotation) as GameObject;
		playerId++;
		ani_run.animator = newPlayer.GetComponent<Animator>();
        if (playerId >5)
        {
            mainCamera.backgroundColor = new Color(0.47f,0.407f,0.517f,0f);
            //weaponA.enabled = false;
            //weaponB.enabled = false;
            //weaponC.enabled = false;
            //skinA.enabled = false;
            //skinB.enabled = false;
            //skinC.enabled = false;
        }
        else
        {
            mainCamera.backgroundColor = new Color(0.431f, 0.498f, 0.552f, 0f);
            //weaponA.enabled = true;
            //weaponB.enabled = true;
            //weaponC.enabled = true;
            //skinA.enabled = true;
            //skinB.enabled = true;
            //skinC.enabled = true;
        }
        if (playerId == 6 || playerId == 7 || playerId == 8 || playerId == 12 || playerId == 13 || playerId == 14 || playerId == 18 || playerId == 19 || playerId == 20)
        {
            //deathB.enabled = true;
        }
        else
        {
            //deathB.enabled = false;
        }
        if (playerId == 11 || playerId == 17 || playerId == 23)
        {
            //combat.enabled = false;
        }
        else
        {
            //combat.enabled = true;
        }
        if (playerId >= 23)
        {
            playerId = 0;
        }
				
	}
	
	void OnMouseUp() {
		//GetComponent<GUITexture>().color = new Color(0.5f,0.5f,0.5f,0.5f);
		
	}

	// Use this for initialization
	void Start () {
		newPlayer = Instantiate(player[0], player[0].transform.position, player[0].transform.rotation) as GameObject;
        ani_run.animator = newPlayer.GetComponent<Animator>();
        //deathB.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

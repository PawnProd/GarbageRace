using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour {

    public MasterGameController masterGC;

	// Use this for initialization
	void Start () {
        masterGC = MasterGameController.Instance;
        SetupSplitScreen();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // On setup la vue en fonction du nombre de joueur
    public void SetupSplitScreen()
    {
        switch (masterGC.nbPlayer)
        {
            case 2:
                SetupTwoView();
                break;

            case 3:
                SetupThreeView();
                break;

            case 4:
                SetupFourView();
                break;
        }
    }


    // La vue à deux joueurs
    public void SetupTwoView()
    {
        Camera cam1 = masterGC.allPlayers[0].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam2 = masterGC.allPlayers[1].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();

        cam1.rect = new Rect(new Vector2(0, 0.5f), new Vector2(1f, 0.5f));
        cam2.rect = new Rect(new Vector2(0, 0), new Vector2(1f, 0.5f));

    }

    // La vue à trois joueurs
    public void SetupThreeView()
    {
        Camera cam1 = masterGC.allPlayers[0].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam2 = masterGC.allPlayers[1].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam3 = masterGC.allPlayers[2].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();

        cam1.rect = new Rect(new Vector2(0, 0.5f), new Vector2(0.5f, 0.5f));
        cam2.rect = new Rect(new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        cam3.rect = new Rect(new Vector2(0, 0f), new Vector2(0.5f, 0.5f));
    }

    // La vue à quatre joueurs
    public void SetupFourView()
    {
        Camera cam1 = masterGC.allPlayers[0].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam2 = masterGC.allPlayers[1].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam3 = masterGC.allPlayers[2].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();
        Camera cam4 = masterGC.allPlayers[3].GetComponent<PlayerController>().cameraPlayer.GetComponent<Camera>();

        cam1.rect = new Rect(new Vector2(0, 0.5f), new Vector2(0.5f, 0.5f));
        cam2.rect = new Rect(new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        cam3.rect = new Rect(new Vector2(0, 0f), new Vector2(0.5f, 0.5f));
        cam4.rect = new Rect(new Vector2(0.5f, 0f), new Vector2(0.5f, 0.5f));
    }
}

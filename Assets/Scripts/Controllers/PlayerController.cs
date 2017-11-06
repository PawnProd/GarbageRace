using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int numPlayer;
    public int numCheckpoint; 

    public GameObject nextCheckpoint;
    public GameObject arrow;

    public GamePadController gamepad;

    public enum PlayerState
    {
        VehiculeSelection,
        Standby,
        Freeze,
        Radioactif,
        Playing,
        Respawn
    };

    public PlayerState playerState;

    public GameObject cameraPlayer;

    private CarController _carController;

	// Use this for initialization
	void Start () {
        _carController = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update () {

        switch(playerState)
        {
            case PlayerState.VehiculeSelection:
                break;
            case PlayerState.Freeze:
                break;

            case PlayerState.Playing:
                Vector3 direction = nextCheckpoint.transform.position - arrow.transform.position;
                arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, Quaternion.LookRotation(direction), 5);
                break;

            case PlayerState.Respawn:
                break;
        } 
	}

    private void FixedUpdate()
    {
        if(playerState == PlayerState.Playing)
        {
            TriggerInGameAction();
        }
    }

    public void TriggerInGameAction()
    {
        float h;
        float v;
        float handbrake = 0;
        if(gamepad != null)
        {
            h = gamepad.GetAxisLeftX();
            v = gamepad.GetRightTrigger();
            if(gamepad.GetShoulderStateLeft("press") || gamepad.GetShoulderStateRight("press"))
            {
                handbrake = 1;
            }
        }
        else
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            handbrake = Input.GetAxis("Jump");

        }

        _carController.Move(h, v, v, handbrake);
    }

    public int GetNumCheckpoint()
    {
        return numCheckpoint;
    }

    /***********************************************
     *                  SETTERS
     **********************************************/
    public void SetNextCheckpoint(GameObject nextCP)
    {
        nextCheckpoint = nextCP;
    }

    public void SetNumCheckpoint(int num)
    {
        numCheckpoint = num;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public CheckpointController cpController;
    public bool lastCheckpoint = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.transform.parent.parent.GetComponent<PlayerController>();
            player.SetNextCheckpoint(cpController.GetCheckpointAt(player.GetNumCheckpoint() + 1));
        }
    }
}

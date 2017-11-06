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
            int numCheckpoint;

            if(lastCheckpoint)
            {
                print("Un tour !");
                numCheckpoint = 0;
            }
            else
            {
                numCheckpoint = player.GetNumCheckpoint() + 1;
            }

            player.SetNextCheckpoint(cpController.GetCheckpointAt(numCheckpoint));
            player.SetNumCheckpoint(numCheckpoint);
        }
    }
}

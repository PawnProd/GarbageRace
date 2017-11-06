using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public GameObject[] allCheckpoints;

	public GameObject GetCheckpointAt(int numCheckpoint)
    {
        return allCheckpoints[numCheckpoint];
    }
}

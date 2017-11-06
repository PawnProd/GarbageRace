using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitController : MonoBehaviour {

    public GameObject[] allCheckpoints;

	public GameObject GetCheckpointAt(int numCheckpoint)
    {
        return allCheckpoints[numCheckpoint];
    }
}

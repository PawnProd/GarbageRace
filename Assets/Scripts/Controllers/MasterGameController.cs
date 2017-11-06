using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGameController : MonoBehaviour {

    private static MasterGameController _instance;

    public static MasterGameController Instance
    {
        get { return _instance; }
    }

    public int nbPlayer;
    public PlayerController[] allPlayers;

    // Use this for initialization
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        DontDestroyOnLoad(this);
    }


    // Update is called once per frame
    void Update () {
		
	}
}

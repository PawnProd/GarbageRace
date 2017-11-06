using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class GamePadObserver : MonoBehaviour {

    public List<GamePadController> allConnectGamepad;
    public List<GameObject> connectEventList;
    public GameObject connectFeedback;
    public float delayShowFeedback = 5f;

    private float _timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(allConnectGamepad.Count < 4)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);

                if (testState.IsConnected && !AlreadyConnected(testPlayerIndex))
                {
                    CreateConnectFeedback(testPlayerIndex);
                    GameObject gamepadController = new GameObject("Gamepad" + i, typeof(GamePadController));
                    DontDestroyOnLoad(gamepadController);
                    gamepadController.GetComponent<GamePadController>()._playerIndex = testPlayerIndex;
                    gamepadController.GetComponent<GamePadController>()._state = testState;
                    gamepadController.GetComponent<GamePadController>().disconnectFeedback = connectFeedback;
                    allConnectGamepad.Add(gamepadController.GetComponent<GamePadController>());   
                }
            }
        }
        if(connectEventList.Count > 0)
        {
            _timer += Time.deltaTime;
            if(_timer >= delayShowFeedback)
            {
                GameObject objToDestroy = connectEventList[0];
                connectEventList.RemoveAt(0);
                Destroy(objToDestroy);
                _timer = 0;
            }
            else
            {
                connectEventList[0].SetActive(true);
            }
        }
    }

    public bool AlreadyConnected(PlayerIndex pIndex)
    {
        int i = 0;
        foreach(GamePadController gamepad in allConnectGamepad)
        {
            if(gamepad == null)
            {
                allConnectGamepad.RemoveAt(i);
            }
            else
            {
                if (gamepad._playerIndex == pIndex)
                {
                    return true;
                }
            }
            ++i;
        }

        return false;
    }

    public void CreateConnectFeedback(PlayerIndex numController)
    {
        GameObject feedback = Instantiate(connectFeedback);
        feedback.GetComponentInChildren<Text>().text = "Manette " + numController + " connectée !";
        connectEventList.Add(feedback);
    }
}

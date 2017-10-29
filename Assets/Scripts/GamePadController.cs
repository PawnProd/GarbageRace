using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class GamePadController : MonoBehaviour {

    public PlayerIndex _playerIndex;
    public GamePadState _state;
    public GamePadState prevState;

    public GameObject disconnectFeedback;
    public GameObject feedback;


    private float _timer = 0;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(!_state.IsConnected)
        {
            if(_timer == 0)
            {
                CreateDisconnectFeedback();
            }
            _timer += Time.deltaTime;
            if(_timer >= 3)
            {
                Destroy(feedback);
                Destroy(gameObject);
            }
        }
        else if (_state.IsConnected)
        {
            prevState = _state;
            _state = GamePad.GetState(_playerIndex);
        }

    }

    public void CreateDisconnectFeedback()
    {
        feedback = Instantiate(disconnectFeedback);
        feedback.GetComponentInChildren<Text>().text = "Manette " + _playerIndex + " déconnectée !";
        feedback.SetActive(true);
        
    }

    public bool GetButtonStateA(string buttonState)
    {
        if(buttonState == "press")
        {
            return prevState.Buttons.A == ButtonState.Released && _state.Buttons.A == ButtonState.Pressed;
        }
        else if(buttonState == "longpress")
        {
            return _state.Buttons.A == ButtonState.Pressed;
        }
        else if (buttonState == "release")
        {
            return prevState.Buttons.A == ButtonState.Pressed && _state.Buttons.A == ButtonState.Released;
        }
        else
        {
            return false;
        }
    }

    public bool GetButtonStateX(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.X == ButtonState.Released && _state.Buttons.X == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.X == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetButtonStateY(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.Y == ButtonState.Released && _state.Buttons.Y == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.Y == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetButtonStateB(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.B == ButtonState.Released && _state.Buttons.B == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.B == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetButtonStateStart(string buttonState)
    {
        if(buttonState == "press")
        {
            return prevState.Buttons.Start == ButtonState.Released && _state.Buttons.Start == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetButtonStateBack(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.Back == ButtonState.Released && _state.Buttons.Back == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetPadStateRight(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.DPad.Right == ButtonState.Released && _state.DPad.Right == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.DPad.Right == ButtonState.Pressed;
        }
        else
        {
            return false;
        }

    }

    public bool GetPadStateLeft(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.DPad.Left == ButtonState.Released && _state.DPad.Left == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.DPad.Left == ButtonState.Pressed;
        }
        else
        {
            return false;
        }

    }

    public float GetRightTrigger()
    {
        return _state.Triggers.Right;
    }

    public float GetLeftTrigger()
    {
        return _state.Triggers.Left;
    }


    public float GetAxisLeftX()
    {
        return _state.ThumbSticks.Left.X;
    }

    public bool GetStickStateLeft (string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.LeftStick == ButtonState.Released && _state.Buttons.LeftStick == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.LeftStick == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
    }

    public bool GetStickStateRight (string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.RightStick == ButtonState.Released && _state.Buttons.RightStick == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.RightStick == ButtonState.Pressed;
        }
        else if (buttonState == "release")
        {
            return prevState.Buttons.RightStick == ButtonState.Pressed && _state.Buttons.RightStick == ButtonState.Released;
        }
        else
        {
            return false;
        }
    }

    public bool GetShoulderStateLeft(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.LeftShoulder == ButtonState.Released && _state.Buttons.LeftShoulder == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.LeftShoulder == ButtonState.Pressed;
        }
        else if (buttonState == "release")
        {
            return _state.Buttons.LeftShoulder == ButtonState.Released;
        }
        else
        {
            return false;
        }
    }

    public bool GetShoulderStateRight(string buttonState)
    {
        if (buttonState == "press")
        {
            return prevState.Buttons.RightShoulder == ButtonState.Released && _state.Buttons.RightShoulder == ButtonState.Pressed;
        }
        else if (buttonState == "longpress")
        {
            return _state.Buttons.RightShoulder == ButtonState.Pressed;
        }
        else if (buttonState == "release")
        {
            return _state.Buttons.RightShoulder == ButtonState.Released;
        }
        else
        {
            return false;
        }
    }
}

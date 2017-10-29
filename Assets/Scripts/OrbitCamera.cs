using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

    public Transform camPos;
    public Transform camTarget;
    public Transform backPos;
    public Transform backTarget;

    public float distance;
    public float distanceMax;
    public float distanceMin;

    public float sensiblityX;
    public float sensiblityY;

    //public bool backView;

    public Vector3 velocity = Vector3.zero;

    private Transform _currentTarget;
    public Transform _currentPos;


    // Use this for initialization
    void Start () {

        _currentPos = camPos;
        _currentTarget = camTarget;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = Vector3.SmoothDamp(transform.position, _currentPos.position, ref velocity, 0.05f);
        transform.LookAt(_currentTarget);

	}

    public void SwitchView()
    {
        if (_currentPos == camPos)
        {
            print("switch to backView");
            _currentPos = backPos;
            _currentTarget = backTarget;
        }
        else
        {
            print("switch to frontView");
            _currentPos = camPos;
            _currentTarget = camTarget;
        }
    }
}

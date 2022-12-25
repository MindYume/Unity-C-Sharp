using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

namespace Maze
{
    public class Player : Unit
    {
        [SerializeField] Camera _Camera;
        [SerializeField] private float _CameraOffset = 10f;
        [SerializeField] private float _MouseSensitivity = 1000f;
        [SerializeField] private WinPopUp _WinPopUp;
        [SerializeField] private UserInterface _userInterface;

        private EventSystem _eventSystem;

        private Vector3 _CameraRotation = Vector3.zero;
        private int _winScore = 5;
        private int _score = 0;

        public int Score
        {
            get 
            {
                return _score;
            }

            set 
            {
                _score = value;
                _userInterface.SetScore(value);
            }
        }

        public override void Awake()
        {
            base.Awake();
            Health = 100;

            if(!GameObject.FindWithTag("EventSystem").TryGetComponent<EventSystem>(out _eventSystem))
            {
                Debug.Log("EventSysyem object not found or has no script!");
            }
            else
            {
                _eventSystem.WinBonusPick.AddListener(PickWinBonus);
            }
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                Vector3 moveVector = Quaternion.Euler(0, _CameraRotation.y, 0) * new Vector3(x, y, z);
                _rb.AddForce(moveVector);
            }
            
            try
            {
                float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _MouseSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _MouseSensitivity;
                _CameraRotation.x -= mouseY;
                _CameraRotation.y += mouseX;
                _CameraRotation.x = Mathf.Clamp(_CameraRotation.x, 0f, 90f);

                _Camera.transform.rotation = Quaternion.Euler(_CameraRotation.x, _CameraRotation.y, 0);
                _Camera.transform.position = transform.position - _Camera.transform.forward * _CameraOffset;
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }
        }

        public void PickWinBonus()
        {
            GetScore(1);
        }

        public void GetScore(int score)
        {
            _score += score;

            if (_userInterface != null)
            {
                _userInterface.SetScore(_score);
            }
            else
            {
                Debug.Log(
                    "User Interface sctirpt has not been assigned."+
                    "The state of the interface cannot be changed using the Player script."
                    );
            }

            if (_score >= _winScore)
            {
                if (_WinPopUp != null)
                {
                    _WinPopUp.Show();
                }
                else
                {
                    Debug.Log("Win Pop Up sctirpt has not been assigned");
                }
            }
        }
    }
}

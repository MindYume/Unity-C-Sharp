using System.Collections;
using System.Collections.Generic;
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

        private Vector3 _CameraRotation = Vector3.zero;
        private int _winScore = 5;
        private int _score = 0;

        public override void Awake()
        {
            base.Awake();
            Health = 100;
        }

        public override void Move(float x, float y, float z)
        {
            if (_rb)
            {
                Vector3 moveVector = Quaternion.Euler(0, _CameraRotation.y, 0) * new Vector3(x, y, z);
                _rb.AddForce(moveVector);
            }

            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _MouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _MouseSensitivity;
            _CameraRotation.x -= mouseY;
            _CameraRotation.y += mouseX;
            _CameraRotation.x = Mathf.Clamp(_CameraRotation.x, 0f, 90f);

            _Camera.transform.rotation = Quaternion.Euler(_CameraRotation.x, _CameraRotation.y, 0);
            _Camera.transform.position = transform.position - _Camera.transform.forward * _CameraOffset;
        }

        public void GetScore(int score)
        {
            _score += score;

            if (_userInterface != null)
            {
                _userInterface.SetScore(_score);
            }

            if (_score >= _winScore)
            {
                if (_WinPopUp != null)
                {
                    _WinPopUp.Show();
                }
            }
        }
    }
}

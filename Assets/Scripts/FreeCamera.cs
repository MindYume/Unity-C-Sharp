
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    [SerializeField] private float _Speed = 20f;
    [SerializeField] private float _MaxSpeed = 40f;
    [SerializeField] private float _MouseSensitivity = 1000f;

    private Camera _camera;
    private Vector3 _cameraRotation = Vector3.zero;

    void Start()
    {
        TryGetComponent<Camera>(out _camera);
        
    }

    void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector3 moveVector = transform.forward * inputVector.y + transform.right * inputVector.x;

        if (Input.GetKey(KeyCode.LeftShift))
            transform.position += moveVector * Time.deltaTime * _MaxSpeed;
        else
            transform.position += moveVector * Time.deltaTime * _Speed;

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _MouseSensitivity;
        _cameraRotation.x -= mouseY;
        _cameraRotation.y += mouseX;
        transform.rotation = Quaternion.Euler(_cameraRotation);
    }
}

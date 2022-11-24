using UnityEngine;

public class PlayerPrevious : MonoBehaviour
{
    [SerializeField] Camera _Camera;
    [SerializeField] private float _CameraOffset = 10f;
    [SerializeField] private float _MouseSensitivity = 1000f;
    [SerializeField] private float _Speed = 1000f;

    Rigidbody _rigidbody;

    private Vector3 _CameraRotation = Vector3.zero;

    void Start()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
    }

    void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector3 moveVector = Vector3.forward * inputVector.y + Vector3.right * inputVector.x;
        moveVector = Quaternion.Euler(0, _CameraRotation.y, 0) * moveVector;
        _rigidbody.AddForce(moveVector * Time.deltaTime * _Speed);


        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _MouseSensitivity;
        _CameraRotation.x -= mouseY;
        _CameraRotation.y += mouseX;
        _CameraRotation.x = Mathf.Clamp(_CameraRotation.x, 0f, 90f);

        _Camera.transform.rotation = Quaternion.Euler(_CameraRotation.x, _CameraRotation.y, 0);
        _Camera.transform.position = transform.position - _Camera.transform.forward * _CameraOffset;
        
    }
}

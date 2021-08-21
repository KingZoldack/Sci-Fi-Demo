using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    Transform _playerBody;

    [SerializeField]
    float _mouseSensitivity = 100f;

    float xRotation = 0f;

    bool _cursorIsLocked = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            _cursorIsLocked = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _cursorIsLocked = false;
        }

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}

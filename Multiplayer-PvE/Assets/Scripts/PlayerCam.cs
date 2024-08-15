using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Steamworks;
using UnityEngine.SceneManagement;
using System.Globalization;

public class PlayerCam : NetworkBehaviour
{
    public float mouseSensitivity = 300f;
    float initialMouseSensitivity;

    public Transform PlayerModel;

    float xRotation = 0f;

    void Start()
    {
        initialMouseSensitivity = mouseSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isOwned)
        {
            float mouseX = Input.GetAxis("Mouse X") * initialMouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * initialMouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            PlayerModel.Rotate(Vector3.up * mouseX);
        }
    }
}

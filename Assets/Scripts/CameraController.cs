using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform targetPlayer;

    [SerializeField]private float distance=5;
    [SerializeField]private float rotateSpeed = 5f;
    [SerializeField] private Vector2 framingOffet = new Vector2(0, 1);

    [SerializeField] private float minAngle = -10;
    [SerializeField] private float maxAngle = 20;

    [SerializeField] private bool invertX = true;
    [SerializeField] private bool invertY = true;

    private float insertValX;
    private float insertValY;

    private float rotateX;
    private float rotateY;

    [SerializeField] GameObject pauseScreen;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isShowPauseScreen = !pauseScreen.activeSelf;
            if (isShowPauseScreen)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseScreen.SetActive(isShowPauseScreen);
                Time.timeScale = 0; //freeze
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                pauseScreen.SetActive(isShowPauseScreen);
                Time.timeScale = 1;
            }
        }

        if (Time.timeScale == 0)
            return;

        rotateX += Input.GetAxis("Mouse Y");
        rotateY += Input.GetAxis("Mouse X");

        rotateX = Mathf.Clamp(rotateX,minAngle,maxAngle);

        var targetRotation = Quaternion.Euler(rotateX, rotateY, 0);
        var focusPosition = targetPlayer.position + new Vector3(framingOffet.x,framingOffet.y);

        
        transform.position = focusPosition - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }

    public Quaternion GetDirection
    {
        get
        { 
            return Quaternion.Euler(0,rotateY,0);
        }
    }
}

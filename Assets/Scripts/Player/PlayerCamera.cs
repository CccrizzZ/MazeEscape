using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCamera : MonoBehaviour
{
  
    public float MouseSensitivity;
    

    public bool canLook;

    public Transform CamTransform;
    PlayerMovement pmove;

    void Start()
    {
        pmove = GetComponent<PlayerMovement>();
        ResetCameraRot();
        SetCameraMove();
    }


    public void ResetCameraRot()
    {
        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        // XRotation = 0.0f;
    }


    public void SetCameraMove()
    {
        // lock cursor to the center of screen
        canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetCameraFreeze()
    {
        // dont lock cursor
        canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }


    void Update()
    {
    }

    




    void OnLook(InputValue input)
    {
        
        if (canLook)
        {

            // // set mouse input
            // float MouseX = input.Get<Vector2>().x * MouseSensitivity / 500;
            // float MouseY = input.Get<Vector2>().y * MouseSensitivity / 500;
            
            // XRotation += MouseX;
            // YRotation += MouseY;
            // YRotation += Mathf.Clamp(YRotation, -10.0f, 10.0f);
            

            // // // clamp rotation to +90 and -90 deg
            // XRotation -= MouseY;
            // XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

            // print(CamTransform.rotation.eulerAngles);

            // rotate player body
            // transform.localRotation = Quaternion.Euler(0.0f, XRotation, 0.0f);

            // if(pmove.InputVector.y > 0)
            // {
                transform.localRotation = Quaternion.Euler(0.0f,CamTransform.rotation.eulerAngles.y, 0.0f);

            // }


        }
    }


}

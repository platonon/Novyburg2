using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed;

    private Vector2 press_position;
    private Quaternion press_rotation;
    private bool pressed;

    void Update()
    {
        ControlSwipeRotation();
        ControlMousePress();
    }

    private void ControlSwipeRotation()
    {
        if (pressed)
        {
            Vector2 mouse_pos = Input.mousePosition;
            Vector2 difference = mouse_pos - press_position;
            Quaternion rot = press_rotation * Quaternion.Euler(-difference.y / 5.625f, 0, 0) * Quaternion.Euler(0, difference.x / 10, 0);
            Vector3 eulers = rot.eulerAngles;
            rot = Quaternion.Euler(eulers.x, eulers.y, 0);
            transform.localRotation = rot;
        }
    }

    private void ControlMousePress()
    {
        if (Input.GetMouseButtonDown(0))
            Press();
        else if (Input.GetMouseButtonUp(0))
            Release();
    }

    private void Press()
    {
        press_position = Input.mousePosition;
        press_rotation = transform.rotation;
        pressed = true;
    }

    private void Release()
    {
        pressed = false;
    }

}

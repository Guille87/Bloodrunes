using UnityEngine;

public class CursorMode : MonoBehaviour
{
    void Start()
    {
        SetLockMode(true); // Lock the cursor at the start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetLockMode(false); // Toggle cursor lock when Escape is pressed
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SetLockMode(true); // Unlock cursor when left mouse button is clicked
        }
    }

    void SetLockMode(bool isLocked)
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false; // Hide the cursor
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Show the cursor
        }
    }
}

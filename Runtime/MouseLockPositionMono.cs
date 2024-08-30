using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLockPositionMono : MonoBehaviour
{


    [ContextMenu("Lock")]
    public void Lock()
    {
        LockMousePosition(true);
    }
    [ContextMenu("Unlock")]
    public void Unlock()
    {
        LockMousePosition(false);
    }

    public void LockMousePosition(bool lockMouse)
    {
        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

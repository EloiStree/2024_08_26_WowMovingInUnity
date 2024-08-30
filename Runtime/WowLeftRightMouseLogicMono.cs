using System;
using UnityEngine;
using UnityEngine.Events;

public class WowLeftRightMouseLogicMono : MonoBehaviour { 

    public bool m_leftMouseIsDown = false;
    public bool m_rightMouseIsDown = false;

    public MouseState m_mouseState = MouseState.None;
    public MouseState m_previousState;


    public UnityEvent<bool> m_isBothDown;
    public UnityEvent<bool> m_isLeftDownOnly;
    public UnityEvent<bool> m_isRightDownOnly;
    public UnityEvent<bool> m_anyIsDown;
    public UnityEvent<bool> m_noneIsDown;


    public UnityEvent<bool> m_isInMouseInteractionMode;
    public UnityEvent<bool> m_isInCameraForwardMode;


    public enum MouseState
    {
        None,
        Left,
        Right,
        Both
    }

    public void SetLeftMouse(bool isDown)
    {
        m_leftMouseIsDown = isDown;
        Refresh();
        
    }

    private void Refresh()
    {
        m_mouseState = MouseState.None;
        if(m_leftMouseIsDown && m_rightMouseIsDown)
        {
            m_mouseState = MouseState.Both;
        }
        else if(m_leftMouseIsDown)
        {
            m_mouseState = MouseState.Left;
        }
        else if(m_rightMouseIsDown)
        {
            m_mouseState = MouseState.Right;
        }
        else 
        {
            m_mouseState = MouseState.None;
        }
        if(m_mouseState== m_previousState)
                    {
            return;
        }

        bool cameraMode = m_mouseState == MouseState.Right || m_mouseState == MouseState.Both;
        bool interactionMode = MouseState.None != m_mouseState;
        

        m_isInCameraForwardMode.Invoke(cameraMode);
        m_isInMouseInteractionMode.Invoke(interactionMode);

        if (m_mouseState == MouseState.Both)
        {
            m_isBothDown.Invoke(true);
            m_isLeftDownOnly.Invoke(false);
            m_isRightDownOnly.Invoke(false);
            m_anyIsDown.Invoke(true);
            m_noneIsDown.Invoke(false);
        }
        else if(m_mouseState== MouseState.Left) 
        { 
            m_isBothDown.Invoke(false);
            m_isLeftDownOnly.Invoke(true);
            m_isRightDownOnly.Invoke(false);
            m_anyIsDown.Invoke(true);
            m_noneIsDown.Invoke(false);

        }
        else if(m_mouseState == MouseState.Right)
        {
            m_isBothDown.Invoke(false);
            m_isLeftDownOnly.Invoke(false);
            m_isRightDownOnly.Invoke(true);
            m_anyIsDown.Invoke(true);
            m_noneIsDown.Invoke(false);
        
        }
        else if(m_mouseState == MouseState.None)
        {
            m_isBothDown.Invoke(false);
            m_isLeftDownOnly.Invoke(false);
            m_isRightDownOnly.Invoke(false);
            m_anyIsDown.Invoke(false);
            m_noneIsDown.Invoke(true);
        
        }
        




        m_previousState = m_mouseState;


    }

    public void SetRightMouse(bool isDown)
    {
        m_rightMouseIsDown = isDown;
        Refresh();

    }
}
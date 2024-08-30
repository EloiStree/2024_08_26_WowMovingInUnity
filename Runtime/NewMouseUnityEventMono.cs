using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class NewMouseUnityEventMono : MonoBehaviour
{

    public InputActionReference m_leftMouseInput;
    public InputActionReference m_rightMouseInput;
    public InputActionReference m_zoomInTick;
    public InputActionReference m_zoomOutTick;

    public InputActionReference m_screenPosition;

    public UnityEvent<bool> m_onLeftDown;
    public UnityEvent<bool> m_onRightDown;
    public UnityEvent<bool> m_onZoomIn;
    public UnityEvent<bool> m_onZoomOut;

    public UnityEvent<Vector2> m_onScreenPositionChanged;


    public void Awake()
    {
        m_leftMouseInput.action.Enable();
        m_rightMouseInput.action.Enable();
        m_zoomInTick.action.Enable();
        m_zoomOutTick.action.Enable();
        m_screenPosition.action.Enable();
           
    }

    public void OnEnable()
    {
        m_leftMouseInput.action.performed+= (context) => m_onLeftDown.Invoke(true);
        m_rightMouseInput.action.performed+= (context) => m_onRightDown.Invoke(true);
        m_leftMouseInput.action.canceled+= (context) => m_onLeftDown.Invoke(false);
        m_rightMouseInput.action.canceled+= (context) => m_onRightDown.Invoke(false);
        m_zoomInTick.action.performed+= (context) => m_onZoomIn.Invoke(true);
        m_zoomOutTick.action.performed+= (context) => m_onZoomOut.Invoke(true);
        m_zoomInTick.action.canceled+= (context) => m_onZoomIn.Invoke(false);
        m_zoomOutTick.action.canceled+= (context) => m_onZoomOut.Invoke(false);

        m_screenPosition.action.performed += (context) => m_onScreenPositionChanged.Invoke(context.ReadValue<Vector2>());
        m_screenPosition.action.canceled += (context) => m_onScreenPositionChanged.Invoke(context.ReadValue<Vector2>());



    }


    public void OnDisable()
    {
        m_leftMouseInput.action.performed -= (context) => m_onLeftDown.Invoke(true);
        m_rightMouseInput.action.performed -= (context) => m_onRightDown.Invoke(true);
        m_leftMouseInput.action.canceled -= (context) => m_onLeftDown.Invoke(false);
        m_rightMouseInput.action.canceled -= (context) => m_onRightDown.Invoke(false);

        m_zoomInTick.action.performed += (context) => m_onZoomIn.Invoke(true);
        m_zoomOutTick.action.performed += (context) => m_onZoomOut.Invoke(true);
        m_zoomInTick.action.canceled += (context) => m_onZoomIn.Invoke(false);
        m_zoomOutTick.action.canceled += (context) => m_onZoomOut.Invoke(false);
        m_screenPosition.action.performed -= (context) => m_onScreenPositionChanged.Invoke(context.ReadValue<Vector2>());
        m_screenPosition.action.canceled -= (context) => m_onScreenPositionChanged.Invoke(context.ReadValue<Vector2>());

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OldKeyboardUnityEventMono : MonoBehaviour
{

    public KeyCode m_forward= KeyCode.Z;
    public KeyCode m_back= KeyCode.S;
    public KeyCode m_left= KeyCode.Q;
    public KeyCode m_right= KeyCode.R;
    public KeyCode m_up= KeyCode.Space;
    public KeyCode m_down= KeyCode.C;
    public KeyCode m_strafeLeft= KeyCode.W;
    public KeyCode m_strafeRight= KeyCode.X;


    public bool m_forwardIsDown = false;
    public bool m_backIsDown = false;
    public bool m_leftIsDown = false;
    public bool m_rightIsDown = false;
    public bool m_upIsDown = false;
    public bool m_downIsDown = false;
    public bool m_strafeLeftIsDown = false;
    public bool m_strafeRightIsDown = false;


    public UnityEvent<bool> m_isForwardDown;
    public UnityEvent<bool> m_isBackDown;
    public UnityEvent<bool> m_isLeftDown;
    public UnityEvent<bool> m_isRightDown;
    public UnityEvent<bool> m_isUpDown;
    public UnityEvent<bool> m_isDownDown;
    public UnityEvent<bool> m_isStrafeLeftDown;
    public UnityEvent<bool> m_isStrafeRightDown;


    public void Update()
    {
        if(!this.isActiveAndEnabled)
        {
            return;
        }
        bool value = false;
        value = Input.GetKey(m_left);
        if (m_leftIsDown != value)
        {
            m_leftIsDown = value;
            m_isLeftDown.Invoke(m_leftIsDown);
        }
        value = Input.GetKey(m_right);
        if (m_rightIsDown != value)
        {
            m_rightIsDown = value;
            m_isRightDown.Invoke(m_rightIsDown);
        }
        value = Input.GetKey(m_up);
        if (m_upIsDown != value)
        {
            m_upIsDown = value;
            m_isUpDown.Invoke(m_upIsDown);
        }
        value = Input.GetKey(m_down);
        if (m_downIsDown != value)
        {
            m_downIsDown = value;
            m_isDownDown.Invoke(m_downIsDown);
        }
        value = Input.GetKey(m_strafeLeft);
        if (m_strafeLeftIsDown != value)
        {
            m_strafeLeftIsDown = value;
            m_isStrafeLeftDown.Invoke(m_strafeLeftIsDown);
        }
        value = Input.GetKey(m_strafeRight);
        if (m_strafeRightIsDown != value)
        {
            m_strafeRightIsDown = value;
            m_isStrafeRightDown.Invoke(m_strafeRightIsDown);
        }
        value = Input.GetKey(m_forward);
        if (m_forwardIsDown != value)
        {
            m_forwardIsDown = value;
            m_isForwardDown.Invoke(m_forwardIsDown);
        }
        value = Input.GetKey(m_back);
        if (m_backIsDown != value)
        {
            m_backIsDown = value;
            m_isBackDown.Invoke(m_backIsDown);
        }

        
    }
}




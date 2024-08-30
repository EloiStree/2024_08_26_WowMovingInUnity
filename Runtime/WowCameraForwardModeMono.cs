using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WowCameraForwardModeMono : MonoBehaviour
{

    public bool m_isInCameraForwardMode = false;

    public UnityEvent<bool> m_onCameraModeChanged;
    public UnityEvent m_onExitMode;
    public UnityEvent m_onEnterMode;

    public void SetAsCameraForwardMode(bool isCameraForwardMode)
    {
        bool changed = m_isInCameraForwardMode != isCameraForwardMode;
        m_isInCameraForwardMode = isCameraForwardMode;
        if (changed)
        {
            m_onCameraModeChanged.Invoke(m_isInCameraForwardMode);
            if (m_isInCameraForwardMode)
            {
                m_onEnterMode.Invoke();
            }
            else
            {
                m_onExitMode.Invoke();
            }
        }

    }   

}

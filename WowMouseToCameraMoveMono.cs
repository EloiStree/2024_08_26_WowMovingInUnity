using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WowMouseToCameraMoveMono : MonoBehaviour
{

    public bool m_isInteracting = false;
    public Vector2 m_screenPositionStart;
    public Vector2 m_currentScreenPosition;
    public Vector2 m_previousScreenPosition;
    public Vector2 m_delta;

    public float m_angleHorizontalPerPixel = 10;
    public float m_angleVerticalPerPixel = 10;


    public bool m_inverserHorizontal = false;
    public bool m_inverserVertical = true;


    public UnityEvent<float> m_angleToAddHorizontal;
    public UnityEvent<float> m_angleToAddVertical;

    public void SetAsInteracting(bool isInteracting)
    {
        m_isInteracting = isInteracting;
        if (m_isInteracting)
        {
            m_previousScreenPosition = m_currentScreenPosition;
        }
        
    }

    public void SetCurrentPositoin(Vector2 position)
    {
        m_currentScreenPosition = position;
    }


    void Update()
    {
        bool hasChange = m_previousScreenPosition.x!= m_currentScreenPosition.x || m_previousScreenPosition.y != m_currentScreenPosition.y;
        m_delta = m_currentScreenPosition - m_previousScreenPosition;
        if (m_isInteracting && hasChange)
        { 
            float angleHorizontal = (m_delta.x) * m_angleHorizontalPerPixel;
            float angleVertical = (m_delta.y) * m_angleVerticalPerPixel;
            if (m_inverserHorizontal)
            {
                angleHorizontal = -angleHorizontal;
            }
            if (m_inverserVertical)
            {
                angleVertical = -angleVertical;
            }
            m_angleToAddHorizontal.Invoke(angleHorizontal);
            m_angleToAddVertical.Invoke(angleVertical);
            m_previousScreenPosition = m_currentScreenPosition;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class OldMouseUnityEventMono : MonoBehaviour
{

    public UnityEvent<bool> m_isMouseLeftDown;
    public UnityEvent<bool> m_isMouseRightDown;

    public UnityEvent<Vector2> m_screenPosition;

    public bool m_mouseStateLeft = false;
    public bool m_mouseStateRight = false;

    public Vector2 m_screenPositionValue;

    void Update()
    {
        bool mouseLeft= Input.GetMouseButton(0);
        bool mouseRight = Input.GetMouseButton(1);

        if(m_mouseStateLeft != mouseLeft)
        {
            m_mouseStateLeft = mouseLeft;
            m_isMouseLeftDown.Invoke(m_mouseStateLeft);
        }
        if(m_mouseStateRight != mouseRight)
        {
            m_mouseStateRight = mouseRight;
            m_isMouseRightDown.Invoke(m_mouseStateRight);
        }

        
        m_screenPositionValue = Input.mousePosition;
        if (!Application.isEditor && Application.platform == RuntimePlatform.Android) { 
            if(isActiveAndEnabled)
            {
                m_screenPositionValue = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
            }
            else {
                m_screenPositionValue = new Vector2(0,0);
            }
        }
        m_screenPosition.Invoke(m_screenPositionValue);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WowMovingLogicClassicFlyMono : MonoBehaviour
{

    public Transform m_whatToMove;
    public Transform m_cameraPositionToUse;
    public bool m_useCameraForwardMode;
    public float m_horizontalRotationAngleSpeed = 180;
    public float m_strafeMeterPerSecond = 1;
    public float m_forwardMeterPerSecond = 1;
    public float m_upMeterPerSecond = 1;
    public float m_downMeterPerSecond = 1;
    public float m_backwardMeterPerSecond = 1;

    public Vector3 m_lastDirection;
    public bool m_rotateLeftKey = false;
    public bool m_rotateRightKey = false;
    public bool m_strafeLeftKey = false;
    public bool m_strafeRightKey = false;
    public bool m_forwardKey = false;
    public bool m_backwardKey = false;
    public bool m_upKey = false;
    public bool m_downKey = false;


    public float m_horizontalRotationAngle;
    public float m_verticalRotationAngle;



    public void SetRotateLeftKey(bool isDown)
    {
        m_rotateLeftKey = isDown;
    }
    public void SetRotateRightKey(bool isDown)
    {
        m_rotateRightKey = isDown;
    }
    public void SetStrafeLeftKey(bool isDown)
    {
        m_strafeLeftKey = isDown;
    }
    public void SetStrafeRightKey(bool isDown)
    {
        m_strafeRightKey = isDown;
    }
    public void SetForwardKey(bool isDown)
    {
        m_forwardKey = isDown;
    }

    public void SetBackwardKey(bool isDown)
    {
        m_backwardKey = isDown;
    }
    public void SetUpKey(bool isDown)
    {
        m_upKey = isDown;
    }
    public void SetDownKey(bool isDown)
    {
        m_downKey = isDown;
    }



    public void SetCameraForwardMode(bool useCameraMode)
    {
        m_useCameraForwardMode = useCameraMode;
    }

    void LateUpdate()
    {
        if (m_useCameraForwardMode)
        {
            Vector3 f = m_whatToMove.position - m_cameraPositionToUse.position;
            f.Normalize();
            Vector3 flatOnHorizontal = new Vector3(f.x, 0, f.z);   
            
            float angle = Vector3.SignedAngle(Vector3.forward, flatOnHorizontal, Vector3.up);
            m_horizontalRotationAngle = angle; 

            Vector3 rAxis= Vector3.Cross(Vector3.up, f);
            float angleVertical = Vector3.SignedAngle(flatOnHorizontal, f, rAxis);
            m_verticalRotationAngle = angleVertical;
        }
        Vector3 foward = m_whatToMove.forward;
        Vector3 right = Vector3.Cross(Vector3.up, foward);
        right.Normalize();





        if (m_forwardKey && m_strafeLeftKey)
        {}
        else if(m_forwardKey)
        {
            m_whatToMove.position += foward * m_forwardMeterPerSecond * Time.deltaTime;
        }
        else if (m_backwardKey)
        {
            m_whatToMove.position -= foward * m_backwardMeterPerSecond * Time.deltaTime;
        }

        if (m_strafeLeftKey && m_strafeRightKey)
        {}
        else if (m_strafeLeftKey)
        {
            m_whatToMove.position -= right * m_strafeMeterPerSecond * Time.deltaTime;
        }
        else if (m_strafeRightKey)
        {
            m_whatToMove.position += right * m_strafeMeterPerSecond * Time.deltaTime;
        }

        if (m_upKey && m_downKey)
        {}
        else if (m_upKey)
        {
            m_whatToMove.position += Vector3.up * m_upMeterPerSecond * Time.deltaTime;
        }
        else if (m_downKey)
        {
            m_whatToMove.position -= Vector3.up * m_downMeterPerSecond * Time.deltaTime;
        }

        if (m_rotateLeftKey && m_rotateRightKey)
        {}
        else if (m_rotateLeftKey)
        {
            m_horizontalRotationAngle -= m_horizontalRotationAngleSpeed * Time.deltaTime;
        }
        else if (m_rotateRightKey)
        {
            m_horizontalRotationAngle += m_horizontalRotationAngleSpeed * Time.deltaTime;
        }

        m_verticalRotationAngle = Mathf.Clamp(m_verticalRotationAngle, -89, 89);
        m_whatToMove.rotation = Quaternion.Euler(m_verticalRotationAngle,m_horizontalRotationAngle, 0);

    }
}

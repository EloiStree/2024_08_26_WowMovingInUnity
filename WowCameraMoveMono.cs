using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WowCameraMoveMono : MonoBehaviour
{


    public Transform m_objectToLookAt;
    public Transform m_cameraToMove;

    public float m_distanceMinimum = 0.1f;
    public float m_distanceMaximum = 10f;
    [Range(0,1f)]
    public float m_percentDistance = 0.5f;

    [Range(0,360)]
    public float m_horizontalRotationAngle0To360 = 360;

    [Range(-89,89)]
    public float m_verticalRotationAngleLess90To90 = 89;

    public bool m_isCameraForwardMode = false;

    public void SetCameraForwardMode(bool isFlying)
    {
        m_isCameraForwardMode = isFlying;
    }

    public void Update()
    {
        Refresh();
    }



    public void ApplyCameraModeOriantationAsNewValue() {
       

    }

    public void Refresh()
    {

        if(m_objectToLookAt == null || m_cameraToMove == null)
        {
            return;
        }

        if(m_previousCameraModeState != m_isCameraForwardMode)
        {
            if(!m_isCameraForwardMode)
            {
                m_horizontalRotationAngle0To360 = m_previousCameraForwardModeHorizontalAngle;
                m_verticalRotationAngleLess90To90 = m_previousCameraForwardModeVerticalAngle;
                float angle = GetPlayerHorizontalFlatNgle();
                m_horizontalRotationAngle0To360 -= angle;
            }
        }


        Vector3 direction = m_cameraToMove.position - m_objectToLookAt.position;
        direction.Normalize();
        m_cameraToMove.forward= direction;
        float distance = Mathf.Lerp(m_distanceMinimum, m_distanceMaximum, m_percentDistance);
        m_cameraToMove.position = m_objectToLookAt.position;
        Vector3 localPostion = Vector3.zero;
        m_verticalRotationAngleLess90To90 = Mathf.Clamp(m_verticalRotationAngleLess90To90, -89 ,89);

        if (Math.Abs(m_horizontalRotationAngle0To360) > 360)
        {
            m_horizontalRotationAngle0To360 = m_horizontalRotationAngle0To360 % 360;
        }

        if(m_horizontalRotationAngle0To360 < 0)
        {
            m_horizontalRotationAngle0To360 += 360;
        }
        else if(m_horizontalRotationAngle0To360 > 360)
        {
            m_horizontalRotationAngle0To360 -= 360;
        }
        

        float horizontalAngle = m_horizontalRotationAngle0To360;
        if( !m_isCameraForwardMode)
        {
            float angle = GetPlayerHorizontalFlatNgle();
            horizontalAngle += angle;
        }

        m_previousCameraForwardModeVerticalAngle = m_verticalRotationAngleLess90To90;
        m_previousCameraForwardModeHorizontalAngle = horizontalAngle;
        Quaternion rotation = Quaternion.Euler(m_verticalRotationAngleLess90To90, horizontalAngle, 0);
        
        localPostion = rotation * Vector3.forward * -distance;

        m_cameraToMove.position = m_objectToLookAt.position + localPostion;
        m_cameraToMove.LookAt(m_objectToLookAt);

      
        m_previousCameraModeState = m_isCameraForwardMode;
        
    }

    private float GetPlayerHorizontalFlatNgle()
    {
        Vector3 forward = m_objectToLookAt.forward;
        forward.y = 0;
        forward.Normalize();
        float angle = Vector3.SignedAngle(Vector3.forward, forward, Vector3.up);
        return angle;
    }

    public float m_previousCameraForwardModeHorizontalAngle = 0;
    public float m_previousCameraForwardModeVerticalAngle = 0;

    public bool m_previousCameraModeState = false;


    public void AddHorizontalAngle(float angle)
    {
        m_horizontalRotationAngle0To360 += angle;
        Refresh();
    }

    public void AddVerticalAngle(float angle)
    {
        m_verticalRotationAngleLess90To90 += angle;
        Refresh();
    }


    private void OnValidate()
    {
        Refresh();
    }




}

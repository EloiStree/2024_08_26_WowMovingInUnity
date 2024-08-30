using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToWowMovingLogicFlyMono : MonoBehaviour
{

    public WowMovingLogicClassicFlyMono m_movingLogicFly;

    public AbstractWowMoveInputMono m_input;
    public AbstractWowMoveInput m_previousInput;

    public void Update()
    {
        if (!this.isActiveAndEnabled)
        {
            return;
        }

        if(m_input.GetMoveForward()!= m_previousInput.GetMoveForward())
        {
            m_movingLogicFly.SetForwardKey(m_input.GetMoveForward());

        }   
        if(m_input.GetMoveBack()!= m_previousInput.GetMoveBack())
        {
            m_movingLogicFly.SetBackwardKey(m_input.GetMoveBack());
        }
        if(m_input.GetRotateLeft()!= m_previousInput.GetRotateLeft())
        {
            m_movingLogicFly.SetRotateLeftKey(m_input.GetRotateLeft());
        }
        if(m_input.GetRotateRight()!= m_previousInput.GetRotateRight())
        {
            m_movingLogicFly.SetRotateRightKey(m_input.GetRotateRight());
        }
        if(m_input.GetMoveUp()!= m_previousInput.GetMoveUp())
        {
            m_movingLogicFly.SetUpKey(m_input.GetMoveUp());
        }
        if(m_input.GetMoveDown()!= m_previousInput.GetMoveDown())
        {
            m_movingLogicFly.SetDownKey(m_input.GetMoveDown());
        }
        if(m_input.GetStrafeLeft()!= m_previousInput.GetStrafeLeft())
        {
            m_movingLogicFly.SetStrafeLeftKey(m_input.GetStrafeLeft());
        }
        if(m_input.GetStrafeRight()!= m_previousInput.GetStrafeRight())
        {
            m_movingLogicFly.SetStrafeRightKey(m_input.GetStrafeRight());
        }

        if(m_input.GetRotateUp()!= m_previousInput.GetRotateUp())
        {
            m_movingLogicFly.SetRotateUpKey(m_input.GetRotateUp());
        }
        if(m_input.GetRotateDown()!= m_previousInput.GetRotateDown())
        {
            m_movingLogicFly.SetRotateDownKey(m_input.GetRotateDown());
        }


        m_previousInput.SetWith(m_input);
    }
}

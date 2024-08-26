using System;
using UnityEngine;
using UnityEngine.Events;


public interface I_WowMoveInputSet { 

    void SetMoveForward(bool value);
    void SetMoveBack(bool value);
    void SetRotateLeft(bool value);
    void SetRotateRight(bool value);
    void SetMoveUp(bool value);
    void SetMoveDown(bool value);
    void SetStrafeLeft(bool value);
    void SetStrafeRight(bool value);
    void SetWith(I_WowMoveInputGet input);
}

public interface I_WowMoveInputGet
{
    bool GetMoveForward();
    bool GetMoveBack();
    bool GetRotateLeft();
    bool GetRotateRight();
    bool GetMoveUp();
    bool GetMoveDown();
    bool GetStrafeLeft();
    bool GetStrafeRight();
}

public interface I_WowMoveInput : I_WowMoveInputSet, I_WowMoveInputGet
{
}




public class AbstractWowMoveInputMono : MonoBehaviour, I_WowMoveInput {

    public AbstractWowMoveInput m_inputState;

    public bool GetMoveBack()
    {
        return ((I_WowMoveInputGet)m_inputState).GetMoveBack();
    }

    public bool GetMoveDown()
    {
        return ((I_WowMoveInputGet)m_inputState).GetMoveDown();
    }

    public bool GetMoveForward()
    {
        return ((I_WowMoveInputGet)m_inputState).GetMoveForward();
    }

    public bool GetMoveUp()
    {
        return ((I_WowMoveInputGet)m_inputState).GetMoveUp();
    }

    public bool GetRotateLeft()
    {
        return ((I_WowMoveInputGet)m_inputState).GetRotateLeft();
    }

    public bool GetRotateRight()
    {
        return ((I_WowMoveInputGet)m_inputState).GetRotateRight();
    }

    public bool GetStrafeLeft()
    {
        return ((I_WowMoveInputGet)m_inputState).GetStrafeLeft();
    }

    public bool GetStrafeRight()
    {
        return ((I_WowMoveInputGet)m_inputState).GetStrafeRight();
    }

    public void SetMoveBack(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetMoveBack(value);
    }

    public void SetMoveDown(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetMoveDown(value);
    }

    public void SetMoveForward(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetMoveForward(value);
    }

    public void SetMoveUp(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetMoveUp(value);
    }

    public void SetRotateLeft(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetRotateLeft(value);
    }

    public void SetRotateRight(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetRotateRight(value);
    }

    public void SetStrafeLeft(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetStrafeLeft(value);
    }

    public void SetStrafeRight(bool value)
    {
        ((I_WowMoveInputSet)m_inputState).SetStrafeRight(value);
    }

    public void SetWith(I_WowMoveInputGet input)
    {
        ((I_WowMoveInputSet)m_inputState).SetWith(input);
    }
}

[System.Serializable]
public class AbstractWowMoveInput: I_WowMoveInput
{
    public bool m_moveForwardIsDown = false;
    public bool m_moveBackIsDown = false;
    public bool m_rotateLeftIsDown = false;
    public bool m_rotateRightIsDown = false;
    public bool m_moveUpIsDown = false;
    public bool m_moveDownIsDown = false;
    public bool m_strafeLeftIsDown = false;
    public bool m_strafeRightIsDown = false;

    public void SetMoveForward(bool value)
    {
        m_moveForwardIsDown = value;
    }
    public void SetMoveBack(bool value)
    {
        m_moveBackIsDown = value;
    }
    public void SetRotateLeft(bool value)
    {
        m_rotateLeftIsDown = value;
    }
    public void SetRotateRight(bool value)
    {
        m_rotateRightIsDown = value;
    }
    public void SetMoveUp(bool value)
    {
        m_moveUpIsDown = value;
    }
    public void SetMoveDown(bool value)
    {
        m_moveDownIsDown = value;
    }
    public void SetStrafeLeft(bool value)
    {
        m_strafeLeftIsDown = value;
    }
    public void SetStrafeRight(bool value)
    {
        m_strafeRightIsDown = value;
    }

    public bool GetMoveForward()
    {
        return m_moveForwardIsDown;
    }
    public bool GetMoveBack()
    {
        return m_moveBackIsDown;
    }
    public bool GetRotateLeft()
    {
        return m_rotateLeftIsDown;
    }
    public bool GetRotateRight()
    {
        return m_rotateRightIsDown;
    }
    public bool GetMoveUp()
    {
        return m_moveUpIsDown;
    }
    public bool GetMoveDown()
    {
        return m_moveDownIsDown;
    }
    public bool GetStrafeLeft()
    {
        return m_strafeLeftIsDown;
    }
    public bool GetStrafeRight()
    {
        return m_strafeRightIsDown;
    }

    public void SetWith(I_WowMoveInputGet input)
    {
        m_moveForwardIsDown = input.GetMoveForward();
        m_moveBackIsDown = input.GetMoveBack();
        m_rotateLeftIsDown = input.GetRotateLeft();
        m_rotateRightIsDown = input.GetRotateRight();
        m_moveUpIsDown = input.GetMoveUp();
        m_moveDownIsDown = input.GetMoveDown();
        m_strafeLeftIsDown = input.GetStrafeLeft();
        m_strafeRightIsDown = input.GetStrafeRight();
    }
}


public class WowMoveInputAnchorMono : AbstractWowMoveInputMono
{

    public UnityEngine.InputSystem.InputActionReference m_moveForward;
    public UnityEngine.InputSystem.InputActionReference m_moveBack       ;
    public UnityEngine.InputSystem.InputActionReference m_rotateLeft       ;
    public UnityEngine.InputSystem.InputActionReference m_rotateRight      ;
    public UnityEngine.InputSystem.InputActionReference m_moveUp         ;
    public UnityEngine.InputSystem.InputActionReference m_moveDown       ;
    public UnityEngine.InputSystem.InputActionReference m_strafeLeft ;
    public UnityEngine.InputSystem.InputActionReference m_strafeRight;

    

    public UnityEvent<bool> m_isMovingForward;
    public UnityEvent<bool> m_isMovingBack;
    public UnityEvent<bool> m_isRotatingLeft;
    public UnityEvent<bool> m_isRotatingRight;
    public UnityEvent<bool> m_isMovingUp;
    public UnityEvent<bool> m_isMovingDown;
    public UnityEvent<bool> m_isStrafeLeft;
    public UnityEvent<bool> m_isStrafeRight;


    private void OnEnable()
    {
        m_moveForward.action.Enable();
        m_moveBack.action.Enable();
        m_rotateLeft.action.Enable();
        m_rotateRight.action.Enable();
        m_moveUp.action.Enable();
        m_moveDown.action.Enable();
        m_strafeLeft.action.Enable();
        m_strafeRight.action.Enable();

        m_moveForward.action.performed += ctx => SetMoveForward(true);
        m_moveForward.action.canceled += ctx => SetMoveForward(false);
        m_moveBack.action.performed += ctx => SetMoveBack(true);
        m_moveBack.action.canceled += ctx => SetMoveBack(false);
        m_rotateLeft.action.performed += ctx => SetRotateLeft(true);
        m_rotateLeft.action.canceled += ctx => SetRotateLeft(false);
        m_rotateRight.action.performed += ctx => SetRotateRight(true);
        m_rotateRight.action.canceled += ctx => SetRotateRight(false);
        m_moveUp.action.performed += ctx => SetMoveUp(true);
        m_moveUp.action.canceled += ctx => SetMoveUp(false);
        m_moveDown.action.performed += ctx => SetMoveDown(true);
        m_moveDown.action.canceled += ctx => SetMoveDown(false);
        m_strafeLeft.action.performed += ctx => SetStrafeLeft(true);
        m_strafeLeft.action.canceled += ctx => SetStrafeLeft(false);
        m_strafeRight.action.performed += ctx => SetStrafeRight(true);
        m_strafeRight.action.canceled += ctx => SetStrafeRight(false);

    }

    private void OnDisable()
    {
      

        m_moveForward.action.performed -= ctx => SetMoveForward(true);
        m_moveForward.action.canceled -= ctx => SetMoveForward(false);
        m_moveBack.action.performed -= ctx => SetMoveBack(true);
        m_moveBack.action.canceled -= ctx => SetMoveBack(false);
        m_rotateLeft.action.performed -= ctx => SetRotateLeft(true);
        m_rotateLeft.action.canceled -= ctx => SetRotateLeft(false);
        m_rotateRight.action.performed -= ctx => SetRotateRight(true);
        m_rotateRight.action.canceled -= ctx => SetRotateRight(false);
        m_moveUp.action.performed -= ctx => SetMoveUp(true);
        m_moveUp.action.canceled -= ctx => SetMoveUp(false);
        m_moveDown.action.performed -= ctx => SetMoveDown(true);
        m_moveDown.action.canceled -= ctx => SetMoveDown(false);
        m_strafeLeft.action.performed -= ctx => SetStrafeLeft(true);
        m_strafeLeft.action.canceled -= ctx => SetStrafeLeft(false);
        m_strafeRight.action.performed -= ctx => SetStrafeRight(true);
        m_strafeRight.action.canceled -= ctx => SetStrafeRight(false);


    }


}




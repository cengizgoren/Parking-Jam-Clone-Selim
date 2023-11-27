using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    private Vector3 _lastFrameFingerPositionX;
    private Vector3 _moveFactorX;

    public Vector3 MoveFactorX { get => _moveFactorX; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = Vector3.zero;
        }
    }

}

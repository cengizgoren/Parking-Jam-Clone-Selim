using DG.Tweening;
using UnityEngine;
public enum Direction { None,Right , Left , Down ,Up }
public class CarMovementController : MonoBehaviour
{
    [SerializeField] private float time = 1.3f;
    public Direction direction;
    [HideInInspector]
    public bool isMoving = true;
    [SerializeField] private Transform[] target;
    private void Update()
    {
        if (RaycastManager.Instance.carMovementController != this)
        {
            return;
        }
        if (InputManager.Instance.MoveFactorX.x > 10)
        {
            // RÝGHT
            if (target[0] != null)
            {
                CarMoving(target[0].position);
            }
        }
        else if (InputManager.Instance.MoveFactorX.x < -10)
        {
            // LEFT
            if (target[1] != null)
            {
                CarMoving(target[1].position);
            }
        }
        else if (InputManager.Instance.MoveFactorX.y > 10)
        {
            // UP
            if (target[2] != null)
            {
                CarMoving(target[2].position);
            }
        }
        else if (InputManager.Instance.MoveFactorX.y < -10)
        {
            // DOWN
            if (target[3] != null)
            {
                CarMoving(target[3].position);
            }
        }
    }
    public void CarMoving(Vector3 target)
    {
        if (isMoving)
        {
            transform.DOMove(target, time);
        }   
    }
    public void ChangeDirectionToCar(Direction changeDirection)
    {
        direction = changeDirection;
    }
}

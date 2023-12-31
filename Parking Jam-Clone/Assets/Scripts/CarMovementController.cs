using DG.Tweening;
using UnityEngine;
public enum Direction { None,Right , Left , Down ,Up }
public class CarMovementController : MonoBehaviour
{
    [SerializeField] private float moveTime = .65f;
    [SerializeField] private float rotateTime = 0.65f;
    public Direction direction;
    [HideInInspector]
    public bool isMoving = false;
    [SerializeField] private Transform[] target;
    [SerializeField] private Ease ease;

    public Vector3 startPos;
    private const string strUntagged = "Untagged";

    public bool isStartPos = false;
    public Rigidbody rb;

    private void Start()
    {
        startPos = transform.position;
        Debug.Log("isMoving" + isMoving);
    }
    private void CarMovingToStartPos()
    {
        if (isStartPos)
        {
            transform.position = Vector3.Lerp(transform.position, startPos, 3 * Time.deltaTime);
        }
    }
    private void Update()
    {
        CarInputMoving();
        CarMovingToStartPos();
    }
    private void CarInputMoving()
    {
        if (RaycastManager.Instance.carMovementController != this)
        {
            return;
        }
        if (InputManager.Instance.MoveFactorX.x > 10)
        {
            // R�GHT
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
            transform.DOMove(target, 1f);
        }   
    }
    public void ChangeDirectionToCar(Direction changeDirection)
    {
        direction = changeDirection;
    }
    public void NodeTriggering(Collider other)
    {
        // other.tag = strUntagged;
        int nodeIndex = NodeManager.Instance.Nodes.IndexOf(other.transform);
        // NodeManager.Instance.Nodes.Contains(NodeManager.Instance.Nodes[nodeIndex + 1]
        if (NodeManager.Instance.Nodes.Count > nodeIndex + 1)
        {
            transform.DOMove(NodeManager.Instance.Nodes[nodeIndex + 1].position, moveTime).OnUpdate(() => transform.DORotate(NodeManager.Instance.Nodes[nodeIndex + 1].eulerAngles, rotateTime)).SetEase(ease);
        }
        else
        {
            isMoving = false;
        }
    }
}

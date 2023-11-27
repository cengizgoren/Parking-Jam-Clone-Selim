using UnityEngine;
using DG.Tweening;

public class CarTriggerController : MonoBehaviour
{
    private const string strNode = "Node";
    private const string strUntagged = "Untagged";
    private const string strCar = "Car";
    private float time = 2f;
    private CarMovementController carMovementController;

    private void Awake()
    {
        carMovementController = GetComponent<CarMovementController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(strNode))
        {
            carMovementController.NodeTriggering(other);
        }
    }
}

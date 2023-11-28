using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CarTriggerController : MonoBehaviour
{
    private const string strNode = "Node";
    private const string strUntagged = "Untagged";
    private const string strCar = "Car";
    private const string finishStr = "Finish";
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
        else if (other.CompareTag(strCar))
        {
            StartCoroutine(CarTrigggerCoroutine());
        }
        else if (other.CompareTag(finishStr))
        {
            CarChangeToUntag();
        }
    }
    private void CarChangeToUntag()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name + "isFinished");
    }
    private IEnumerator CarTrigggerCoroutine()
    {
        carMovementController.isStartPos = true;
        DOTween.KillAll();
        yield return new WaitForSeconds(.4f);
        carMovementController.isStartPos = false;
    }
}

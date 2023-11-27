using UnityEngine;

public class RaycastManager : Singleton<RaycastManager>
{
    private Camera _camera;
    [SerializeField] private float hitAmount = 250f;
    public CarMovementController carMovementController;
    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        TouchedCar();
    }
    private void TouchedCar()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hitAmount))
        {
            carMovementController = hit.collider.GetComponent<CarMovementController>();
            if (carMovementController != null)
            {
                ChangeToCarMovementController(true);
            }
        }
        else
        {
            if (carMovementController != null)
            {
                ChangeToCarMovementController(false);
            }
        }
    }
    private void ChangeToCarMovementController(bool isMove) => carMovementController.isMoving = isMove;
}

using UnityEngine;

public class CarMovementControllerSettings : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
}

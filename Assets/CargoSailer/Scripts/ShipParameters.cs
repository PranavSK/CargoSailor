using UnityEngine;

[CreateAssetMenu(fileName = "New Ship Parameters", menuName = "Cargo Sailor/Ship Parameters", order = 51)]
public class ShipParameters : ScriptableObject {
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float acceleration = 7.0f;
    [SerializeField] private float friction = 3.0f;
    [SerializeField] private float rotationalSpeed = 1.5f;

    public float MaxSpeed { get => maxSpeed; }
    public float Acceleration { get => acceleration; }
    public float Friction { get => friction; }
    public float RotationalSpeed { get => rotationalSpeed; }
}
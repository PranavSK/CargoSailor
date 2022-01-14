using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour {
    [SerializeField] private ShipParameters defaultParams;
    [SerializeField] private ShipParameters shallowWaterParams;
    [SerializeField] private ShipParameters deepWaterParams;
    [SerializeField] private float health = 90;
    [SerializeField] private ShipView view;

    private ShipParameters shipParameters;
    private Rigidbody2D body;
    private Vector2 desiredVelocity;

    public float Health { get => health; }

    public void ApplyInput(float surgeFactor, float swayFactor) {
        if (Health <= 0) return;
        // INFO: Assume -y as forward direction since the ship asset is designed
        // facing downward.
        // Clamp to remove backward movement.
        var moveDir = swayFactor * -transform.right + Mathf.Clamp01(surgeFactor) * -transform.up;
        desiredVelocity = shipParameters.MaxSpeed * moveDir;
    }

    public void ApplyParameters(ShipParameters parameters = null) {
        shipParameters = parameters ?? defaultParams;
    }

    public void ApplyDamage(float value) {
        health -= value;
        if (!view) return;
        if (Health <= 0) {
            health = 0;
            view.DamageType = ShipView.DamageTypes.DESTROYED;
        } else if (Health <= 30) {
            view.DamageType = ShipView.DamageTypes.HIGH;
        } else if (Health <= 60) {
            view.DamageType = ShipView.DamageTypes.MEDIUM;
        } else {

        }
    }

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        ApplyParameters();
    }

    // Called at a fixed interval independent of the frame rate.
    // This ensures physics calculations to be precise.
    private void FixedUpdate() {
        // Calculate the desired change in velocity.
        var currentVelocity = body.velocity;
        var desiredVelocityChange = desiredVelocity - currentVelocity;
        // Calculate the maximum allowed velocity change.
        // If the angle between the current velocity and the desired  velocity
        // is within +/- 30 degrees apply acceleration, else friction
        // INFO: Assume -y as forward direction since the ship asset is designed
        // facing downward.
        var down = new Vector2(-transform.up.x, -transform.up.y);
        var dirAngle = Vector2.Dot(down, desiredVelocity) > 0.85;
        var maxSpeedChange = Time.fixedDeltaTime * (dirAngle ? shipParameters.Acceleration : shipParameters.Friction);
        var maxVelocityChange = Vector2.ClampMagnitude(desiredVelocityChange, maxSpeedChange);
        body.velocity += maxVelocityChange;
        // If velocity is zero don't change rotaion.
        if (body.velocity == Vector2.zero) return;
        // Change the body rotaion to face movement.
        // INFO: Assume -y as forward direction since the ship asset is designed
        // facing downward. Hence find distance from -90 degrees;
        var desiredAngle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg;
        desiredAngle = Mathf.DeltaAngle(-90, desiredAngle);
        var lerpfactor = shipParameters.RotationalSpeed * Time.fixedDeltaTime;
        body.rotation = Mathf.LerpAngle(body.rotation, desiredAngle, lerpfactor);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ApplyDamage(10f);
        Debug.LogFormat("Ship collided! Damage taken! Health remaining is {0}", Health);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.tag);
        if (other.CompareTag("ShallowWater")) {
            Debug.LogFormat("Ship ({0}) entered shallow water!", this.name);
            ApplyParameters(shallowWaterParams);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("ShallowWater")) {
            Debug.LogFormat("Ship ({0}) exited shallow water!", this.name);
            ApplyParameters(deepWaterParams);
        }
    }
}

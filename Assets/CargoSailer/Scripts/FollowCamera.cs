using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private float maxSpeed = 100.0f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate() {
        var desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime, maxSpeed, Time.smoothDeltaTime);
    }
}

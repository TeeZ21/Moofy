using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1,10)] [SerializeField] private float smoothFactor;
    [SerializeField] private Vector3 minValues, maxValues;

    void LateUpdate() {
        Follow();
    }

    void Follow() {
        Vector3 targetPosition = target.position + offset;
        //Verify if the targetPosition is out of bound or not. Limit it to the min and max values
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x), 
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}

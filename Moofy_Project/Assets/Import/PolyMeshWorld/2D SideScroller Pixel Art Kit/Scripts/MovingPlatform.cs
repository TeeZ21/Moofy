using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private int currentPoint;

    [SerializeField] private Transform[] points;
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private Transform platform;

    private void Update() {
        MoveToNextPoint();
    }

    private void MoveToNextPoint() {
        // Move towards the goal point
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        // Check if we are reaching the next point if so Move to the next one
        if(Vector3.Distance(platform.position, points[currentPoint].position) < .05f) {
            currentPoint++;

            if(currentPoint >= points.Length) {
                currentPoint = 0;
            }
        }
    }
}

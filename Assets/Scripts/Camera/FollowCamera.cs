using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] float smoothing = 5f;
    [SerializeField] float zDistance = 15f;

    private float offsetX;
    private float offsetY;

    private void Start()
    {
        offsetX = transform.position.x - targetTransform.position.x;
        offsetY = transform.position.y - targetTransform.position.y;
    }

    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = new Vector3(targetTransform.position.x + offsetX, targetTransform.position.y + offsetY, -zDistance);

        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing * Time.deltaTime);
    }
}

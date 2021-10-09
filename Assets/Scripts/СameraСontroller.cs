using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class —amera—ontroller : MonoBehaviour
{
    [Header("Zoom setting")]
    [SerializeField] private float _minZoom = 1f;
    [SerializeField] private float _maxZoom = 8f;
    [SerializeField] private float _approachSpeed = 0.01f;

    private Vector3 _touch;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        CameraControl();

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, _minZoom, _maxZoom);
    }
    private void CameraControl()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroLastPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOneLastPosition = touchOne.position - touchOne.deltaPosition;

            float distanceTouch = (touchZeroLastPosition - touchOneLastPosition).magnitude;
            float currentDistanceTouch = (touchZero.position - touchOne.position).magnitude;

            float difference = currentDistanceTouch - distanceTouch;

            Zoom(difference * _approachSpeed);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = _touch - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }
}

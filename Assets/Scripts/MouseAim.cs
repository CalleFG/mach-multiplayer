using UnityEngine;

public class MouseAim : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCamera;

    private void Start()
    { 
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}

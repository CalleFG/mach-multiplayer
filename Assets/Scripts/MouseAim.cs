using UnityEngine;
using Alteruna;
public class MouseAim : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCamera;
    private Alteruna.Avatar _avatar;

    private void Start()
    {
        _avatar = GetComponentInParent<Alteruna.Avatar>();
        if (!_avatar.IsMe) return;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!_avatar.IsMe) return;
        _mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}

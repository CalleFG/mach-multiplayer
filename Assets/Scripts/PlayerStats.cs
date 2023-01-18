using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    private float _horizontal;
    private float _vertical;
    private float _playerSpeed = 10.0f;
    private float _diagonalSpeedLimit = 0.7f;
    private Transform _body;
    
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        if (!_avatar.IsMe)
        {
            Debug.Log("This is NOT me!");
            return;
        }
        Debug.Log("Avatar name: " + _avatar.Possessor.Index);

        _body = transform;
    }

    void Update()
    {
        if (!_avatar.IsMe) return;
        
        InputCollection();
        Movement();
    }

    private void InputCollection()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void Movement()
    {
        float horizontalSpeed = _horizontal * _playerSpeed;
        float verticalSpeed = _vertical * _playerSpeed;

        if (_horizontal != 0 && _vertical != 0)
        {
            _body.position += new Vector3(
                horizontalSpeed * _diagonalSpeedLimit * Time.deltaTime,
                verticalSpeed * _diagonalSpeedLimit * Time.deltaTime,
                0);
        }
        else
        {
            _body.position += new Vector3(
                horizontalSpeed * Time.deltaTime,
                verticalSpeed * Time.deltaTime,
                0);
        }
    }
}

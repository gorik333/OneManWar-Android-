using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShootMechanic))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Joystick _joystick;

    private PlayerMovement _playerMovement;
    private PlayerShootMechanic _playerShootMechanic;
    private PlayerAnimationController _animationController;
    private PlayerHealthController _playerHealthController;

    public static PlayerInput Instance { get; private set; }

    private bool _isButtonClicked;


    void Awake()
    {
        Instance = this;

        _playerHealthController = GetComponent<PlayerHealthController>();
        _animationController = GetComponent<PlayerAnimationController>();
        _playerShootMechanic = GetComponent<PlayerShootMechanic>();
        _playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (_playerHealthController.IsAlive && Time.timeScale != 0 && !DefaultLevelController.IsGameEnd)
        {
            SitAndRunInputs();
        }

        if (_isButtonClicked)
        {
            _playerShootMechanic.Shoot();
        }
    }


    public void SwitchAmmo()
    {
        _playerShootMechanic.SwitchAmmoType();
    }


    public void ChangeDirection()
    {
        if (_playerBody.rotation.y != 0)
        {
            _playerBody.rotation = Quaternion.Euler(0, 0, 0);
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(_playerBody.rotation.y == 0)
        {
            _playerBody.rotation = Quaternion.Euler(0, 180, 0);
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
    }


    private void SitAndRunInputs()
    {
        if (_playerHealthController.IsAlive)
        {
            float sitInput = _joystick.Vertical;
            _animationController.StartSitAnim(sitInput);

            float horizontalDirection;

            if (!MiniShopController.IsShopping)
            {
                horizontalDirection = _joystick.Horizontal;
            }
            else
            {
                horizontalDirection = 0;
            }

            _playerMovement.HorizontalMovement(horizontalDirection);
        }
    }


    public void Jump()
    {
        if (_playerHealthController.IsAlive)
        {
            _playerMovement.Jump();
        }
    }


    public void FireOnPointerDown()
    {
        if (_playerHealthController.IsAlive && Time.timeScale != 0)
        {
            _isButtonClicked = true;
        }
    }


    public void FireOnPointerUp()
    {
        _isButtonClicked = false;
    }


    public void Reload()
    {
        if (!_playerShootMechanic.IsReloading && _playerHealthController.IsAlive && Time.timeScale != 0)
        {
            _playerShootMechanic.Reload();
        }
    }
}

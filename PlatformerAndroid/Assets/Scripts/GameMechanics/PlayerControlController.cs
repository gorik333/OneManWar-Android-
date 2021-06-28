using UnityEngine;
using UnityEngine.UI;

public class PlayerControlController : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _secondSprite;

    private Sprite _currentSprite;

    private bool _isJumpButtonHold;


    void Update()
    {
        if (_isJumpButtonHold)
        {
            PlayerInput.Instance.Jump();
        }
    }


    private void ChangeSprite()
    {
        _currentSprite = _buttonImage.sprite;
        _buttonImage.sprite = _secondSprite;
        _secondSprite = _currentSprite;
    }


    public void FireOnPointerDown()
    {
        PlayerInput.Instance.FireOnPointerDown();
    }


    public void FireOnPointerUp()
    {
        PlayerInput.Instance.FireOnPointerUp();
    }


    public void ReloadOnClick()
    {
        PlayerInput.Instance.Reload();
    }


    public void SwitchAmmoOnClick()
    {
        PlayerInput.Instance.SwitchAmmo();
    }


    public void ChangeDirectionOnClick()
    {
        ChangeSprite();
        PlayerInput.Instance.ChangeDirection();
    }


    public void UseHealOnClick(int ID)
    {
        PlayerHealController.Instance.UseHeal(ID);
    }


    public void JumpOnPointerDown()
    {
        _isJumpButtonHold = true;
    }   


    public void JumpOnPointerUp()
    {
        _isJumpButtonHold = false;
    }
}

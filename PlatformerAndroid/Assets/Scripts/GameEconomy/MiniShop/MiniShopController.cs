using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MiniShopController : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _playerControlCanvas;

    [SerializeField] private GameObject _openShopButton;

    [SerializeField] private Button[] _button;

    private bool _isEnteredToZone;

    private static bool _isShopping;

    public static MiniShopController Instance { get; private set; }


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        _shop.transform.localScale = Vector2.zero;
        SetDefaultValues();
    }


    void SetDefaultValues()
    {
        for (int i = 0; i < _button.Length; ++i)
        {
            if (_button[i].name.Equals("AmmoPanelButton"))
            {
                _button[i].interactable = false;
                continue;
            }
            _button[i].interactable = true;
        }
    }


    public void OpenShopOnClick()
    {
        if (Time.timeScale != 0 && !_isShopping && _isEnteredToZone)
        {
            _openShopButton.SetActive(false);
            _playerControlCanvas.transform.localScale = Vector2.zero;

            _shop.SetActive(true);
            _shop.transform.LeanScale(Vector2.one, 0.15f);
            _isShopping = true;
        }
    }


    public void CloseShopOnClick()
    {
        if (Time.timeScale != 0 && _isShopping)
        {
            _playerControlCanvas.transform.localScale = Vector2.one;

            _shop.transform.localScale = Vector2.zero;
            AmmunitionPanelController.Instance.HideAllInfo();

            _isShopping = false;
            _shop.SetActive(false);

            TurnOnButtonAgain();
        }
    }


    private void TurnOnButtonAgain()
    {
        if (_isEnteredToZone)
        {
            OpenButtonController.ChangeID(OpenButtonController.OPEN_SHOP_ID);

            _openShopButton.SetActive(true);
            _openShopButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enter";
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerCollider") && collider.name.Equals("PlayerBody"))
        {
            AudioController.Instance.PlayShopEntranceSound();

            OpenButtonController.ChangeID(OpenButtonController.OPEN_SHOP_ID);

            _openShopButton.SetActive(true);
            _openShopButton.GetComponentInChildren<TextMeshProUGUI>().text = "Enter";
            _isEnteredToZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerCollider"))
        {
            _isEnteredToZone = false;
            _openShopButton.SetActive(false);
        }
    }


    public static bool IsShopping { get => _isShopping; }
}

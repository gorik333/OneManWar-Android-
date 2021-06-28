using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    [SerializeField] private GameObject _openChestButton;

    private Animator _animator;

    private bool _isOpened;

    public static ChestController Instance { get; private set; }


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("PlayerBody") && !_isOpened)
        {
            OpenButtonController.ChangeID(OpenButtonController.OPEN_CHEST_ID);

            _openChestButton.SetActive(true);
            _openChestButton.GetComponentInChildren<TextMeshProUGUI>().text = "Open";
        }
    }


    public void OpenChestOnClick()
    {
        if (!_isOpened)
        {
            _openChestButton.SetActive(false);
            _animator.SetTrigger("Open");
            AudioController.Instance.PlayOpenChestSound();
            DefaultLevelController.EarnMoneyFromChest();

            _isOpened = true;
        }
        Destroy(gameObject, 2f);
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name.Equals("PlayerBody"))
        {
            _openChestButton.SetActive(false);
        }
    }
}

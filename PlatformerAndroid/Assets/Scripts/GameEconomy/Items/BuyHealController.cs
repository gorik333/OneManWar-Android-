using UnityEngine;
using UnityEngine.UI;

public class BuyHealController : MonoBehaviour
{
    [Header("HealPrice")]
    [SerializeField] private Text[] _healPriceText;

    [Header("HealAmount")]
    [SerializeField] private Text[] _healPurchasedText;

    private PlayerHealController _playerHealController;

    private int[] _healPrice = GlobalDefVals.HEAL_PRICE_ARRAY;


    void Start()
    {
        _playerHealController = FindObjectOfType(typeof(PlayerHealController)) as PlayerHealController;
        DefaultValues();
    }


    void FixedUpdate()
    {
        UpdateValuesOnScreen();
    }


    private void DefaultValues()
    {
        for (int i = 0; i < _healPriceText.Length; i++)
        {
            _healPriceText[i].text = _healPrice[i].ToString();
        }
    }


    private void UpdateValuesOnScreen()
    {
        if (_playerHealController != null)
        {
            for (int i = 0; i < _healPriceText.Length; i++)
            {
                _healPurchasedText[i].text = _playerHealController.HealPurchased[i].ToString();
            }
        }
    }


    public void BuyHealItem(int ID)
    {
        bool isPurchased = DefaultLevelController.BuySomething(_healPrice[ID]);

        if (isPurchased)
        {
            if (_playerHealController != null)
            {
                _playerHealController.AddHeal(ID);
            }
            AudioController.Instance.PlaySuccessfulPurchaseSound();
        }
        else
        {
            AudioController.Instance.PlayUnsuccessfulPurchaseSound();
        }
    }
}

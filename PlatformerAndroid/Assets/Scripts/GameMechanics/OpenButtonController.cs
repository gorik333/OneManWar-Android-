using UnityEngine;

public class OpenButtonController : MonoBehaviour
{
    private static int ID;

    public const int OPEN_SHOP_ID = 0;
    public const int OPEN_CHEST_ID = 1;


    public static void ChangeID(int newID)
    {
        ID = newID;
    }


    public void OpenOnClick()
    {
        if (ID == OPEN_SHOP_ID)
        {
            if (MiniShopController.Instance != null)
                MiniShopController.Instance.OpenShopOnClick();
        }
        else if (ID == OPEN_CHEST_ID)
        {
            if (ChestController.Instance != null)
                ChestController.Instance.OpenChestOnClick();
        }
    }
}

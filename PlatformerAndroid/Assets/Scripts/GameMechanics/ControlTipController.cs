using UnityEngine;

public class ControlTipController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;


    void Start()
    {
        Destroy(gameObject, 5f);
    }


    void Update()
    {
        if (Mathf.Abs(_playerRigidbody.velocity.x) > 1)
        {
            Destroy(gameObject);
        }
    }
}

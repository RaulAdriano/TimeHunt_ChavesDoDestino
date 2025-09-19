using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private TipoPowerUp tipo;

    void Start()
    {
        Invoke(nameof(AtivarColisor), 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ControladorPowerUp>().EquiparPowerUp(tipo);
            Destroy(gameObject);
        }
    }

    private void AtivarColisor()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}

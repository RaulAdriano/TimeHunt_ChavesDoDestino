using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private TipoPowerUp tipo;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ControladorPowerUp>().EquiparPowerUp(tipo);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class ArmadilhaEspinhos : MonoBehaviour
{
    [SerializeField] private int dano;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Vida>().ReduzirVida(dano);
        }
    }
}

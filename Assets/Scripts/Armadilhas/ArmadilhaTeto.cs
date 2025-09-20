using UnityEngine;

public class ArmadilhaTeto : MonoBehaviour
{

    [SerializeField] private int dano;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
        
        InvokeRepeating(nameof(AtivarArmadilha),Random.Range(1,5), Random.Range(2,5));
    }

    private void AtivarArmadilha()
    {
        animator.SetTrigger("Atacar");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Vida>().ReduzirVida(dano);
        }
    }
}

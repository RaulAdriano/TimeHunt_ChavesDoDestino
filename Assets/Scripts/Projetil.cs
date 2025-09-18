using UnityEngine;

public class Projetil : MonoBehaviour
{
    private int dano;
    private int velocidade;
    [SerializeField] private GameObject explosao;

    private bool ignorarInimigo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(DestruirProjetil), 5f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * velocidade);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!(collision.gameObject.tag == "Inimigo" && ignorarInimigo))
        {
            collision.gameObject.GetComponent<Vida>()?.ReduzirVida(dano);
        }
        DestruirProjetil();
    }

    public void IniciarLancamento(Transform alvo, int velocidade, int dano, bool ignorarInimigo)
    {
        transform.right = alvo.position - transform.position;
        this.velocidade = velocidade;
        this.dano = dano;
        this.ignorarInimigo = ignorarInimigo;
    }

    private void DestruirProjetil()
    {
        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

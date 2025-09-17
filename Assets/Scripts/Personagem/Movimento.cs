using System.Collections;
using UnityEngine;

public class Movimento : MonoBehaviour
{

    private Rigidbody2D rb;
    private float entradaHorizontal;
    [SerializeField] private float velocidade = 5f;

    private bool estaNoChao;
    [SerializeField] private Transform pePersonagem;
    [SerializeField] private LayerMask cenarioLayer;
    [SerializeField] private TrailRenderer trailRenderer;
    

    private bool saltoExtra;
    private bool dashLiberadoParaUso = true;
    private bool executandoDash;

    private DirecaoPersonagem direcaoAtual;

    private Animator animator;
    [SerializeField] private JogadorUI jogadorUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcaoAtual = DirecaoPersonagem.DIREITA;

        animator = GetComponent<Animator>();

        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        entradaHorizontal = Input.GetAxis("Horizontal");

        estaNoChao = Physics2D.OverlapCircle(pePersonagem.position,0.3f,cenarioLayer);

        if (estaNoChao)
        {
            saltoExtra = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaNoChao)
            {
                Saltar();
            }
            else if (saltoExtra)
            {
                saltoExtra = false;
                Saltar();
            }
        }

        if (Input.GetKeyDown(KeyCode.C) && dashLiberadoParaUso)
        {
            StartCoroutine(RealizarDash());            
        }

        if (entradaHorizontal > 0)
        {
            GirarPersonagem(DirecaoPersonagem.DIREITA);
        }else if(entradaHorizontal < 0)
        {
            GirarPersonagem(DirecaoPersonagem.ESQUERDA);
        }

        animator.SetBool("Correr", entradaHorizontal != 0);
        animator.SetBool("EstaNoChao", estaNoChao);
    }

    private void FixedUpdate()
    {
        if (!executandoDash)
        {
            rb.linearVelocity = new Vector2(entradaHorizontal * velocidade, rb.linearVelocity.y);
        }
        
    }

    private void Saltar()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * 300);

        animator.SetTrigger("Saltar");
    }

    private void GirarPersonagem(DirecaoPersonagem direcao)
    {
        if (direcao == direcaoAtual)
        {
            return;
        }

        direcaoAtual = direcao; 
        if(direcaoAtual == DirecaoPersonagem.DIREITA)
        {
            transform.eulerAngles = new Vector3 (0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private IEnumerator RealizarDash()
    {
        trailRenderer.emitting = true;
        dashLiberadoParaUso = false;
        executandoDash = true;

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0;
        
        if(direcaoAtual == DirecaoPersonagem.DIREITA)
        {
            rb.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
        }else 
        {
            rb.AddForce(Vector2.left * 20, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(0.3f);

        trailRenderer.emitting = false; 
        executandoDash = false;
        rb.gravityScale = 1;
        rb.linearVelocity = Vector2.zero;

        float contador = 0f;

        while (contador < 3)
        {
            contador += Time.deltaTime;
            jogadorUI.AtualizarProgressoDash(contador / 3);
            yield return null;
        }

        dashLiberadoParaUso = true;
    }
}

enum DirecaoPersonagem { ESQUERDA,DIREITA}

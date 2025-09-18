using System;
using UnityEngine;

public class InimigoGenericoMovimento : InimigoEstado
{

    [SerializeField] private float velocidade = 3f;
    [SerializeField] private float distanciaPatrulha = 5f;

    private bool movendoParaDireita = true;
    private Vector3 posicaoInicial;
    private Animator animator;
    private Rigidbody2D rb;

    private GameObject player;
    private bool alvoEncontrado;

    [SerializeField] private ControladorHitBox controladorHitBox;  

    public override void OnEnter()
    {
        animator.SetBool("Andar", true);
    }

    public override void OnExit()
    {
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("Andar", false);
    }

    public override Type OnUpdate()
    {
        if (controladorHitBox.ExisteAlvosDisponiveis())
        {
            alvoEncontrado = true;
            return typeof(InimigoGenericoAtaque);
        }

        if (alvoEncontrado)
        {
            Perseguir();
        }
        else
        {
            Patrulhar();
        }

        return null;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        posicaoInicial = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Patrulhar()
    {
        if (movendoParaDireita)
        {
            rb.linearVelocity = new Vector2(velocidade, rb.linearVelocity.y);

            if (transform.position.x >= posicaoInicial.x + distanciaPatrulha)
            {
                GirarInimigo();
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-velocidade, rb.linearVelocity.y);
            if (transform.position.x <= posicaoInicial.x - distanciaPatrulha)
            {
                GirarInimigo();
            }
        }
    }


    public void GirarInimigo()
    {
        movendoParaDireita = !movendoParaDireita;

        if (movendoParaDireita)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Perseguir()
    {
        Vector2 direcao = player.transform.position - transform.position;

        rb.linearVelocity = new Vector2(direcao.normalized.x, rb.linearVelocity.y);

        if (direcao.x > 0 && !movendoParaDireita)
        {
            GirarInimigo();
        }
        else if (direcao.x < 0 && movendoParaDireita)
        {
            GirarInimigo();
        }
    }

    public void SetPerseguirJogador()
    {
        alvoEncontrado = true;
    }

}

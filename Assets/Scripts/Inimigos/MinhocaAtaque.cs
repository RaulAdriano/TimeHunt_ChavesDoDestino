using System;
using UnityEngine;

public class MinhocaAtaque : InimigoEstado
{
    [SerializeField] private ControladorHitBox hitBox;
    private Animator animator;
    private Transform player;

    [SerializeField] private float intervaloAtaque;
    private float contador;

    [SerializeField] private int velocidade;
    [SerializeField] private int dano;

    [SerializeField] private Projetil bolaFogoPrefab;
    [SerializeField] private Transform pontoLancamento;

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override Type OnUpdate()
    {
        GirarInimigo();

        if (hitBox.ExisteAlvosDisponiveis())
        {
            contador += Time.deltaTime;
            if (contador > intervaloAtaque)
            {
                contador = 0;
                animator.SetTrigger("Atacar");
            }
        }

        return null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void RealizarAtaque()
    {
        Projetil projetil = Instantiate(bolaFogoPrefab,pontoLancamento.position,Quaternion.identity);
        projetil.IniciarLancamento(player,velocidade,dano,true);
    }

    private void GirarInimigo()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
    }
    
}

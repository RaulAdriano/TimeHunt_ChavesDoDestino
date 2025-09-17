using System;
using UnityEngine;

public class InimigoGenericoAtaque : InimigoEstado
{

    [SerializeField] private int dano = 30;
    [SerializeField] private ControladorHitBox controladorHitBox;
    [SerializeField] private float tempoReacao;
    private Animator animator;
    private Type proximoEstado = null;

    public override void OnEnter()
    {

        Invoke(nameof(IniciarAtaque), tempoReacao);
    }

    public override void OnExit()
    {
        proximoEstado = null;
        CancelInvoke();
    }

    public override Type OnUpdate()
    {
        return proximoEstado;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        
    }

    private void IniciarAtaque()
    {
        animator.SetTrigger("Atacar");
    }

    public void RealizarAtaque()
    {
        controladorHitBox.AplicarDano(dano);
        Invoke(nameof(FinalizarAtaque), tempoReacao);
    }

    private void FinalizarAtaque()
    {
        proximoEstado = typeof(InimigoGenericoMovimento);
    }
    
}

using System;
using UnityEngine;

public class InimigoGenericoAtordoado : InimigoEstado
{
    private Animator animator;
    [SerializeField] private float tempoAtordoado;

    private float contador;

    public override void OnEnter()
    {
        animator.SetTrigger("ReceberDano");
    }

    public override void OnExit()
    {
        contador = 0;   
    }

    public override Type OnUpdate()
    {
        contador += Time.deltaTime;
        if( contador > tempoAtordoado)
        {
            return typeof(InimigoGenericoMovimento);
        }
        return null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

}

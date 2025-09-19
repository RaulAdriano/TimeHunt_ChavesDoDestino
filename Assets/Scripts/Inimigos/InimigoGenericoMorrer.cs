using System;
using UnityEngine;

public class InimigoGenericoMorrer : InimigoEstado
{

    private Animator animator;
    [SerializeField] private GameObject efeitoMorte;

    public override void OnEnter()
    {
        Instantiate(efeitoMorte, transform.position, transform.rotation);
        animator.SetTrigger("Morrer");
        Destroy(gameObject, 3f);
    }

    public override void OnExit()
    {
        
    }

    public override Type OnUpdate()
    {
        return null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }


}

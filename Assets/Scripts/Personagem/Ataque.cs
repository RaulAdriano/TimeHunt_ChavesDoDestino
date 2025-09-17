using System.Collections;
using UnityEngine;

public class Ataque : MonoBehaviour
{

    [SerializeField] private bool espadaLiberada = true;
    private Animator animator;
    [SerializeField] private ControladorHitBox controladorHitBox;
    [SerializeField] private JogadorUI jogadorUI;

    private int danoEspada = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && espadaLiberada)
        {
            StartCoroutine(RealizarAtaqueComEspada());
        }
        
    }


    private IEnumerator RealizarAtaqueComEspada()
    {
        espadaLiberada = false;
        animator.SetTrigger("AtaqueComEspada");
        controladorHitBox.AplicarDano(danoEspada);

        float contador = 0f;

        while (contador <0.6f)
        {
            contador += Time.deltaTime;
            jogadorUI.AtualizarProgressoEspada(contador / 0.6f);
            yield return null;
        }
        espadaLiberada = true;
    }
}

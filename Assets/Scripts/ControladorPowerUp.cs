using System.Collections;
using UnityEngine;

public class ControladorPowerUp : MonoBehaviour
{
    [SerializeField] private Coroutine invencivelCoroutine;
    [SerializeField] private Coroutine velocidadeCoroutine;
    [SerializeField] private Coroutine dano2xCoroutine;
    [SerializeField] private JogadorUI JogadorUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void EquiparPowerUp(TipoPowerUp tipo)
    {
        switch (tipo)
        {
            case TipoPowerUp.INVENCIVEL:
                if(invencivelCoroutine != null)
                {
                    StopCoroutine(invencivelCoroutine);
                }
                invencivelCoroutine = StartCoroutine(AtivarInvencivel());
                break;
            case TipoPowerUp.CURA:
                GetComponent<Vida>().AumentarVida(40);
                break;
            case TipoPowerUp.VELOCIDADE:
                if (velocidadeCoroutine != null)
                {
                    StopCoroutine(velocidadeCoroutine);
                }
                velocidadeCoroutine = StartCoroutine(AtivarVelocidade());
                break;
            case TipoPowerUp.DANO2X:
                if (dano2xCoroutine != null)
                {
                    StopCoroutine(dano2xCoroutine);
                }
                dano2xCoroutine = StartCoroutine(AtivarDano2x());
                break;
        }

    }

    private IEnumerator AtivarInvencivel()
    {
        gameObject.layer = LayerMask.NameToLayer("Intangivel");
        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.INVENCIVEL,true);

        float contador = 0;

        while (contador < 5f) 
        { 
            contador += Time.deltaTime;
            JogadorUI.AtualizarProgressoPowerUp(TipoPowerUp.INVENCIVEL,contador/5);
            yield return null;
        }

        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.INVENCIVEL, false);
        gameObject.layer = LayerMask.NameToLayer("Personagem");
    }

    private IEnumerator AtivarVelocidade()
    {
        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.VELOCIDADE,true);
        GetComponent<Movimento>().AumentarVelocidade();

        float contador = 0;

        while (contador < 10f)
        {
            contador += Time.deltaTime;
            JogadorUI.AtualizarProgressoPowerUp(TipoPowerUp.VELOCIDADE, contador / 10);
            yield return null;
        }
        GetComponent<Movimento>().ReduzirVelocidade();
        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.VELOCIDADE, false);
    }

    private IEnumerator AtivarDano2x()
    {
        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.DANO2X, true);
        GetComponent<Ataque>().AumentarDano();

        float contador = 0;

        while (contador < 10f)
        {
            contador += Time.deltaTime;
            JogadorUI.AtualizarProgressoPowerUp(TipoPowerUp.DANO2X, contador / 10);
            yield return null;
        }
        GetComponent<Ataque>().ReduzirDano();
        JogadorUI.AlterarVisibilidadePowerUp(TipoPowerUp.DANO2X, false);
    }

}
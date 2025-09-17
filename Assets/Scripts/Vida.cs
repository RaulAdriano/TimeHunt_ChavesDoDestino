using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vidaMaxima;
    [SerializeField] private int vidaAtual;

    [SerializeField] private UnityEvent<int,int> onAtualizarVidaMaxima;
    [SerializeField] private UnityEvent<int,int> onReduzirVida;
    [SerializeField] private UnityEvent<int,int> onAumentarVida;
    [SerializeField] private UnityEvent onMorrer;

    private void Start()
    {
        AtualizarVidaMaxima(vidaMaxima, vidaAtual);
    }

    public void AtualizarVidaMaxima(int vidaMaxima, int vidaAtual)
    {
        this.vidaMaxima = vidaMaxima;
        this.vidaAtual = vidaAtual;

        onAtualizarVidaMaxima.Invoke(vidaMaxima,vidaAtual);
    }

    public void ReduzirVida(int danoRecebido)
    {
        vidaAtual -= danoRecebido;
        onReduzirVida.Invoke(danoRecebido,vidaAtual) ;

        if (vidaAtual <= 0)
        {
            onMorrer.Invoke();
        }
    }

    public void AumentarVida(int aumentoRecebido)
    {
        vidaAtual += aumentoRecebido;
        
        if(vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        onAumentarVida.Invoke(aumentoRecebido,vidaAtual) ;
    }
}

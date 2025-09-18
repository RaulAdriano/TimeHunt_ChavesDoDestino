using UnityEngine;
using UnityEngine.UI;

public class BarraVidaInimigo : MonoBehaviour
{
    [SerializeField] private Slider barraVidaSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barraVidaSlider.gameObject.SetActive(false);   
    }

    public void AtualizarVidaMaxima(int vidaMaxima, int vidaAtual)
    {
        barraVidaSlider.maxValue = vidaMaxima;
        barraVidaSlider.value = vidaAtual;
    }

    public void AtualizarVidaAtual(int vidaMaxima, int vidaAtual)
    {
        barraVidaSlider.gameObject.SetActive(true);
        barraVidaSlider.value = vidaAtual;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class JogadorUI : MonoBehaviour
{

    [SerializeField] private Image espadaProgressoImage;
    [SerializeField] private Image bolaFogoProgressoImage;
    [SerializeField] private Image dashProgressoImage;
    [SerializeField] private Slider barraVidaSlider;

    public void AtualizarProgressoEspada(float progresso)
    {
        espadaProgressoImage.fillAmount = progresso;
    }

    public void AtualizarProgressoBolaDeFogo(float progresso)
    {
        bolaFogoProgressoImage.fillAmount = progresso;
    }

    public void AtualizarProgressoDash(float progresso)
    {
        dashProgressoImage.fillAmount = progresso;
    }

    public void AtualizarVidaMaxima(int vidaMaxima, int vidaAtual)
    {
        barraVidaSlider.maxValue = vidaMaxima;
        barraVidaSlider.value = vidaAtual;
    }

    public void AtualizarVidaAtual(int modificador, int vidaAtual)
    {
        barraVidaSlider.value = vidaAtual;
    }
}

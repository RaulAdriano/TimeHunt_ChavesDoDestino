using UnityEngine;
using UnityEngine.UI;

public class JogadorUI : MonoBehaviour
{

    [SerializeField] private Image espadaProgressoImage;
    [SerializeField] private Image bolaFogoProgressoImage;
    [SerializeField] private Image dashProgressoImage;
    [SerializeField] private Slider barraVidaSlider;

    [SerializeField] private Image powerUpInvencivelProgresso;
    [SerializeField] private Image powerUpVelocidadeProgresso;
    [SerializeField] private Image powerUpDano2xProgresso;

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

    public void AtualizarProgressoPowerUp(TipoPowerUp powerUp, float progresso)
    {
        progresso = 1 - progresso;

        switch (powerUp)
        {
            case TipoPowerUp.INVENCIVEL:
                powerUpInvencivelProgresso.fillAmount = progresso;
                break;
            case TipoPowerUp.VELOCIDADE:
                powerUpVelocidadeProgresso.fillAmount = progresso;
                break;
            case TipoPowerUp.DANO2X:
                powerUpDano2xProgresso.fillAmount = progresso;
                break;
        }
    }

    public void AlterarVisibilidadePowerUp(TipoPowerUp powerUp, bool ativado)
    {
        switch (powerUp)
        {
            case TipoPowerUp.INVENCIVEL:
                powerUpInvencivelProgresso.transform.parent.gameObject.SetActive(ativado);
                break;
            case TipoPowerUp.VELOCIDADE:
                powerUpVelocidadeProgresso.transform.parent.gameObject.SetActive(ativado);
                break;
            case TipoPowerUp.DANO2X:
                powerUpDano2xProgresso.transform.parent.gameObject.SetActive(ativado);
                break;
        }
    }
}

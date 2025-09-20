using System.Collections;
using TMPro;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    [SerializeField] public static ControladorPartida instance { get; private set; }
    private int tempoRestante = 30;
    private int tempoTotalPartida = 0;
    private int monstrosDerrotados;
    private int danoSofrido;
    private int chavesColetadas;

    [SerializeField] private TMP_Text tempoRestanteText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text chavesColetadasText;
    [SerializeField] private TMP_Text tempoJogadoGameOverText;
    [SerializeField] private TMP_Text monstrosDerrotadosGameOverText;
    [SerializeField] private TMP_Text danoSofridoGameOverText;
    [SerializeField] private TMP_Text chavesColetadasGameOverText;
    [SerializeField] private TMP_Text scoreGameOverText;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(ContadorDeTempo());   
    }

    private IEnumerator ContadorDeTempo()
    {
        while (tempoRestante > 0)
        {
            yield return new WaitForSeconds(1);
            tempoRestante--;
            tempoTotalPartida++;

            tempoRestanteText.text = tempoRestante + "s";
        }

        FinalizarPartida(false);

    }

    public void FinalizarPartida(bool vitoria)
    {
        Time.timeScale = 0;    
        gameOverPanel.SetActive(true);

        tempoJogadoGameOverText.text = tempoTotalPartida + "s";
        monstrosDerrotadosGameOverText.text = monstrosDerrotados.ToString();
        danoSofridoGameOverText.text = danoSofrido.ToString();
        chavesColetadasGameOverText.text = chavesColetadas + "/3";

        if (vitoria)
        {
            scoreGameOverText.text = "SCORE: " + Mathf.Max(0, CalcularScore());
        }
        else
        {
            scoreGameOverText.text = "SCORE: 0000";
        }
    }

    private int CalcularScore()
    {
        return (2000 - tempoTotalPartida) + (monstrosDerrotados * 5) - (danoSofrido * 2);
    }

    public void NovoMonstroDerrotado(int tempoExtra)
    {
        monstrosDerrotados++;
        tempoRestante += tempoExtra;
    }

    public void AdicionarDanoSofrido(int danoRecebido, int vidaAtual)
    {
        danoSofrido += danoRecebido;
    }

    public void NovaChaveColetada()
    {
        chavesColetadas++;
        chavesColetadasText.text = chavesColetadas + "/3";

        if (chavesColetadas >= 3)
        {
            FinalizarPartida(true);
        }
    }
}

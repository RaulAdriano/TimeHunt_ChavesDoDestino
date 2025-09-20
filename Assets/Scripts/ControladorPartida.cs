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

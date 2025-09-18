using UnityEngine;

public class Minhoca : ControladorEstado
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MudarEstado(typeof(MinhocaAtaque));   
    }

    public void Morrer()
    {
        MudarEstado(typeof (InimigoGenericoMorrer));
    }

    
}

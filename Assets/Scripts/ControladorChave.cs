using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ControladorChave : MonoBehaviour
{
    [SerializeField] private GameObject chavePrefab;
    [SerializeField] private List<Transform> pontosSpawn;
    [SerializeField] private GameObject efeitoColetarChave;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 3; ++i)
        {
            int random = Random.Range(0, pontosSpawn.Count);
            Instantiate(chavePrefab, pontosSpawn[random].position, Quaternion.identity);
            pontosSpawn.RemoveAt(random);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Chave")
        {
            Instantiate(efeitoColetarChave, collision.transform.position, collision.transform.rotation);
            collision.collider.enabled = false;
            ControladorPartida.instance.NovaChaveColetada();
            Destroy(collision.gameObject);
        }
    }


}

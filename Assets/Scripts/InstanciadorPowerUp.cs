using UnityEngine;

public class InstanciadorPowerUp : MonoBehaviour
{

    [SerializeField] private GameObject[] powerUps;
    [Range(0f,1f)][SerializeField] private float probabilidade;

    public void InstanciarPowerUp()
    {
        float random = Random.Range(0f, 1f);

        if (random <probabilidade)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, Quaternion.identity);
        }
    }
}

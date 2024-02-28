using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        // Encontrar y asignar el GameManager en la escena.
        gameManager = FindObjectOfType<GameManager>();
    }
    // OnTriggerEnter se llama cuando el objeto entra en colisión con otro Collider.
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Destruir la moneda.
            Destroy(this.gameObject);
            gameManager.ObtenerPts();
        }
    }
}

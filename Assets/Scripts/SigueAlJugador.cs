
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

        //La c�mara se ajusta a la posci�n del jugador m�s un vector
    {
        transform.position = jugador.transform.position + new Vector3(0, 20, 1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using UnityEditor;
#endif

public class Pelota : MonoBehaviour
{
    private Rigidbody rig;

    [SerializeField] private float velocidad;

    // Variables para el movimiento móvil
    private Vector2 touchOrigin = -Vector2.one;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Si estamos en el editor de Unity o en una plataforma de PC, usar las teclas de dirección
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
#elif UNITY_ANDROID
        float horizontal = 0f;
        float vertical = 0f;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchOrigin = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float x = touch.position.x - touchOrigin.x;
                float y = touch.position.y - touchOrigin.y;
                horizontal = x / Screen.width;
                vertical = y / Screen.height;
            }
        }
#endif

        // Aplicar la fuerza al objeto
        rig.AddForce(new Vector3(horizontal, 0, vertical) * velocidad * Time.deltaTime);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuadricula : MonoBehaviour
{

    public GameObject personaje; // El personaje a instanciar
    public Zona[] zonas; // Las zonas de la cuadrícula
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
    public void SetPersonaje(GameObject personajePrefab)
    {
        personaje = personajePrefab;
    }

    private void OnEnable()
    {
        // Hacer algo si es necesario cuando se activa

        foreach (Zona zona in zonas)
        {
            if (zona.ocupada)
            {
                zona.gameObject.SetActive(false);
            }
            else
            {
                zona.gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        // Hacer algo si es necesario cuando se desactiva
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Verificar si se ha hecho clic en una zona válida
                Zona zona = hit.collider.GetComponent<Zona>();
                if (zona != null && !zona.ocupada)
                {
                    // Instanciar el personaje en la posición de la zona
                    Instantiate(personaje, new Vector3(zona.transform.position.x, zona.transform.position.y, 0), Quaternion.identity);
                    // Marcar la zona como ocupada
                    zona.ocupada = true;
                    Debug.Log("Personaje instanciado en la zona " + zona.ocupada);
                    // Desactivar la cuadrícula después de colocar el personaje
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public bool HayZonasDisponibles()
    {
        foreach (Zona zona in zonas)
        {
            if (!zona.ocupada)
            {
                return true;
            }
        }
        return false;
    }
}
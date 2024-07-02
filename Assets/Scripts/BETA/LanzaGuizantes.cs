using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaGuizantes : MonoBehaviour
{
    public float cadencia = 3;
    public GameObject Guisante;
    public Transform ca�on;
    public LayerMask layerZombie;

    IEnumerator Start()
    {
        while (true)
        {
            //------------------------------------------------ APENAS INICIE EL JUEGO
            yield return new WaitForSeconds(cadencia);
            //------------------------------------------------ LANZA EL SOL LUEGO DE LA FRECUENCIA


            RaycastHit2D hit = Physics2D.Raycast(ca�on.position, Vector3.right, 12, layerZombie);
            if (hit.collider != null)
            {
                GameObject go = Instantiate(Guisante, ca�on.position, Guisante.transform.rotation) as GameObject;
                Destroy(go, 10);
            }

        }
    }
}

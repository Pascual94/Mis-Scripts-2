using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject flecha, lista;

    int indice = 0;
    void Start()
    {
        Dibujar();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKeyDown("up");
        bool down = Input.GetKeyDown("down");

        if (up) indice--;
        if (down) indice++;
        if (indice > lista.transform.childCount - 1) indice = 0;
        else if (indice < 0) indice = lista.transform.childCount - 1;

        if (up || down) Dibujar();

        if (Input.GetKeyDown("return"))
        {
            Accion();
        }
    }

    void Dibujar()
    {
        Transform opcion = lista.transform.GetChild(indice);
        flecha.transform.position = opcion.position;
    }
    void Accion()
    {
        Transform opcion = lista.transform.GetChild(indice);

        if (opcion.gameObject.tag == "World1")
        {
            SceneManager.LoadScene(opcion.gameObject.tag);
        }
        if (opcion.gameObject.tag == "LoadGame")
        {
            Debug.Log("No hay partidas guardadas");
        }
        if(opcion.gameObject.tag == "Credits")
        {
            SceneManager.LoadScene(opcion.gameObject.tag);
        }
        if (opcion.gameObject.tag == "Exit")
        {
            print("Cerrando juego...");
        }
        
    
    }
}

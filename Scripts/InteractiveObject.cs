using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] GameObject objectContainer;
    private void OnMouseDown()
    {
        objectContainer.SetActive(!objectContainer.activeInHierarchy);
    }

    






















    /*
    private void OnMouseEnter()
    {
        Debug.Log("Alguien anda por aqui.... ");
    }
    private void OnMouseExit()
    {
        Debug.Log("Se fueron de aqui .¡.");
    }

    private void OnMouseOver()
    {
        Debug.Log("Alejateeeee");
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Para que me aprietas si me vas a soltar aqui mismo .¡.");
    }

    
    private void OnMouseDown()
    {
        Debug.Log("Me presionastes");
    }

    private void OnMouseDrag()
    {
        Debug.Log("Hay mierda suertame");
    }

    private void OnMouseUp()
    {
        Debug.Log("Mieeeeerda me soltastes");
    }
    */


}

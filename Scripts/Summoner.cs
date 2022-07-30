using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    [SerializeField] GameObject objectToInvoke;
    [SerializeField] GameObject placeTosummon;
    [SerializeField] GameObject container;

    bool noActiveObject = false;
    private void OnMouseDown()
    {
        StartCoroutine(WeInvoke());
    }

    // Invocamos

    
    IEnumerator   WeInvoke()
    {

        if (!noActiveObject)
        {
            noActiveObject = true;
            GameObject clonObjectToInvoke =
            Instantiate(objectToInvoke,
            placeTosummon.transform.position,
            placeTosummon.transform.rotation);
            //container.SetActive(false);
            Debug.Log("Hemos invocado");

            yield return new WaitForSeconds(2f);
            Destroy(clonObjectToInvoke.gameObject, 0.1f);
            Debug.Log("Podemos volver a invocar");
            noActiveObject = false;
            
        }

    }
}

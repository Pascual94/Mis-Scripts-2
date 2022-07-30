using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotType : MonoBehaviour
{
    [SerializeField] GameObject objetoToAddForce;
    [SerializeField] Transform canyon;
    [SerializeField] float shotForce = 10f;
    [SerializeField] int numberOfBullets = 100;
    [SerializeField] float rechargeTime = 30f;
    bool reloading = false;
    void Update()
    {

        
        // Test Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            AddForceRigth();
        }
        
    }

    public void AddForceUp()
    {
        GameObject clon = Instantiate(objetoToAddForce, transform.position, transform.rotation);
        Rigidbody2D rb2dClon = clon.GetComponent<Rigidbody2D>();
        rb2dClon.AddForce(Vector2.up * shotForce, ForceMode2D.Impulse);
    }
    public void AddForceRigth()
    {
        if(!reloading && numberOfBullets > 0)
        {
            GameObject bulletClon = Instantiate(objetoToAddForce, transform.position, transform.rotation);
            Rigidbody2D rb2dClon = bulletClon.GetComponent<Rigidbody2D>();
            rb2dClon.AddForce(canyon.right * shotForce, ForceMode2D.Impulse);
            numberOfBullets--;
            Destroy(bulletClon, 10f);
        }      
        if (numberOfBullets == 70)
        {
            reloading = true;
            StartCoroutine(Expect());
            numberOfBullets--;
        }
        if (numberOfBullets == 40)
        {
            reloading = true;
            StartCoroutine(Expect());
            numberOfBullets--;
        }
        if (numberOfBullets == 10)
        {
            reloading = true;
            StartCoroutine(Expect());
            numberOfBullets --;
        }
        if (numberOfBullets == 0)
        {
            reloading = true;
            Debug.Log("!! No hay mas balas ¡¡");

            numberOfBullets = 0;
        }
    }

    IEnumerator Expect()
    {
        if (reloading)
        {
            Debug.Log("Hay que esperar...");

            yield return new WaitForSeconds(rechargeTime);

            Debug.Log("¡Se acabo la espera!");

            reloading = false;
        }
        
    }
}

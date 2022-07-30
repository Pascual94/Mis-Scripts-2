using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    /* Nuetra clase (NetworkManager) es la que se va encargar 
     * de enviar y recibir la informacion del servidor
     */



    /* Creamos una (Funcion) para crear un usuario con la informacion que 
     * el usuario coloque en los Input Field
     * Esta funcion debe recibir un delegado para que nos de un valor devuelto como respuesta
     * Y debe recibir los datos ingresados por el usuario en forma de cadena
     * los datos los obtenemos por medio de los (Input Field)
     */
    public void CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        // Aqui debemos empezar la Corrutina (co_CreateUser) y le pasamos todos los datos recuperados
        StartCoroutine(CO_CreateUser( userName, email, pass, response) );
    }

    /* Ahora creamos una Corroutina
     * Como el contacto con el servidor no es algo que sucede en un solo frame,
     * no es algo que sucede inmediatamente tenemos que contener el codigo en una corrutina.
     * ! NOTA: 
     * El codigo que se usa para contactar al servidor 
     * siempre tiene que estar contenido en una corrutina
     * porque la corrutina va esperar hasta que el servidor nos responda
     * y va a proveer la respuesta
     * nuestra corrutina (IEnumerator) tambien debe recibir toda la informacion del usuario
     * y por supuesto nuetros delegado (Action<>) 
     */
    private IEnumerator CO_CreateUser(string userName, string email, string pass, Action<Response> response)
    {
        // Creamos un formulario para enviar nuestra informacion al servidor
        SecureForm form = new SecureForm();
        /* Ahora añadimos todos los datos que queramos con (AddField())
         * Colocamos primero el nombre del campo y el valor de ese campo
         */
        form.secureForm.AddField("userName", userName);
        form.secureForm.AddField("email", email);
        form.secureForm.AddField("pass", pass);

        /* Ya que tenemos toda la informacion montada en nuestro formulario
         * creamos nuestro object (WWW) que va ser el encargado de enviar 
         * ese formulario a nuestro servidor
         * en el constructor de nuestro objcet (WWW) debemos pasar primero que todo, 
         * la (direccion a nuestro servidor) que en este caso vendria siendo simplemente
         * y nuestro proyecto o carpeta de proyecto que se debe llamar (/Game/) 
         * la carpeta del proyecto tiene que estar guardada en (xampp/htdocs) para que pueda 
         * estar vinculada con el servidor, y el 
         * (script) o codigo (PHP) que se deberia llamar (/createUser.php)
         * coma (,) y nuetro formulario que contiene toda nuestra informacion
         */
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        var w = new WWW("http://localhost/Game/createUser.php" , form.secureForm );
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

        /* Y como nuestro codigo no va a devolver la respuesta inmediatamente 
         * debemos hacerle un (yield return) a nuetro object (WWW) 
         * para esperar que nos envie su respuesta
         */
        yield return w;
        Debug.Log(w.text);
        
        /* Y simplemente llamamos a response();
        * ahora que tenemos la respuesta simplemente ((w.text)) tiene la respuesta 
        * que nos a enviado el servidor en forma de (JSON) asi que 
        * utilizamos el metodo (JsonUtility) para trasformala de (JSON)
        * (.FromJson) a nuestro delegado (<Response>) y le pasamos la respuesta entre parentesis (w.text) 
        */
        response(JsonUtility.FromJson<Response>(w.text));
    }


    // AQUI CREAMOS LAS FUNCIONES PARA CHECK AL USUARIO
    public void CheckUser(string userName, string pass, Action<Response> response)
    {
        // Aqui debemos empezar la Corrutina (co_CreateUser) y le pasamos todos los datos recuperados
        StartCoroutine(CO_CheckUser(userName, pass, response));
    }

    private IEnumerator CO_CheckUser(string userName, string pass, Action<Response> response)
    {
        // Creamos un formulario para enviar nuestra informacion al servidor que seria nuetro formulario seguro (SecureForm)
        SecureForm form = new SecureForm();
        /* Ahora añadimos todos los datos que queramos con (AddField())
         * Colocamos primero el nombre del campo y el valor de ese campo
         */
        form.secureForm.AddField("userName", userName);
        form.secureForm.AddField("pass", pass);

        /* Ya que tenemos toda la informacion montada en nuestro formulario
         * creamos nuestro object (WWW) que va ser el encargado de enviar 
         * ese formulario a nuestro servidor
         * en el constructor de nuestro object (WWW) debemos pasar primero que todo, 
         * la (direccion a nuestro servidor) que en este caso vendria siendo simplemente (localhost)
         * y nuestro proyecto o carpeta de proyecto que se debe llamar (/Game/) 
         * la carpeta del proyecto tiene que estar guardada en (xampp/htdocs) para que pueda 
         * estar vinculada con el servidor, y el 
         * (script) o codigo (PHP) que se deberia llamar (/checkUser.php)
         * coma (,) y nuetro formulario que contiene toda nuestra informacion
         */
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        var w = new WWW("http://localhost/Game/checkUser.php", form.secureForm);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

        /* Y como nuestro codigo no va a devolver la respuesta inmediatamente 
         * debemos hacerle un (yield return) a nuetro object (WWW) 
         * para esperar que nos envie su respuesta
         */
        yield return w;
        Debug.Log(w.text);

        /* Y simplemente llamamos a response();
        * ahora que tenemos la respuesta simplemente ((w.text)) tiene la respuesta 
        * que nos a enviado el servidor en forma de (JSON) asi que 
        * utilizamos el metodo (JsonUtility) para trasformala de (JSON)
        * (.FromJson) a nuestro delegado (<Response>) y le pasamos la respuesta entre parentesis (w.text) 
        */
        response(JsonUtility.FromJson<Response>(w.text));
    }
}

// Creamos una clase para la respuesta que vamos a recibir
// la clase tiene que ser de tipo [Serializable] para que pueda ser transformada en (JSON)
[Serializable]
public class Response
{
    // Creamos un valor booleano que es el que nos va adecir si todo 
    // fue satifactorio,(si el usuario pudo ser creado)
    public bool     done        = false;
    // Y el mensaje que nos devuelve el servidor
    public string   message     = "";

    // Ejemplo : Si nosotros enviamos la informacion al servidor y el usuario es creado
    // Simplemente (done) va ser (true) y el (message) deberia ser simplemente "Usuario Creado"
    // si el usuario no fue creado (done) deberia ser (false) y el (message) deberia decirnos el ERROR
    // Por ejemplo: Que "el usuario ya esta creado", o que "el imail ya existe en la base de datos" etc...
}

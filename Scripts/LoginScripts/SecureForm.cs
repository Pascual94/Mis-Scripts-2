using UnityEngine;

public class SecureForm
{
    /* FORMULARIO PARA LA SEGURIDAD DE CONECCION A NUESTRA BASE DE DATOS
     * 
     */
    // Creamos un objeto privado de tipo (WWWForm)
    private WWWForm m_secureForm                  = null;

    /* Vamos a tener una contraseña base. Para conseguir unas claves podemos irnos a (KEY GENERATOR) 
        y podemos usar cualquier generador de claves o crear una clave inventada por nosotros mismo
    */
    private const string CONNECTION_PASSWORD    = "ContraseñadeconeccionbasicaJlecpd";
    // Vamos a tener una contraseña para cada plataforma que desarrollemos nuertro juego 
    // Es decir podemos tener una para android
    private const string ANDROID_PASSWORD       = "ContraseñadeconeccionbasicaparaANDROIDJlecpd";
    // Una para IOS. Es decir podemos tener una para cada plataforma que queramos
    private const string IOS_PASSWORD           = "ContraseñadeconeccionbasicaparaIOSJlecpd";

    // Hay que añadir un acceso publico a nuestro formulario
    public WWWForm secureForm  { get { return m_secureForm; } }

    // Vamos a tener el construtor de la clase (SecureForm)
    public SecureForm()
    {
        // Dentro de nuetro contructor vamos a iniciar primero nuetros formulario
        m_secureForm = new WWWForm();

        // Y vamos añadir todas nuestras claves
        /* Primero añadimos nuestra clave base que va estar en todas nuestras peticiones al servidor
         * podemos llamarlo ("connectionPass") y obviamente le pasmos como valor (CONNECTION_PASSWORD)
         */
        m_secureForm.AddField("connectionPass", CONNECTION_PASSWORD);

        /* Ahora vamos añadir las claves que dependen de cada plataforma, para eso vamos hacer uso de algo en (unity)
         * que se llama directiva dependiente de la plataforma
        */
        /* Que quiere decir esto??
         * Quiere decir que podemos poner codigo entre las directivas
         * 
            #if UNITY_ANDROID
            // Agregar codigo 
            #endif

         /* Y este codigo que este dentro de la directiva va ser solamente compilado para la plataforma que estemos definiendo
          en este caso puede ser (ANDROID)*/

        /* Pero en caso de que yo quiera que sea para (IOS) tenemos que hacer que el proyecto haga (build) para (IOS)  para que las 
        * directivas lo reconozca como codigo para (IOS)*/

        /* Lo que quiere decir esto es que cuando estemos en un (dispositivo android) vamos añadir estas contraseñas */
        /* Primero hay que añadir en que sistema operativo nos encontramos. 
           Asi que si entramos aqui estamos en el sitema operativo (os) android (android)
        */
#if UNITY_ANDROID
        /* Primero hay que añadir en que sistema operativo nos encontramos. 
          Asi que si entramos aqui estamos en el sitema operativo (os) android (android)
        */
        secureForm.AddField("os" , "android");
        // Y añadimos la contraseña
        secureForm.AddField("platformPass" , "ANDROID_PASSWORD");
#endif

        /* En caso que estemos en (IOS) para que este codigo pueda ser compilado para que veamos si en realidad esta funcionando 
         * vamos a colocar que sea (IOS) o (||) (UNITY_EDITOR) osea desde el editor
        */
#if UNITY_IOS
        // Vamos añadir las contraseñas para (IOS)

        /* Primero hay que añadir en que sistema operativo nos encontramos. 
          Asi que si entramos aqui estamos en el sitema operativo (os) ios (ios)
        */
        secureForm.AddField("os" , "ios");
        // Y añadimos la contraseña
        secureForm.AddField("platformPass" , "IOS_PASSWORD");
#endif

    }

    // Y listo ya hemos creado nuestro (Secure.Form)
}

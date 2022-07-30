using UnityEngine;
using UnityEngine.UI;

public class SceneManager1 : MonoBehaviour
{
    // Esto es para poner un subtitulo en el Ispector para tener todo mas ordenado
    [Header("Login")]
    [SerializeField] private InputField m_loginUserNameInput    = null;
    [SerializeField] private InputField m_loginPasswordInput    = null;


    // Esto es para poner un subtitulo en el Ispector para tener todo mas ordenado
    [Header("Register")]
    // Guardamos las variables en [SerializeField] para verlas en el inspector, 
    // no la volvemos publica para no tener que interactual con ellas sin querer por medio de codigo.
    [SerializeField] private GameObject _Login                  = null;
    [SerializeField] private GameObject _Register               = null;
    /* Aqui guardamos una la referencia al campo de (Text) que vamos a
     * utilizar para comunicarnos con el usuario
    */
    [SerializeField] private Text m_textMessage                 = null;
    // Aqui guardamos todos los (Input Field) que poseen la refencia a los datos que proporciono el usuario
    [SerializeField] private InputField m_userNameInput         = null;
    [SerializeField] private InputField m_emailInput            = null;
    [SerializeField] private InputField m_passwordInput         = null;
    [SerializeField] private InputField m_reEnterPasswordInput  = null;
    // Creamos una referencia de nuestro (NetworkManager) para poder acceder a sus codigos
    private NetworkManager m_networkManager                     = null;


    // Metodo que se llama antes de iniciar
    private void Awake()
    {
        // Buscamos el objeto (NetworkManager) y lo almacenamos en (m_networkManager) como una referencia
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    // Metodo para enviar el login del usuario
    public void SubmitLogin()
    {
        // Verificamos que ningun campo este vacio
        if (m_loginUserNameInput.text == "" || m_loginPasswordInput.text == "")
        {
            // Si algunos de los campos esta vacio tenemos que decirle al usuario
            m_textMessage.text = "Porfavor llena todos los campos";
            // Y ponemos un (return) para devolvernos
            return;
        }

        // Y si no hay problemas entonces enviamos nuetra informacion
        m_textMessage.text = "Procesando...";

        /* En caso de que los datos sean correctos llamamos a nuetra clase (NetworkManager)
         * y a su metodo (.CheckUser()) y le pasamos nuestros datos de (InputField) y 
         * nuetra respuesta que nos va a decir como nos ha ido todo y nuetro delegado 
         * que contiene la informacion de como ha salido todo
         */
        m_networkManager.CheckUser(m_loginUserNameInput.text, m_loginPasswordInput.text, delegate (Response response)
        {
            /* En cualquier caso de que se haya creado o no se haya creado 
             * simplemente mostramos (response) en el campo de mensaje 
             * para el usuario (m_textMessage), con el mensaje enviado desde el servidor
             */
            m_textMessage.text = response.message;
        });
    }


    // Metodo para enviar el registro del usuario
    public void SubmitRegister()
    {
        // Verificamos que ningun campo este vacio
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_passwordInput.text == "" || m_reEnterPasswordInput.text == "")
        {
            // Si algunos de los campos esta vacio tenemos que decirle al usuario
            m_textMessage.text = "Porfavor llena todos los campos";
            // Y ponemos un (return) para devolvernos
            return;
        }

        // Detectamos que los campos de las contraseñas sean iguales 
        if(m_passwordInput.text == m_reEnterPasswordInput.text)
        {
            /* Un mesaje para el usuario para que sepa que se esta procesando ya que la respuesta
             * puede tardar quisas 1 o 2 segundos en volver o si nuestra conexion a internet es muy lenta
             * puede tardar mucho mas
             */ 
            m_textMessage.text = "Procesando...";

            /* En caso de que los datos sean iguales llamamos a nuetra clase (NetworkManager)
             * y a su metodo (.CreateUser()) y le pasamos nuestros datos de (InputField) y 
             * nuetra respuesta que nos va a decir como nos ha ido todo y nuetro delegado 
             * que contiene la informacion de como ha salido todo
             */
            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_passwordInput.text,delegate(Response response) 
            {
                /* En cualquier caso de que se haya creado o no se haya creado 
                 * simplemente mostramos (response) en el campo de mensaje 
                 * para el usuario (m_textMessage), con el mensaje enviado desde el servidor
                 */
                m_textMessage.text = response.message;
            });
        }
        else
        {
            // En caso de que los datos no sean iguales enviamos un mensaje
            m_textMessage.text = "Contraseñas no son igual por favor verificar ";
        }
    }

    // Metodo para ver la interfas del Login 
    public void ShowLogin()
    {
        // Al guardarlo en un (object) GameObject podemos activarlo y desactivarlo con true y false
        _Register.SetActive(false);
        _Login.SetActive(true);
    }

    // Metodo para ver la interfas del Register 
    public void ShowRegister()
    {
        // Al guardarlo en un (object) GameObject podemos activarlo y desactivarlo con true y false
        _Login.SetActive(false);
        _Register.SetActive(true);
    }
}

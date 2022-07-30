using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public float jumpPower = 13f;
    public bool grounded;
    public float maxSpeed = 110f;
    public float speed = 220f;

    bool movement = true;
    bool jump;
    bool doubleJump;
    Rigidbody2D rb2d;
    Animator anim; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }  
    void Update()
    {

        if (grounded && Input.GetKeyDown("r"))
        {
            speed *= 2f;
        }
        if( grounded && Input.GetKeyUp("r"))
        {
            speed = 220f;
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        if (grounded)
        {
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }
        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;
        rb2d.AddForce(Vector2.right * speed * h);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);          
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);          
        }
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
   
}


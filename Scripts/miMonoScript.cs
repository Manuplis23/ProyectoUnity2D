    using UnityEngine;

public class miMonoScript : MonoBehaviour
{
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int movimientoHorizontal;
    private int movimientoVertical;
    private Vector2 mov;
    [SerializeField] private float speed = 3.0f;
    private float ogSpeed;
    private float multiSpeed;
    [SerializeField] private float valMultSpeed = 1.5f;
    private Rigidbody2D rb;

    
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //timerOn = true;
    rb = GetComponent<Rigidbody2D>();
        ogSpeed = speed;
        multiSpeed = speed * valMultSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        // Velocidad aumentada o normal
        Sprint(multiSpeed);
        // Movimiento horizontal
        MovHorizontal(1);
        // Movimiento vertical
        MovVertical(1);

        // rb.AddForce(mov * speed * Time.fixedDeltaTime); // empuja el objeto
    }
    private void MovHorizontal(int a)
    {
        if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = -1;
        }
        else
        {
            movimientoHorizontal = 0;
        }
    }

    private void MovVertical(int a)
    {
        if (Input.GetKey(KeyCode.W))
        {
            movimientoVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movimientoVertical = -1;
        }
        else
        {
            movimientoVertical = 0;
        }
    }

    private void Sprint(float multSpeed)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = multiSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = ogSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = mov * speed * Time.fixedDeltaTime;
        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        mov = mov.normalized; //normaliza vector, reduce al vector a su magnitud minima(1) con su misma direccion
    }
}

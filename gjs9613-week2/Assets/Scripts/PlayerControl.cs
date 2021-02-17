using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float forceAmt =  10;

    public static PlayerControl instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);

        transform.position = new Vector2(10.26f, 0f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(Vector2.up * forceAmt);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(Vector2.left * forceAmt);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(Vector2.down * forceAmt);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(Vector2.right * forceAmt);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * (2 * forceAmt));
        }

        //need to get 0 of camera space instead of world space
        if (transform.position.x <= 0 || transform.position.x >= Screen.width || transform.position.y <= 0 || transform.position.y >= Screen.height)
        {
            //rb2d.velocity = Vector2.zero;
        }
    }
}

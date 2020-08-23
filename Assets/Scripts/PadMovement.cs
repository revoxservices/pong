using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Move the player alongside the y axis 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PadMovement : MonoBehaviour
{
    private float xOff = 0f;
    
    

    //Movement velocity
    [Tooltip("Velocity in unity units")]
    [SerializeField]private float velocity = 5f;
    [Header("true para movimiento por traslacion false para movimiento por fuerza:")]
    [SerializeField] private bool movimiento = true;  //switch de forma de movimiento
    
    [Header("Controles para el game pad:")]
    [SerializeField] private KeyCode upControl = KeyCode.W;
    [SerializeField] private KeyCode downControl = KeyCode.S;

    private Rigidbody2D _rigidbody2D;
    [Header("Separacion del sprite con el borde de la pantalla en Y abajo:")]
    public float yOffsetInf;

    [Header("Separacion del sprite con el borde de la pantalla en Y arriba:")]
    public float yOffsetSup;
    // Start is called before the first frame update
    void Start()
    {
        xOff = gameObject.GetComponent<SpriteRenderer>().size.x / 2;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        /*
        if(Input.GetAxis("Vertical")> 0)
            transform.Translate(0f,velocity,0f);
        else if(Input.GetAxis("Vertical")< 0)
            transform.Translate(0f,-velocity,0f);
        */
        if (movimiento == true)
        {
            if (Input.GetKey(upControl))
                transform.Translate(0f, velocity, 0f);
            if (Input.GetKey(downControl))
                transform.Translate(0f, -velocity, 0f);
        }
        else{
            if (Input.GetKey(upControl))
            {
                //transform.Translate(0f,velocity,0f);
                if (!_rigidbody2D.Equals(null))
                    _rigidbody2D.AddForce(Vector2.up * velocity, ForceMode2D.Impulse);
                else
                {
                    Debug.LogWarning("El objeto no tiene rigidbody!!!");
                }
            }
            else if (Input.GetKey(downControl))
            {
                if (!_rigidbody2D.Equals(null))
                    _rigidbody2D.AddForce(Vector2.down * velocity, ForceMode2D.Impulse);
                else
                {
                    Debug.LogWarning("El objeto no tiene rigidbody!!!");
                }
            }
        }
        //transform.Translate(0f,-velocity,0f); 
        /*
        if (!_rigidbody2D.Equals(null))
        {
            _rigidbody2D.AddForce(Vector2.up, ForceMode2D.Impulse);
            _rigidbody2D.AddForce(Vector2.down, ForceMode2D.Impulse);
            
        }
        else
        {
            Debug.LogWarning("El objeto no tiene rigidbody!!!");
        }
        */
        var position = transform.position;
        position =new Vector3(position.x,Mathf.Clamp(position.y, yOffsetInf, yOffsetSup));
        transform.position = position;
        }
}

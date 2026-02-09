using UnityEngine;
using UnityEngine.InputSystem;

public class Leonardo : MonoBehaviour
{
    public float velocidad = 5f;
    public float salto = 10f;
    public Transform playaCheck;
    public float playaCheckRadius = 0.2f;
    public LayerMask playaLayer;


    public int saltosextraValue = 1;
    private int saltosextra;
    private Rigidbody2D rb;
    private bool isPlaya;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        saltosextra = saltosextraValue;
    }

    
    void Update()
    {
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.left * velocidad;
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.right * velocidad;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isPlaya)
            {
                rb.linearVelocity = Vector2.up * salto;
            }
            else if (saltosextra > 0)
            {
                rb.linearVelocity = Vector2.up * salto;
                saltosextra--;
            }
        }
    }

    private void FixedUpdate()
    {
        isPlaya = Physics2D.OverlapCircle(playaCheck.position, playaCheckRadius, playaLayer);
        if (isPlaya)
        {
            saltosextra = saltosextraValue;
        }
    }
}

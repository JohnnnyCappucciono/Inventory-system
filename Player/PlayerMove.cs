using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    public float speed = 0.2f;
    float verticalInput;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //movment
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(horizontalInput, verticalInput).normalized;
        rb.transform.Translate(moveInput * speed * Time.deltaTime, Space.World);

        if(verticalInput > 0) 
        {
            animator.SetBool("runUp", true);
            animator.SetBool("runDown", false);
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);

        }

        if (verticalInput < 0)
        {
            animator.SetBool("runDown", true);
            animator.SetBool("runUp", false);
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);
        }

        if(verticalInput == 0) 
        {
            animator.SetBool("runDown", false);
            animator.SetBool("runUp", false);

        }
        
        if(horizontalInput > 0) 
        {
            //desno
            animator.SetBool("runRight", true);
            animator.SetBool("runLeft", false);
        }
        if (horizontalInput < 0)
        {
            //lijevo
            animator.SetBool("runLeft", true);
            animator.SetBool("runRight", false);
        }
        
        if (horizontalInput == 0)
        {
            //desno
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);
        }
        
    }
}

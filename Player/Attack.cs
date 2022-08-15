using UnityEngine.EventSystems;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Camera cam;
    [SerializeField] private LoadOutSlot weaponSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (weaponSlot.item != null)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
                var dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
                if (dir.x > transform.position.x)
                {
                    sprite.flipX = true;

                }
                else sprite.flipX = false;

                animator.SetBool("attack", true);
            }
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetBool("attack", false);

        }
    }
}

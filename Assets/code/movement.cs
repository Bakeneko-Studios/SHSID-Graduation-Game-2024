using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float runSpeed = 20.0f;
    Rigidbody2D rb;
    public Animator anim;
    public float hf = 0.0f;
    public float vf = 0.0f;
    public Vector2 movementVec;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVec.x = Input.GetAxisRaw("Horizontal");
        movementVec.y = Input.GetAxisRaw("Vertical");
        movementVec = movementVec.normalized;
        
        float hf = movementVec.x > 0.01f ? movementVec.x : movementVec.x < -0.01f ? 1 : 0;
        float vf = movementVec.y > 0.01f ? movementVec.y : movementVec.y < -0.01f ? 1 : 0;

        if (movementVec.x < -0.01f)
        {
            this.gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            facingRight = false;
        }
        else if (movementVec.x > 0.01f)
        {
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            facingRight = true;
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.Play("walking");
        }
        else
        {
            anim.Play("idle");
        }

    }

    void FixedUpdate()
    {

       
        rb.velocity = new Vector2(movementVec.x * runSpeed, movementVec.y * runSpeed);

        
    }
}

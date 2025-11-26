using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        //Flip player when moving left-right
        if(horizontalInput > 0.01)
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
        else if(horizontalInput < -0.01)
            transform.localScale = new Vector3(-0.7f, 0.7f, 1);

        if(Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);

        anim.SetBool("run", horizontalInput != 0);
    }
}

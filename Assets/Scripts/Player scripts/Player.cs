using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float maxVelocity = 4f;

    private Rigidbody2D playerBody;
    private Animator anim;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); // returns -1 if <- or A, returns 1 if -> or D, returns 0 if nothing pressed

        if (h > 0) // going right
        {
            if (vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale;
            temp.x = 1.5f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if (h < 0) // going left
        {
            if (vel < maxVelocity)
                forceX = -speed;

            Vector3 temp = transform.localScale;
            temp.x = -1.5f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }
}

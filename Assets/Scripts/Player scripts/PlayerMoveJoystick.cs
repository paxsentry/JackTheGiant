using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    private bool moveLeft, moveRight;

    private Rigidbody2D playerBody;
    private Animator anim;

    public void SetMoveDirection(bool left)
    {
        moveLeft = left;
        moveRight = !left;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        Move(true);
    }

    void MoveRight()
    {
        Move(false);
    }

    void Move(bool direction)
    {
        float forceX = 0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        if (vel < maxVelocity)
        {
            if (direction)
                forceX = -speed;
            else
                forceX = speed;
        }

        Vector3 temp = transform.localScale;

        if (direction)
            temp.x = -1.5f;
        else
            temp.x = 1.5f;

        transform.localScale = temp;
        anim.SetBool("Walk", true);
        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
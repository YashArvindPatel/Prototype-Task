using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb2D;
    private Animator animator;
    public float charSpeed;
    public GameObject[] playerViews;

    public enum Direction
    {
        Front = 0,
        Right = 1,
        Back = 2,
        Left = 3
    }

    public enum State
    {
        Idle = 0,
        Walk = 1,
        Run = 2
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        HandleAnimations();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void HandleAnimations()
    {
        if (movement.y > 0)
        {
            ChangePlayerView(Direction.Back);
        }
        else if (movement.y < 0)
        {
            ChangePlayerView(Direction.Front);
        }
        else
        {
            if (movement.x > 0)
            {
                ChangePlayerView(Direction.Right);
            }
            else if (movement.x < 0)
            {
                ChangePlayerView(Direction.Left);
            }
        }

        if (movement.sqrMagnitude == 0)
        {
            animator.SetInteger("State", (int)State.Idle);
        }         
        else
        {
            animator.SetInteger("State", (int)State.Walk);
        }         
    }

    void ChangePlayerView(Direction dir)
    {
        foreach (var view in playerViews)
        {
            view.SetActive(false);
        }

        playerViews[(int)dir].SetActive(true);
    }

    void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + movement.normalized * charSpeed * Time.fixedDeltaTime);
    }
}

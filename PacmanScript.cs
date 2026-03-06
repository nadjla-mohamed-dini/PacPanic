using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanScript : MonoBehaviour {

    enum Direction {
        UP,
        LEFT,
        RIGHT,
        DOWN
};

public Direction direction = Direction.LEFT;
public float speed = 0.5f;

private Rigidbody2D _body;
//private Animator _animator;
private SpriteRenderer _renderer;

    void Start(){
        _body = GetComponent<Rigidbody2D>();
        //_animator = GetComponentInChildren<Animator>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Move(){
        Vector2 movement =  Vector2.zero;

        switch (direction)
        {
        case Direction.UP:
            movement = Vector2.up;
            break;
        case Direction.DOWN:
            movement = Vector2.down;
            break;
        case Direction.LEFT:
            movement = Vector2.left;
            break;
        case Direction.RIGHT:
            movement = Vector2.right;
            break;
        }
        _body.MovePosition(_body.position + movement * speed * Time.deltaTime);

    }

    // private void UpdateAnimation() {
    //     switch (direction)
    //     {
    //     case Direction.UP:
    //         _animator.Play("pacman_up");
    //         _renderer.flipY = false;
    //         break;
    //     case Direction.DOWN:
    //         _animator.Play("pacman_up");
    //         _renderer.flipY = true;
    //         break;
    //     case Direction.LEFT:
    //         _animator.Play("pacman_left");
    //         _renderer.flipX = false;
    //         break;
    //     case Direction.RIGHT:
    //         _animator.Play("pacman_left");
    //         _renderer.flipX = true;
    //         break;
    //     }
    // }

    void Update (){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0)
            direction = Direction.LEFT;
        else if (horizontal > 0)
            direction = Direction.RIGHT;
        else if (vertical > 0)
            direction = Direction.UP;
        else if (vertical < 0)
            direction = Direction.DOWN;

        //UpdateAnimation();
    }
    void FixedUpdate() {
        Move();
    }
}
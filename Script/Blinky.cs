using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour {

    enum Direction {
        UP,
        LEFT,
        RIGHT,
        DOWN
    }

    enum Mode {
        SCATTER,
        CHASE
    }

    public float speed = 0.5f;
    public float chasespeed = 0.6f;

    public Transform scatterTarget;
    private Transform pacman;

    private Mode currentMode = Mode.SCATTER;
    private Direction direction = Direction.LEFT;
    private Rigidbody2D _body;

    void Start(){
        _body = GetComponent<Rigidbody2D>();
        pacman = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(ModeRoutine());
    }

    void FixedUpdate() {
        Move();
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

        float currentSpeed = (currentMode == Mode.CHASE) ? chasespeed : speed;
        _body.MovePosition(_body.position + movement * currentSpeed * Time.deltaTime);
 
    }

    IEnumerator ModeRoutine()
    {
        while (true)
        {
            currentMode = Mode.SCATTER;
            yield return new WaitForSeconds(7f);

            currentMode = Mode.CHASE;
            yield return new WaitForSeconds(20f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Intersection"))
        {
            ChooseDirection();
        }
    }

    void ChooseDirection()
    {
        Vector2 target;

        if (currentMode == Mode.CHASE)
            target = pacman.position;
        else
            target = scatterTarget.position;

        Direction bestDirection = direction;
        float bestDistance = Mathf.Infinity;

        foreach (Direction dir in System.Enum.GetValues(typeof(Direction)))
        {
            Vector2 dirVector = DirectionToVector(dir);
            Vector2 newPos = _body.position + dirVector;

            float distance = Vector2.Distance(newPos, target);

            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestDirection = dir;
            }
        }

        direction = bestDirection;
    }

    Vector2 DirectionToVector(Direction dir)
    {
        switch (dir)
        {
            case Direction.UP:
                return Vector2.up;
            
            case Direction.DOWN:
                return Vector2.down;

            case Direction.LEFT:
                return Vector2.left;

            case Direction.RIGHT:
                return Vector2.right;
        }

        return Vector2.zero;
    }
}
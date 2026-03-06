using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelette : MonoBehaviour
{
    public int point = 10;

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PeletteEaten(this);
        FindObjectOfType<GameManager>().PeletteEaten(this, transform.position);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))

        {
            Eat();
        }
        Debug.Log("Collision avec : " + other.name);
    }
}

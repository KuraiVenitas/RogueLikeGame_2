using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public int health;
    public int damage;
    
    public GameObject deathDropPrefab; // On defeat, drop something
    public SpriteRenderer sr;
    public LayerMask moveLayer = new LayerMask();


    private void Start()
    {
         player = FindObjectOfType<Player>();
    }

    public void Move()
    {
        if(Random.value < 0.5f)
            return;
        Vector3 dir = Vector3.zero;
        bool canMove = false;

        while(canMove == false)
        {
            dir = GetRandomDirection();
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, moveLayer);

            if (hit.collider == null)
                canMove = true;
        }

        transform.position += dir;

    }

    Vector3 GetRandomDirection()
    {
        int ran = Random.Range(0, 4);
        if (ran == 0)
            return Vector3.up;
        else if (ran == 1)
            return Vector3.down;
        else if (ran == 2)
            return Vector3.left;
        else if (ran == 3)
            return Vector3.right;

        return Vector3.zero;
    }

}

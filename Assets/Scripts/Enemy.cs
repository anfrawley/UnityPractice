using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 3;

    GameObject player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");

        if(health <= 0)
        {
            Die();
        }
        
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}

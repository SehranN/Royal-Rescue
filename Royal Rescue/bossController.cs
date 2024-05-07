using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{

    public GameObject enemy;
    public float speed = 5f;
    public Animator animator;

    public float distanceLimit = 20f;  // Adjust the distance limit as needed
    private float distanceTraveled = 0f;
    private bool movingRight = true;
    public float health = 200.0f;
    private bool isAttacking = false;
    private bool isAttacked = false;

    public Transform attackPoint;
    public float range = 0.5f;
    public LayerMask enemyLayer;
    public Animator player;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Speed", 1);
        animator.SetFloat("Health", health);
        animator.SetBool("isAttacked", isAttacked);
        animator.SetBool("isAttacking", isAttacking);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        StartCoroutine(AttackAfterDelay());
    }



    IEnumerator AttackAfterDelay()
    {
        float minRange = 0f;
        float maxRange = 10f;
        float randomFloat = Random.Range(minRange, maxRange);
        // Wait for the specified delay
        yield return new WaitForSeconds(randomFloat);

        // Call the Attack method
        Attack();
    }

    void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("attack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position,range, enemyLayer);

        foreach(Collider2D enemy in hitEnemy)
        {
            Debug.Log("We hit");
            player.SetTrigger("Hurt");
        }

        StartCoroutine(AttackAfterDelay());

    }

    public void getHit()
    {
        if (health <= 1f)
        {
            animator.Play("death");
        }
        else
        {
            animator.SetTrigger("isAttacked");
            health -= 50f;
        }
        
    }

    public void die()
    {
        Destroy(gameObject);
    }

    
}

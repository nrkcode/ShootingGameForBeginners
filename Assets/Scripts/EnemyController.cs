using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyBullet;
    float fireDelay; //총알 발사 간격

    Animator animator;
    bool onDead;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        onDead = false;
        time = 0.0f;
    }

    public void FireBullet()
    {
        fireDelay += Time.deltaTime;
        if(fireDelay > 3f)
        {
            Instantiate(enemyBullet,transform.position, Quaternion.identity);
            fireDelay -= 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onDead)
        {
            time += Time.deltaTime;
        }
        if(time > 0.6f)
        {
            Destroy(gameObject);
        }
        FireBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            animator.SetInteger("State", 1);
            OnDead();
        }
    }

    private void OnDead()
    {
        onDead = true;
        // 스코어 증가 코드 작성
    }
}

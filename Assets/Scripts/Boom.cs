using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private  Vector3 LaunchOffset;
    [SerializeField] private  float speed = 4f;
    [SerializeField] private  GameObject explosionPrefab;
    [SerializeField] private  float impactField, force;
    [SerializeField] private  LayerMask toHit;

    Rigidbody2D rb;
    Vector3 lastVelocity;
    

    public void Explodeed() // code làm cho bom nổ 
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, toHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponentInParent<Rigidbody2D>().AddForce(direction * force);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Tạo ra vụ nổ
        Destroy(gameObject); // Xoá vụ nổ
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var direction = transform.right + Vector3.up;
        GetComponentInParent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        transform.Translate(LaunchOffset);;
    }


    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 2f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player"|| other.tag == "Boom" || other.tag == "Box")
        {
            Explodeed();
            AudioManager.Instance.PlaySFX(4);
        } else
        {
            StartCoroutine(CountDown());
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2f);
        Explodeed();
        AudioManager.Instance.PlaySFX(4);
    }

}


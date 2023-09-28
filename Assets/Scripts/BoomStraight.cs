using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStraight : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private  float speed = 4f;
    [SerializeField] private  GameObject explosionPrefab;
    [SerializeField] private  float impactField, force;
    [SerializeField] private  LayerMask toHit;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*speed;
    }
    public void Explodeed()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, toHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 dir = obj.transform.position - transform.position;

            obj.GetComponentInParent<Rigidbody2D>().AddForce(dir * force);

        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Terrain" || other.tag == "Boom" || other.tag == "Box")
        {
            Explodeed();
            AudioManager.Instance.PlaySFX(4);
        } else {
            StartCoroutine(CountDown());
        }
    }

        IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2.5f);
        Explodeed();
        AudioManager.Instance.PlaySFX(4);
    }


}

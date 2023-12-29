using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Thisone;
    public int Hit;
    public GameObject explosionPosition;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.right * Time.deltaTime * 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Thisone == 1)
        {
            if (collision.GetComponent<personBehavior>().healthAmount > 0)
            {
                collision.GetComponent<personBehavior>().healthAmount -= 1;
            }
            else
            {
                collision.GetComponent<personBehavior>().healthAmount -= Hit;
            }
            Instantiate(explosionPrefab, explosionPosition.transform.position, explosionPosition.transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Enemy" && Thisone == 0)
        {
            collision.GetComponent<Enemy>().HP -= Hit;

            Instantiate(explosionPrefab, explosionPosition.transform.position, explosionPosition.transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.tag == "EnemyBoss" && Thisone == 0)
        {
            collision.GetComponent<Boss>().HP -= 1;

            Instantiate(explosionPrefab, explosionPosition.transform.position, explosionPosition.transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.tag == "EnemyBoss1" && Thisone == 0)
        {
            GameObject.FindGameObjectWithTag("EnemyBoss").GetComponent<Boss>().HP -= 5;

            Instantiate(explosionPrefab, explosionPosition.transform.position, explosionPosition.transform.rotation);
            Destroy(this.gameObject);
        }
        if (collision.tag == "4" && Thisone == 0)
        {
            collision.GetComponent<Jgm>().i = true;
           // Destroy(this.gameObject);
        }
    }

}

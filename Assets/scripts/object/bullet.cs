using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 2f;
    public float lastTime = 4f;
    public GameObject projectile;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        rb2d.velocity = projectile.transform.up * speed;
        yield return new WaitForSeconds(lastTime);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

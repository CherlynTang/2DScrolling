using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public Vector3 Trigget;
    public float speed;
    public bool GJ;
    Vector3 endVec;
    Vector3 StartVec;
    Vector3 End;
    public float ShootTime;
    public int HP;
    public Slider slider1;
    public GameObject Bullet;
    public int CanShoot;
    public bool zz,tt;

    SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        StartVec = this.transform.position;
        endVec = this.transform.position + Trigget;
        End = endVec;

      //  slider1 = this.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        slider1.maxValue = HP;

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        slider1.value = HP;
        if (HP <= 0)
        {
            Destroy(this.gameObject);

        }
        if (tt == true)
        {
        ShootTime += Time.deltaTime;
        if (ShootTime >= 1.5f && CanShoot == 0)
        {
            ShootTime = 0;
            GameObject go = GameObject.Instantiate(Bullet, this.transform.position, Quaternion.identity);
            go.transform.right = this.transform.right;

        }
    }
        if (zz == true)
        {

            if (End == endVec)
            {
                if (GJ)
                {
                    this.transform.Translate(Vector2.up * Time.deltaTime * speed);
                }
                else
                {
                    this.transform.localEulerAngles = new Vector3(0, 180, 0);
                    this.transform.Translate(-Vector2.right * Time.deltaTime * speed);
                }


                if (Vector3.Distance(this.transform.position, End) <= 0.2f)
                {
                    End = StartVec;
                }
            }
            else
            {
                if (GJ)
                {
                    this.transform.Translate(-Vector2.up * Time.deltaTime * speed);
                }
                else
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    this.transform.Translate(-Vector2.right * Time.deltaTime * speed);
                }

                if (Vector3.Distance(this.transform.position, End) <= 0.2f)
                {
                    End = endVec;
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            //  m_SpriteRenderer.color = Color.red;
            StartCoroutine(bulletHit());
        }
        /*if (!collision.CompareTag("bullet"))
        {
            m_SpriteRenderer.color = Color.white;
        }*/
    }

    IEnumerator bulletHit()
    {
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        m_SpriteRenderer.color = Color.white;
    }
}



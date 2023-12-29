using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int HP;
    public Slider slider1;
    public GameObject Bullet;
    public float i,time, ShootTime;
    public GameObject jg;
    // Start is called before the first frame update
    void Start()
    {
        slider1.maxValue = HP;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        slider1.value = HP;
        if (time <=0)
        {
            i += 1;
            time = 3;
            if (i >= 4)
            {
                i = 1;
            }
        }
        if (HP <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<personBehavior>().YDUI[7].SetActive(true);
            Destroy(this.gameObject);
        }
        ShootTime -= Time.deltaTime;
        if (ShootTime <= 0 && i == 1)
        {
            ShootTime = 1;
            jg.SetActive(false);
            GameObject go = GameObject.Instantiate(Bullet, this.transform.position, Quaternion.identity);
            go.transform.right = this.transform.right;
        }
        else if(ShootTime<=0&&i == 2)
        {
            ShootTime = 1;
               jg.SetActive(false);
               GameObject go = GameObject.Instantiate(Bullet, this.transform.position, Quaternion.identity);
                GameObject go1 = GameObject.Instantiate(Bullet, this.transform.position+ new Vector3(0,1,0), Quaternion.identity);
                GameObject go2 = GameObject.Instantiate(Bullet, this.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                go.transform.right = this.transform.right;
                go1.transform.right = this.transform.right;
                go2.transform.right = this.transform.right;           
        }
        else if (i == 3)
        {
            jg.SetActive(true);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jgm : MonoBehaviour
{
    public GameObject Door,Door1;
    public bool i;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i == true)
        { z -= Time.deltaTime;
            Door1.SetActive(false);
            if(z>=0)
            Door.transform.Translate(Vector3.up * 3 * Time.deltaTime);
            this.GetComponent<BoxCollider2D>().enabled = false;
          //  transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
    }


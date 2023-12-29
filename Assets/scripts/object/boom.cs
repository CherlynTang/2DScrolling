using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(waitTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}

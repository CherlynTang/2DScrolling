using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject Player;
    Vector3 Dis;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");  //Íæ¼Ò
        Dis = transform.position - Player.transform.position;//¸úËæÍæ¼ÒÒÆ¶¯ 
    }

    // Update is called once per frame
    void Update()
    {
        float targetY = Player.transform.position.y + Dis.y;
        Vector3 targetPos = new Vector3(Player.transform.position.x + Dis.x, targetY, Player.transform.position.z + Dis.z);
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, Time.deltaTime * 6);
    }
}

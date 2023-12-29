using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tz(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

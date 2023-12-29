using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class personBehavior : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 10f;
    public float jumpHeight ;
    public Transform groundChecker;
    public float groundRadius;
    public LayerMask groundMask;
    public bool grounded = true;

    public bool jumping;
    public bool falling;

    public float healthAmount ;
    //public Slider healthSlider;
    //朝向
    public bool IsFacingRight;
    //射击
    public GameObject gunPoint;
    public GameObject bulletPrefab;

    public Animator animator;
    public GameObject[] UI;
    public int i;
    public bool YS;
    public float YSTime, YSCD;
    public SpriteRenderer t;
    public GameObject[] YDUI;

    public Image slider;

    public bool characterTalkable;

    //对话文字
    public TMPro.TMP_Text Max_words;
    public TMPro.TMP_Text Nate_words;
    public string dialogueString1;
    public string dialogueString2;
    public string dialogueString3;
    public string dialogueString4;
    public string dialogueString5;
    public string dialogueString6;

    //对话框
    public GameObject Max_UI;
    public GameObject Nate_UI;

    //对话按钮
    public GameObject TalkButton;

    public Button talkButton;

    public int dialogueOrder = 0;
  

    // Start is called before the first frame update
    void Start()
    {
        slider.fillAmount = 1;
        //healthSlider.maxValue = healthAmount;
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 0;
        }
        t = GetComponent<SpriteRenderer>();

        Max_UI.SetActive(false);
        Nate_UI.SetActive(false);

        talkButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        //talkable
        if (characterTalkable == true)
        {
            TalkButton.SetActive(true);
        }
        if (characterTalkable == false)
        {
            TalkButton.SetActive(false);
        }
        //血量
        slider.fillAmount = healthAmount / 4;
        //healthSlider.value = healthAmount;
        if(healthAmount > 4)
        {
            healthAmount = 4;
        }
        if(healthAmount < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            healthAmount = 0;
        }

        //移动
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(speed * move, rb2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));
        //跳跃
        if (grounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.H))
            {
                float jumpForce = Mathf.Sqrt(2f * Physics2D.gravity.magnitude * rb2D.gravityScale * jumpHeight) * rb2D.mass;
                rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                animator.SetTrigger("Jump");
                grounded = false;

                jumping = true;
            }
            
        }
        //是否坠落
        falling = rb2D.velocity.y < -0.01;
        if (falling || grounded)
        {
            jumping = false;
            //animator.SetBool("IsJumping", false);
        }
        //是否站在地面
        grounded = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundMask) != null;
        animator.SetBool("Grounded", grounded);     
        //射击
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetInteger("State",1);
            // animator.SetTrigger("IsAttacking");
            //   Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
            GameObject go = GameObject.Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
            go.transform.right = this.transform.right;
        }
        else
        {
            animator.SetInteger("State", 0);
            animator.SetBool("IsAttacking", false);
        }
        //隐身
        YSTime -= Time.deltaTime;
        YSCD -= Time.deltaTime;
        if (YSCD <= 0 && Input.GetKeyDown(KeyCode.K))
        {
            YSTime = 2;
            YSCD = 4;
        }
        if (YSTime >= 0)
        {
            YS = true;
            Color color = t.color;
            color.a = 0.5f;
            t.color= color;    
        }
        else
        {
             YS = false;
            Color color = t.color;
            color.a = 1f;
            t.color = color;
        }
        //朝向
        if(Input.GetKeyDown(KeyCode.D))
        {
            IsFacingRight = true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            IsFacingRight = false;
        }

        if (IsFacingRight == true)
        {
            /*Vector3 scale = transform.localScale;
            scale.x *= 1;
            transform.localScale = scale;*/
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (IsFacingRight == false)
        {
            /* Vector3 scale = transform.localScale;
             scale.x *= -1;
             transform.localScale = scale;*/
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }
    bool z;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("gold")) 
        {
            Debug.Log("gold + 1");
        }
        if (other.CompareTag("addHealth"))
        {
            healthAmount += 2;
            if (z == false)
            {
                z = true;
                YDUI[5].SetActive(true);
            }        
            Destroy(other.gameObject);

        }
        if (other.CompareTag("Enemy"))
        {
            healthAmount -= 1;

        }
        if (other.CompareTag("1"))
        {
            //毒液
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("2"))
        {
            i += 1;
            UI[i].SetActive(true);
        
            Destroy(other.gameObject);
        }
        if (other.tag=="3")
        {
            if (YS == false)
            {
                healthAmount -= 1;
            }   
        }
        if (other.CompareTag("UI1"))
        {
            YDUI[0].SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("UI2"))
        {
            YDUI[1].SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("UI3"))
        {
            YDUI[2].SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("UI4"))
        {
            YDUI[3].SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("UI5"))
        {
            YDUI[4].SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag=="UIBoss")
        {
            YDUI[6].SetActive(true);
        }
        if (other.CompareTag("22"))
        {
            SceneManager.LoadScene(3);
        }
        if (other.CompareTag("33"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.CompareTag("11"))
        {
           // SceneManager.LoadScene(3);
        }

        if (other.CompareTag("character1"))
        {
            characterTalkable = true;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("character1"))
        {
            characterTalkable = false;

        }
    }
    public void TIme()
    {
        Time.timeScale = 1;
    }

    void TaskOnClick()
    {
        StartCoroutine(dialogue1());
        dialogueOrder += 1;
    }
    IEnumerator dialogue1()
    {
        Nate_UI.SetActive(true);
        for (int i = 0; i < dialogueString1.Length; i++)
        {
            Nate_words.text = dialogueString1.Substring(0, i + 1);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        Nate_UI.SetActive(false);
        Max_UI.SetActive(true);
        for (int i = 0; i < dialogueString2.Length; i++)
        {
            Max_words.text = dialogueString2.Substring(0, i + 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

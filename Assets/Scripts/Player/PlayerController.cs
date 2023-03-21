using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public FixedJoystick joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float speed = 4;
    public GameObject slashAttackPrefab;
    public float attackInterval = 0.5f;
    public HealthBar healthBar;

    [Space]
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;

    [Space]
    public GameObject lightning;

    private Vector2 direction = Vector2.right;
    private bool slashLeft;
    public float maxHealth = 100;
    public float curHealth = 100;
    private int slashLevel = 0;
    private int deffenderLevel = 0;
    private int lightningLevel = 0;

    IWeapon basicWeapon;

    public Text skill1;
    public Text skill2;
    public Text skill3;

    public GameObject gameOverPanel;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            instance = null;
        }
        else
        {
            instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(PerformAutoAttack());
        //StartCoroutine(LighningAttack());
        //GameObject circle = Instantiate(circle1, transform.position, Quaternion.identity);
        //circle.transform.parent = this.transform;
        slashLeft = false;
        StartDeffend();
        basicWeapon = new Weapon();
        basicWeapon.Init();
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;
        if (curHealth <= 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }

    public void InitSlash()
    {
        if (slashLevel == 0)
        {
            basicWeapon = new Slash(basicWeapon);
            basicWeapon.Init();
            slashLevel++;
        }
        else if (slashLevel > 0 && slashLevel < 8)
        {
            //add damage or range
            slashLevel++;
            slashAttackPrefab.GetComponent<WeaponControl>().damage++;
        }
        else if (slashLevel > 8)
        {
            //update skill panel to max
            skill1.text = "Level Max";
        }
        Debug.Log("slash: " + slashLevel);
        skill1.text = "Level " + slashLevel.ToString();
        GameController.instance.weaponPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void InitDeffend()
    {
        if (deffenderLevel == 0)
        {
            basicWeapon = new Deffender(basicWeapon);
            basicWeapon.Init();
            deffenderLevel++;
        }
        else if (deffenderLevel > 0 && deffenderLevel < 8)
        {
            //add damage or range
            if (deffenderLevel == 3)
            {
                c.SetActive(false);
                c1.SetActive(true);
            }
            if (deffenderLevel == 6)
            {
                c1.SetActive(false);
                c2.SetActive(true);
            }
            deffenderLevel++;
        }
        else if (deffenderLevel > 8)
        {
            //update skill panel to max
            skill2.text = "Level Max";

        }
        Debug.Log("deffend: " + deffenderLevel);
        skill2.text = "Level " + deffenderLevel.ToString();
        GameController.instance.weaponPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void InitLightning()
    {
        if (lightningLevel == 0)
        {
            basicWeapon = new Lightning(basicWeapon);
            basicWeapon.Init();
            lightningLevel++;
        }
        else if (lightningLevel > 0 && lightningLevel < 8)
        {
            //add damage or range
            lightningLevel++;
            lightning.GetComponent<WeaponControl>().damage++;
        }
        else if (lightningLevel > 8)
        {
            //update skill panel to max
            skill3.text = "Level Max";
        }
        Debug.Log("lightning: " + lightningLevel);
        skill3.text = "Level " + lightningLevel.ToString();
        GameController.instance.weaponPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartSlash()
    {
        StartCoroutine(PerformAutoAttack());
    }

    private IEnumerator PerformAutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject slashAttack;
            // Instantiate the slash attack
            if (!slashLeft)
            {
                slashAttack = Instantiate(slashAttackPrefab, transform.position, Quaternion.identity);
                slashAttack.transform.parent = this.transform;
                float elapsedTime = 0f; 
                while (elapsedTime < 0.5f)
                {
                    float t = elapsedTime / 0.5f; 
                    slashAttack.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y, this.transform.position.z), t);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                slashLeft = true;
            }
            else
            {
                slashAttack = Instantiate(slashAttackPrefab, transform.position, Quaternion.identity);
                slashAttack.transform.parent = this.transform;

                float elapsedTime = 0f;
                while (elapsedTime < 0.5f)
                {
                    float t = elapsedTime / 0.5f;
                    slashAttack.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, this.transform.position.z), t);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                slashLeft = false;
            }

            // Destroy the slash attack after a short delay
            Destroy(slashAttack, 0.25f);
        }
    }

    public void StartLightning()
    {
        StartCoroutine(LighningAttack());
    }

    private IEnumerator LighningAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject ln;
            ln = Instantiate(lightning, new Vector2(this.transform.position.x + (Random.Range(-2.5f, 2.5f)), this.transform.position.y + (Random.Range(-3f, 3f))), Quaternion.identity);
            Destroy(ln, 0.3f);
        }
    }

    private GameObject c;
    private GameObject c1;
    private GameObject c2;


    public void StartDeffend()
    {
        c = Instantiate(circle1, transform.position, Quaternion.identity);
        c.transform.parent = this.transform;
        c.SetActive(false);
        c1 = Instantiate(circle2, transform.position, Quaternion.identity);
        c1.transform.parent = this.transform;
        c1.SetActive(false);
        c2 = Instantiate(circle3, transform.position, Quaternion.identity);
        c2.transform.parent = this.transform;
        c2.SetActive(false);
    }

    public void StartDeffender()
    {
        c.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            if (other.gameObject.name == "ExpLow")
            {
                GameController.instance.expGain += 3;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "ExpMedium")
            {
                GameController.instance.expGain += 4;
                Destroy(other.gameObject);
            }
            else
            {
                GameController.instance.expGain += 5;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Creep1"))
        {
            curHealth -= collision.gameObject.GetComponent<CreepManager>().damageAmount;
            healthBar.UpdateHealthbar(maxHealth, curHealth);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float temp = 0;
        if (collision.gameObject.CompareTag("Creep1"))
        {
            temp += Time.deltaTime;
            if (temp > 1f)
            {
                curHealth--;
                healthBar.UpdateHealthbar(maxHealth, curHealth);
                temp = 0;
            }        
        }
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void RestartGame()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

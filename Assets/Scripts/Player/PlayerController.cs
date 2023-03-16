using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float speed = 2;
    public GameObject slashAttackPrefab;
    public float attackInterval = 2f;

    [Space]
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;

    [Space]
    public GameObject lightning;

    private Vector2 direction = Vector2.right;
    private bool slashLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PerformAutoAttack());
        StartCoroutine(LighningAttack());
        GameObject circle = Instantiate(circle1, transform.position, Quaternion.identity);
        circle.transform.parent = this.transform;
        slashLeft = false;
    }

    private void Update()
    {
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }

    private IEnumerator PerformAutoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
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
                    slashAttack.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), t);
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
                    slashAttack.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), t);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                slashLeft = false;
            }

            // Destroy the slash attack after a short delay
            Destroy(slashAttack, 0.25f);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Exp"))
        {
            if (other.gameObject.name == "ExpLow")
            {
                GameController.instance.expGain += 1;
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name == "ExpMedium")
            {
                GameController.instance.expGain += 2;
                Destroy(other.gameObject);
            }
            else
            {
                GameController.instance.expGain += 3;
                Destroy(other.gameObject);
            }
        }
    }
}

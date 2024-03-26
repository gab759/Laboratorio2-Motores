using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    public TextMeshProUGUI textoLife;
    public float direction;
    public LayerMask layerMask;
    public int playerLife = 10;
    public bool suelo;
    public bool doubleJump;
    public float jumpForce = 4.5f;
    Rigidbody2D _compRigidbody2D;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(direction * speed, _compRigidbody2D.velocity.y);
    }

    private void Update()
    {
        Inputs();
        Check();
        textoLife.text = "Vida: " + playerLife;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muerte"))
        {
            SceneManager.LoadScene("YouLoss");
        }
        if (collision.CompareTag("puerta"))
        {
            SceneManager.LoadScene("Nivel2");
        }
        if (collision.CompareTag("win"))
        {
            SceneManager.LoadScene("YouWin");
        }
        if (collision.CompareTag("Color"))
        {
            playerLife = playerLife - 1;
            Debug.Log("perdi uno de vida");
        }
    }
    private void Inputs()
    {
        direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && (suelo || doubleJump))
        {
            if (!suelo)
            {
                doubleJump = false;
            }
            _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, jumpForce);
        }
    }
    private void Check()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.blue);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask))
        {
            suelo = true;
            doubleJump = true;
        }
        else
        {
            suelo = false;
        }
    }

    
}

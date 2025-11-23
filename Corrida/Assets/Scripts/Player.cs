using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject camera;
    public GameObject gameOver;
    private Placar placar;
    private AtrairObjetos atrair;
    public Transform checarChao;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float velocidade;
    public float velocidadeTotal;
    public float pulo;
    private float moveInput;
    private bool doublejump = false;
    private bool facingRight = false;
    [HideInInspector]
    private bool estaNoChao;

    void Start()
    {
        velocidade = velocidadeTotal;
        camera = GameObject.FindWithTag("MainCamera");
        atrair = GameObject.Find("Jogador").GetComponent<AtrairObjetos>();
        atrair.enabled = false;
        placar = GameObject.Find("Gerenciador").GetComponent<Placar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        ChecarChao();
    }
    void Update()
    {
        //moveInput = Input.GetAxis("Horizontal");
        Vector3 direction = transform.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, velocidade * Time.deltaTime);
        animator.SetInteger("playerState", 1); // Turn on run animation
      
        if (estaNoChao) animator.SetInteger("playerState", 0); // Turn on idle animation
        if (estaNoChao)
        {
            doublejump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
        {
            if (estaNoChao)
            {
                rigidbody.AddForce(transform.up * pulo, ForceMode2D.Impulse);
            }
            else if (doublejump)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                rigidbody.AddForce(transform.up * pulo, ForceMode2D.Impulse);
                doublejump = false;
            }
        }
        if (!estaNoChao)animator.SetInteger("playerState", 2); // Turn on jump animation
        if(facingRight == false)
        {
            Virar();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Virar();
        }
        velocidadeCamera();
    }
    private void Virar()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void ChecarChao()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checarChao.transform.position, 0.2f);
        estaNoChao = colliders.Length > 1;
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        
        if(outro.gameObject.tag == "Obstaculo")
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);                
        }
        
        if (outro.gameObject.tag == "Item")
        {
            placar.pontuar(25);
            Destroy(outro.gameObject);
        }
        if(outro.gameObject.tag == "ima")
        {
            atrair.enabled = true;
            Destroy(outro.gameObject);
        }
    }
    private void velocidadeCamera(){
        if (transform.position.x < (camera.transform.position.x-3)){
            velocidade = velocidadeTotal*(float)1.10;
        }
        else if(transform.position.x == (camera.transform.position.x-3)){
            velocidade = velocidadeTotal;
        }
        else if(transform.position.x > (camera.transform.position.x-3)){
            velocidade = velocidadeTotal*(float)0.9;
        }
    }
    public float getvelocidadeTotal(){
        return velocidadeTotal;
    }
}

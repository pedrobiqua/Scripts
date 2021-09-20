using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Velocidade do personagem")]
    public float Speed;

    private Animator animacao;
    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {//                             Eixo X                        Eixo Y                     Eixo Z                  
        Vector3 move = new Vector3((Input.GetAxis("Horizontal")),(Input.GetAxis("Vertical")),0f);
        transform.position += move * Time.fixedDeltaTime * Speed; //Isso é padrão de movimentação

        //Controle de Animações
        if (Input.GetAxis("Horizontal")> 0f)
        {
            animacao.SetBool("Andar", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            Debug.Log("Andar Direita");
            animacao.SetBool("Andar", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Vertical")> 0f)
        {
            animacao.SetBool("AndarCima", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if (Input.GetAxis("Vertical")< 0f)
        {
            animacao.SetBool("AndarBaixo", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if ((Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f))
        {
            animacao.SetBool("Andar", false);
            animacao.SetBool("AndarCima", false);
            animacao.SetBool("AndarBaixo", false);
        }

    }
}

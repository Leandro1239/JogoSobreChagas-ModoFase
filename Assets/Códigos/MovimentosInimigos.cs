using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentosInimigos : MonoBehaviour
{
    //VARIÁVEIS
    private float velMove = 3f;
    private Rigidbody2D rb;
    private bool moveE;
    public Transform limite;
    
    //INICIA
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveE = true;
        Physics2D.IgnoreLayerCollision(9, 9);                   //IGNORA COLISÃO ENTRE OBJETOS COM MESMA LAYER
    }

    // VERIFICA A MOVIMENTAÇÃO
    void Update()
    {
        if (moveE)
        {
            rb.velocity = new Vector2(-velMove, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(velMove, rb.velocity.y);
        }

        VerificaChao();
    }

    // VERIFICA SE TEM CHÃO, SE NÃO TIVER ELE VIRA
    void VerificaChao()
    {
        if (!Physics2D.Raycast(limite.position, Vector2.down, 0.1f))
        {
            Flip();
        }
    }

    //MÉTODO QUE FAZ VIRAR
    void Flip()
    {
        moveE = !moveE;
        Vector3 temp = transform.localScale;

        if (moveE)
        {
            temp.x = Mathf.Abs(temp.x);
        }
        else
        {
            temp.x = - Mathf.Abs(temp.x);
        }

        transform.localScale = temp;
    }
}

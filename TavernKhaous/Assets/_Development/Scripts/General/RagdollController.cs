using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Transform pontoDeControle;
    public float forcaImpulsoVertical = 5f;
    public float proporcaoP = 5f;
    public float proporcaoD = 2f;
    public float limiteAngular = 30f;
    public LayerMask obstaculoLayer;

    private Rigidbody corpo;
    private Vector3 velocidadeDesejada;
    private Vector3 posicaoInicial;

    void Start()
    {
        corpo = GetComponent<Rigidbody>();
        posicaoInicial = transform.position;
    }

    void FixedUpdate()
    {
        ManterEquilibrio();
        SimularLocomocao();
    }

    void ManterEquilibrio()
    {
        Vector3 direcaoParaBaixo = pontoDeControle.position - transform.position;

        corpo.AddForce(direcaoParaBaixo.normalized * forcaImpulsoVertical, ForceMode.Acceleration);

        Quaternion erroAngular = Quaternion.FromToRotation(transform.up, pontoDeControle.up);
        erroAngular = Quaternion.Euler(new Vector3(0f, erroAngular.eulerAngles.y, 0f));

        float torqueProporcional = proporcaoP * erroAngular.eulerAngles.y;
        float torqueDerivativo = proporcaoD * corpo.angularVelocity.y;

        corpo.AddTorque(Vector3.up * (torqueProporcional + torqueDerivativo), ForceMode.Acceleration);
    }

    void SimularLocomocao()
    {
        // Calcula a velocidade desejada com base na entrada do jogador
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        velocidadeDesejada = new Vector3(movimentoHorizontal, 0f, movimentoVertical).normalized * forcaImpulsoVertical;

        // Aplica força para simular a locomoção
        corpo.AddForce(velocidadeDesejada, ForceMode.Acceleration);
    }
}

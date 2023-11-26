using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoSpawn : MonoBehaviour
{
    public GameObject[] tetriminoPrefabs; // Prefabs para as diferentes formas Tetris
    public Transform pontoDeSpawn; // Ponto onde os Tetriminos serão gerados
    public float intervaloDeGeracao = 2.0f; // Intervalo entre a geração de Tetriminos

    private float tempoDaUltimaGeracao;

    private void Start()
    {
        tempoDaUltimaGeracao = Time.time;
    }

    private void Update()
    {
        if (Time.time - tempoDaUltimaGeracao > intervaloDeGeracao)
        {
            GerarTetriminoAleatorio();
            tempoDaUltimaGeracao = Time.time;
        }
    }

    private void GerarTetriminoAleatorio()
    {
        int indiceTetrimino = Random.Range(0, tetriminoPrefabs.Length);
        int posZAleatoria = Random.Range(0, 2); // Gera uma coordenada X aleatória no intervalo de 0 a 10
        
        Vector3 posicaoAleatoria = new Vector3(posZAleatoria, pontoDeSpawn.position.y, posZAleatoria);

        GameObject tetrimino = Instantiate(tetriminoPrefabs[indiceTetrimino], posicaoAleatoria, Quaternion.identity);
    }
}
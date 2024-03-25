using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmController : MonoBehaviour
{
    public Vector2 areaDeSpawn;
    [SerializeField] SnakeController _snake;
    [SerializeField] GameObject Fruta;
    [SerializeField] GameObject[] FrutasEnEscena;

    private void Update()
    {
        if (FrutasEnEscena[0]==null)
        {
            CrearComida();
        }
    }
    public void CrearComida()
    {       
        Vector2 randomPosition = new Vector2(
            Random.Range(-areaDeSpawn.x / 2f, areaDeSpawn.x / 2f),
            Random.Range(-areaDeSpawn.y / 2f, areaDeSpawn.y / 2f)
        ) ;

        // Verificar si el punto aleatorio está dentro de alguno de los colliders en la lista
        foreach (GameObject _snakeCola in _snake.cola)
        {
            if (_snakeCola.gameObject.GetComponent<Collider2D>().bounds.Contains(randomPosition))
            {
                CrearComida();
                return;
            }
        }

        GameObject frutaTmp= Instantiate(Fruta, randomPosition, Quaternion.identity);
        FrutasEnEscena[0]=frutaTmp;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject Fruta;
    public void CrearComida()
    {
        Instantiate(Fruta, transform.position, Quaternion.identity);
    }
}

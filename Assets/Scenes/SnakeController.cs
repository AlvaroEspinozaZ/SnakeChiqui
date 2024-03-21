using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeController : MonoBehaviour
{
    [SerializeField] float velocity,x,y;
    [SerializeField] Vector2 direction;
    [SerializeField] bool directionValidx = true, directionValidy = true, stop=true;
    [SerializeField] List<GameObject> cola=new List<GameObject>();
    [SerializeField] GameObject lose;
    void Start()
    {
        StartCoroutine(Movement());
    }

    // Update is called once per frame
    void Update()
    {
       
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x < 0)
        {
            
            direction = Vector2.left;
            stop = false;
        }     
         
        else if(x>0)
        {
            
            direction = Vector2.right;
            stop = false;
        }
        else if (y < 0)
        {
            direction = Vector2.down;
            stop = false;
        }
        else if (y > 0)
        {
            direction = Vector2.up;
            stop = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            UI_ManagerSinglenton.Instance.UpdateScore();
            UI_ManagerSinglenton.Instance.Prueba();
            GameObject newCola = Instantiate(cola[1]);
            cola.Add(newCola);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Muro")
        {
            lose.SetActive(true);
            stop = true;

        }
    }
    IEnumerator Movement()
    {
        if (!stop)
        {
            Vector3 tmp = new Vector3(direction.x, direction.y, 0);
            transform.position += tmp * (velocity);     
        }
        Vector2 Head = cola[0].transform.position;
        yield return new WaitForSecondsRealtime(0.6f);
        if (!stop)
        {
            if (cola != null)
            {
               
                for (int i = 0; i < cola.Count; i++)
                {
                    Vector3 temp = cola[i].transform.position;
                    cola[i].transform.position = Head;
                    Head = temp;

                    //yield return new WaitForSecondsRealtime(0.6f);
                }
            }
        }
        StartCoroutine(Movement());
    }
}

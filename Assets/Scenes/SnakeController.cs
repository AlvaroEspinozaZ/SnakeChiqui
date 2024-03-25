using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeController : MonoBehaviour
{
    [SerializeField] float velocity=0,x=0,y=0;
    [SerializeField] Vector2 direction;
    [SerializeField] bool directionValidx = true, directionValidy = true, stop=true;
    [SerializeField] public List<GameObject> cola=new List<GameObject>();
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

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x < 0 && direction != Vector2.right)
            {
                direction = Vector2.left;
                stop = false;
            }
            else if (x > 0 && direction != Vector2.left)
            {
                direction = Vector2.right;
                stop = false;
            }
        }
        else if (Mathf.Abs(y) > Mathf.Abs(x))
        {
            if (y < 0 && direction != Vector2.up)
            {
                direction = Vector2.down;
                stop = false;
            }
            else if (y > 0 && direction != Vector2.down)
            {
                direction = Vector2.up;
                stop = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Score_ManagerSinglenton.Instance.UpdateScore();
            Score_ManagerSinglenton.Instance.Prueba();
            GameObject newCola = Instantiate(cola[1], cola[2].transform.position,Quaternion.identity) ;
            cola.Add(newCola);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Muro")
        {
            lose.SetActive(true);
            stop = true;
            StopCoroutine(Movement());
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
                }
            }
        }
        StartCoroutine(Movement());
    }
}

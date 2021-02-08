using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moving : MonoBehaviour
{
    public GameObject efectdestoy;
    Rigidbody rb;
    float x;
    float y;
    float z;
    float destroynow;
    public int golovi;
  
    public Text gols;
    public Text scores;
    public int score;
    public GameObject pausepanel;
    public GameObject tapcont;
    Vector3 pos;
   public float movespeed=20f;
    float dir;
    public Vector3 velocity;
    public GameObject ballenemy;
 
    // public GameObject ball;
    // Start is called before the first frame update
    void Start()
        
    {//golovi= PlayerPrefs.GetInt("golovi");
        PlayerPrefs.SetInt("pause", 0);
        tapcont.SetActive(true);
        pausepanel.SetActive(false);
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody>();
        pausepanel.SetActive(false);
        movespeed = 40f;
        destroynow = 0.5f;
        scores.text = PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Time.timeScale == 0)
        {
            tapcont.SetActive(true);
        }
        else { tapcont.SetActive(false); }
        scores.text = PlayerPrefs.GetInt("score").ToString();
        transform.RotateAround(transform.position, Vector3.up, 200 * Time.deltaTime);
        pos = new Vector3(x, y, z);
         pos= transform.position;
        pos.z = -8;
        transform.position= pos;
        if (PlayerPrefs.GetInt("pause", 0) == 0)
        {
            dir = Input.acceleration.x * movespeed;

            rb.velocity = new Vector3(dir, 0, 0);
            transform.localPosition += velocity * Time.fixedDeltaTime;
        }

       /* if (((Input.touchCount > 0) || (Input.GetMouseButton(0))) && (PlayerPrefs.GetInt("pause", 0)==0))
        {
            velocity = new Vector3(20, 0, 0);
            transform.localPosition += velocity * Time.fixedDeltaTime;
        }
        else
        {
            velocity = new Vector3(-15, 0, 0);
            transform.localPosition += velocity * Time.fixedDeltaTime;
        }*/
        if (!ballenemy.activeSelf)
        {
            x = Random.Range(-4.5f, 4.5f);
            y = 0.8f;
            z = 10;
            pos = new Vector3(x, y, z);
            ballenemy.transform.position = pos;
            ballenemy.SetActive(true);
        }
        if (ballenemy.transform.position.z < -12)
        {
            x = Random.Range(-4.5f, 4.5f);
            y = 0.8f;
            z = 10;
            pos = new Vector3(x, y, z);
            ballenemy.transform.position = pos;
        }
  
    }
   
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "star") 
        {//golovi= PlayerPrefs.GetInt("golovi");
            score = PlayerPrefs.GetInt("score");
            collision.gameObject.SetActive(false);
            Instantiate(efectdestoy,transform.position,Quaternion.identity);
            StartCoroutine(destroyparzicles(destroynow));
            golovi += 1;
            if (PlayerPrefs.GetInt("score") < golovi)
            {
                PlayerPrefs.SetInt("score", golovi);
            }
           // PlayerPrefs.SetInt("golovi",golovi);
            gols.text = golovi.ToString();

            scores.text = PlayerPrefs.GetInt("score").ToString();
        }
    }
    private IEnumerator destroyparzicles(float destroynow)
    {
        yield return new WaitForSeconds(destroynow);
        Destroy(GameObject.FindWithTag("Player"));
        // StartCoroutine(delayedShowBanner(delay));
    }
    public void pauseactive() { pausepanel.SetActive(true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("pause", 1);
        tapcont.SetActive(false);
    }
    public void pausedeactive()
    {
       tapcont.SetActive(true);
        pausepanel.SetActive(false);
        PlayerPrefs.SetInt("pause", 0);
        // Time.timeScale = 1;
    }
    public void looadscene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}



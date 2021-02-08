using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star2 : MonoBehaviour
{
    float x;
    float y;
    float z;
    public AudioClip otherClip;
    public Text gols;
    public int golovi;
    Vector3 pos;
    public GameObject gameoveractive;
    public GameObject ballenemy;
    public GameObject Mainmenu;
    public float delay;
    public GameObject efectdestoy;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        gameoveractive.SetActive(false);
       Mainmenu.SetActive(true);
        golovi = System.Convert.ToInt32(gols.text);
        x = Random.Range(-4.5f, 4.5f);
        y = 0.8f;
        delay = 1;
        z = 10;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        if ((Time.timeScale == 1) && (PlayerPrefs.GetInt("pause", 0) != 1))
        {
            if ((golovi <= 20) && (golovi >= 0)) { velocity = new Vector3(0, 0, -17); }

            if (golovi > 20) { velocity = new Vector3(0, 0, -20); }

            transform.localPosition += velocity * Time.fixedDeltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        golovi = System.Convert.ToInt32(gols.text);
        if ((Time.timeScale == 1) && (PlayerPrefs.GetInt("pause", 0) != 1))
        {
            if ((golovi <= 20) && (golovi >= 0)) { velocity = new Vector3(0, 0, -17); }

            if (golovi > 20) { velocity = new Vector3(0, 0, -20); }

            transform.localPosition += velocity * Time.fixedDeltaTime;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "goal")
        {
            Instantiate(efectdestoy, transform.position, Quaternion.identity);

            GetComponent<AudioSource>().clip = otherClip;
            GetComponent<AudioSource>().Play();
            StartCoroutine(gameover(delay));
        }
    }
    private IEnumerator gameover(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameoveractive.SetActive(true);
        Time.timeScale = 0;
        Destroy(GameObject.FindWithTag("Enemy"));
        Mainmenu.SetActive(false);

      
    }
  
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star3 : MonoBehaviour
{
    float x;
    float y;
    float z;
    public Text gols;
    public int golovi;
    Vector3 pos;
    public GameObject gameoveractive;
    public GameObject Mainmenu;
    public float delay;
    public GameObject efectdestoy;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        gameoveractive.SetActive(false);
        Mainmenu.SetActive(true);
        golovi = System.Convert.ToInt32(gols.text);
        x = Random.Range(-4.5f, 4.5f);
        y = 0.8f;
        delay = 1f;
        z = 18;
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        golovi = System.Convert.ToInt32(gols.text);
        if ((golovi <= 20) && (golovi >= 0)) { velocity = new Vector3(0, 0, -13); }

        if (golovi > 20) { velocity = new Vector3(0, 0, -15); }

        transform.localPosition += velocity * Time.fixedDeltaTime;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "goal")
        {
            Instantiate(efectdestoy, transform.position, Quaternion.identity);

            StartCoroutine(gameover(delay));
        }
    }
    private IEnumerator gameover(float delay)
    {
        yield return new WaitForSeconds(delay);
        //gameoveractive.SetActive(true);
        //Time.timeScale = 0;
        //Mainmenu.SetActive(true);

        // StartCoroutine(delayedShowBanner(delay));
    }

}
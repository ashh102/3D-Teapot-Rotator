// Ashley Maynez
// 11/16/19
// Test 2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileShooter : MonoBehaviour
{
    GameObject prefab;
    public float speed = 2.0f;
    float timeLeft = 30;
    public Text countDown;
    public Text gameOver;
  

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load("projectile") as GameObject;
        count = 0;
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            countDown.text = ("" + timeLeft);
        }
        if (timeLeft <= 0)
        {
            countDown.text = "0";
            gameOver.text = "GAMEOVER";
        }
        
        
        if (Input.GetKeyDown("space"))
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 4;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        


    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

    public GameObject red_circle;
    public GameObject green_circle;
    public GameObject blue_circle;

    GameObject[,] circles = new GameObject[11, 11];

    // Use this for initialization
    void Start () {
        StartCoroutine("CreateDots");
	}
    
    IEnumerator CreateDots()
    {
        System.Random rand = new System.Random();
        for (int y = -20; y <= 20; y += 4)
        {
            for (int x = -20; x <= 20; x += 4)
            {
                int type = rand.Next(3);
                if (type == 0)
                    circles[y / 4 + 5, x / 4 + 5] = Instantiate(red_circle, new Vector3(x / 10.0f, y / 10.0f, -1), Quaternion.identity);
                else if (type == 1)
                    circles[y / 4 + 5, x / 4 + 5] = Instantiate(green_circle, new Vector3(x / 10.0f, y / 10.0f, -1), Quaternion.identity);
                else
                    circles[y / 4 + 5, x / 4 + 5] = Instantiate(blue_circle, new Vector3(x / 10.0f, y / 10.0f, -1), Quaternion.identity);
                object[] param = new object[2] { y / 4 + 5, x / 4 + 5 };
                StartCoroutine("Bounce", param);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
	
    IEnumerator Bounce(object[] param)
    {
        int y = (int)param[0];
        int x = (int)param[1];
        for (float t = 0.0f; t <= 0.2f; t += 0.01f)
        {
            circles[y, x].transform.position = new Vector3((x - 5) * 4.0f / 10.0f, (y - 5) * 4.0f / 10.0f - 20.0f * t * (t - 0.2f), -1.0f);
            yield return new WaitForSeconds(0.01f);
        }
        for (float t = 0.0f; t <= 0.2f; t += 0.01f)
        {
            circles[y, x].transform.position = new Vector3((x - 5) * 4.0f / 10.0f, (y - 5) * 4.0f / 10.0f - 10.0f * t * (t - 0.2f), -1.0f);
            yield return new WaitForSeconds(0.01f);
        }
        circles[y, x].transform.position = new Vector3((x - 5) * 4.0f / 10.0f, (y - 5) * 4.0f / 10.0f, -1.0f);
    }

	// Update is called once per frame
	void Update () {
        
	}
}

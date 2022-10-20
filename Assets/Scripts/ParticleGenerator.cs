using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    public GameObject star;

    private Vector3 starPos;
    private Vector3 starEuler;
    private Vector3 starScale;

    private Color starColor;

    public int starTotal;
    private int starCounter;

    private int setStarTotal;

    private float timer;
    public float interval = 6 ;




    // Start is called before the first frame update
    void Start()
    {
        Randomizestar();
        setStarTotal = starTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else {
            ClearStar();
            GenerateStar();
            timer = interval;
        } 
        
        
    }

    private void Randomizestar()
    {
        starPos = new Vector3(Random.Range(-30, 30), Random.Range(25, 28), Random.Range(-30, 30));
        starEuler = new Vector3(Random.Range(-180, 180), -90f, 0f);
        float newScale = Random.Range(.5f, 1.1f);
        starScale = new Vector3(star.transform.localScale.x, newScale, newScale);
        starColor = new Color(1, 1, 1, Random.value);
    }

    public void GenerateStar()
    {
        while (starCounter < starTotal)
        {
            //generate stars
            GameObject newstar = (GameObject)Instantiate(star, starPos, Quaternion.Euler(starEuler));
            newstar.transform.localScale = starScale;
            //newstar.GetComponent<MeshRenderer>().material.color = starColor;

            //randomize vector 3s again
            Randomizestar();

            //Increment counter
            starCounter += 1;
        }

        // starTotal += setStarTotal;

    }

    public void ClearStar()
    {
        GameObject[] starList = GameObject.FindGameObjectsWithTag("Star");

        foreach (GameObject star in starList)
        {
            GameObject.Destroy(star);
        }
        starCounter = 0;
        starTotal = setStarTotal;
    }

    public void ChangeColor()
    {
        GameObject[] starList = GameObject.FindGameObjectsWithTag("Star");

        foreach (GameObject star in starList)
        {
            star.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

        }
    }

}

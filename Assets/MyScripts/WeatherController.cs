using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public GameObject RainEffect;
    public GameObject SnowEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Sun")
                {
                    RainEffect.SetActive(false);
                    SnowEffect.SetActive(false);
                }
                else if (hit.transform.tag == "Rain")
                {
                    RainEffect.SetActive(true);
                    SnowEffect.SetActive(false);
                }
                else if (hit.transform.tag == "Snow")
                {
                    RainEffect.SetActive(false);
                    SnowEffect.SetActive(true);
                }

                if (hit.transform.tag=="door")
                {
                    DoorController dl = hit.transform.GetComponent<DoorController>();
                    dl.OpenDoor();               
                }
                if (hit.transform.tag == "cat")
                {
                    AnimalsController ac = hit.transform.GetComponent<AnimalsController>();
                    ac.SetMovee();             
                }
            }
        }
    }
}

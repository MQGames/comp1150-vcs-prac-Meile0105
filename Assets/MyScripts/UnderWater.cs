using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{
    // Start is called before the first frame update
    public blurEffect be;
    public GameObject underWaterSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="MainCamera")
        {
            be.enabled = true;
            underWaterSource.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            be.enabled = false;
            underWaterSource.gameObject.SetActive(false);
        }
    }
}

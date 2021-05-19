using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsController : MonoBehaviour
{
    public Transform Person;
    private bool isMove = false;
    private Vector3 lookat;
    private Animator am;
    // Start is called before the first frame update
    void Start()
    {
        lookat = new Vector3();
        am = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            transform.Translate(Person.position * Time.deltaTime * 0.05f);
            lookat.x = Person.position.x;
            lookat.z = Person.position.z;
            am.Play("walk");

            transform.LookAt(lookat);
            if (Vector3.Distance(transform.position,Person.position)<=1f)
            {
                isMove = false;
                am.Play("Idel");
            }
        }
    }
    public void SetMovee() 
    {
        isMove = true;
    }
}

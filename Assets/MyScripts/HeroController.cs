using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // Start is called before the first frame update
    public static HeroController _instance;

    public float speed = 2f;
    public float Rspeed = 50;

    public float JumpSpeed = 200;


    private Animator _anim;
    private Rigidbody _rg;

    private bool _canJump = true;

    public float _HeroHpAll = 100; 
    public float _HeroHp = 100;

    Vector3 moveForward;

    public CurState _curState;

    public enum CurState
    {
        Idle,
        Attack,
        Die
    }
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        Rspeed = 200;
        _anim = GetComponent<Animator>();
        _rg = GetComponent<Rigidbody>();

        _curState = CurState.Idle;
    }

    // Update is called once per frame 
    void Update()
    {
        MovePlay();
    }
    
    private Vector3 _mainF;
    private Vector3 _mainL;
    public void MovePlay() 
    {
        _mainF = Camera.main.transform.forward; 
        _mainL = Camera.main.transform.right; 
       _mainF.y = 0;
       _mainL.y=0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(_mainF  * Time.deltaTime * speed);
       
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-_mainF  * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-_mainL  * Time.deltaTime * speed);
       
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_mainL  * Time.deltaTime * speed);
        }

      

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //预留跳跃
        }
    }     //移动
}

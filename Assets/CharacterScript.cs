using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Animator Animator;
    public int Speed;
    private int _speed;
    private bool isStart = false;
    private float newLeftX = float.MinValue;
    private float newRightX = float.MaxValue;
    private int Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _speed = Speed;
    }

    // Update is called once per frame
    private void Update()
    {
        ScoreText.text = Score.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStart = true;
            _speed = Speed - 2;
            Animator.SetTrigger("run");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isStart)
        {
            _speed = Speed;
            Animator.SetTrigger("left");
            newLeftX = transform.position.x - 3;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && isStart)
        {
            _speed = Speed;
            Animator.SetTrigger("right");
            newRightX = transform.position.x + 3;
        }
    }

    void FixedUpdate()
    {
        

        if (transform.position.x < newLeftX  || transform.position.x > newRightX)
        {
            _speed = Speed - 2;
            Animator.SetTrigger("run");
            newLeftX = float.MinValue;
            newRightX = float.MaxValue;
        }

        if(transform.position.y < -0.1f)
        {
            Animator.SetTrigger("fall");
        }

        if (isStart)
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        Score += 100;
    }
}

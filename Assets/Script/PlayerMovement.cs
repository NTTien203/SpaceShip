
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed=15f;
    [SerializeField] float PaddingLeft;
     [SerializeField] float PaddingRight;
      [SerializeField] float PaddingTop;
       [SerializeField] float PaddingBottom;
    Vector2 rawInput;
    Vector2 maxbound;
    Vector2 minbound;
    Shooter shooter;
     void Awake() {
        shooter= GetComponent<Shooter>();    
    }
     void Start() {
        InitBound();   
        
    }
    void Update()
    {
        Move();
    }

     void Move() 
    {
        Vector2 delta = rawInput * playerSpeed * Time.deltaTime; 
        Vector2 newPos= new Vector2();
        newPos.x=Mathf.Clamp(transform.position.x+delta.x,minbound.x+PaddingLeft,maxbound.x-PaddingRight);
        newPos.y=Mathf.Clamp(transform.position.y+delta.y,minbound.y+PaddingBottom,maxbound.y-PaddingTop);
        transform.position= newPos;
    }

    void InitBound(){
        Camera maincamera=Camera.main;
        minbound =maincamera.ViewportToWorldPoint(new Vector2(0,0));
        maxbound= maincamera.ViewportToWorldPoint(new Vector2(1,1));
       
    }
    void OnMove(InputValue value){
        rawInput= value.Get<Vector2>();
    }
    void OnFire(InputValue value){
        if(shooter!=null){
            shooter.isFiring=value.isPressed;
            
        }
    }
}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour {
    public int currentPlayer=1;


	bool leftDown;
	public bool LeftDown
	{
		get{
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
                return true;
            if (leftDown)
            {
                leftDown = false;
                return true;
            }
            else
            {
                return false;
            }
            }
		set{leftDown = value;}
	}

	bool rightDown;
	public bool RightDown
	{
		get{
            
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                return true;
            if (rightDown)
            {
                rightDown = false;
                return true;
            }
            else
            {
                return false;
            }
          
            
		}
		set{rightDown = value;}
	}

	bool downDown;
	public bool DownDown
	{
		get{
            
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                return true;
            if (downDown)
            {
                downDown = false;
                return true;
            }
            else
            {
                return false;
            }
           
           
		}
		set{downDown = value;}
	}

	bool upDown;
	public bool UpDown
	{
		get{
           
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
                return true;
            if (upDown)
            {
                upDown = false;
                return true;
            }
            else
            {
                return false;
            }
           
           
		}
		set{upDown = value;}
	}

	bool aDown;
	public bool Adown
	{
		get{
           
            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                return true;
            if (aDown)
            {
                aDown = false;
                return true;
            }
            else
            {
                return false;
            }
           
            
		}
		set{aDown = value;}
	}

	bool bDown;
	public bool Bdown
	{
		get{
            
            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Backspace))
                return true;
            if (bDown)
            {
                bDown = false;
                return true;
            }
            else
            {
                return false;
            }
           
            
		}
		set{bDown = value;}
	}

	bool xDown;
	public bool Xdown
	{
		get{
           
            if (Input.GetKeyDown(KeyCode.V))
                return true;
            if (xDown)
            {
                xDown = false;
                return true;
            }
            else
            {
                return false;
            }
           
			
		}
		set{xDown = value;}
	}


	public IEnumerator Wait(float duration)
	{
		print(Time.time);
		yield return new WaitForSeconds (duration);
		print(Time.time);
	}

	void Start()
	{
		
	}

	
	//Il faut penser a faire l'update en fonction de l'exemple de la derniere fois
	void Update()
	{
      
	}

	void FixedUpdate()
	{
		//Se servir de cette méthode pour les mouvements et autres inputs
	}

	
}

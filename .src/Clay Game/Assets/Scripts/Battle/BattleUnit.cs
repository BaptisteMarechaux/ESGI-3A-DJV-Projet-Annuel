﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleUnit : BattleEntity {
	/// Classe décrivant une unité, ses statistiques et certaines de ses actions
	[SerializeField]
	private int power; //Puissance de l'unité
	public int Power{
		get{return power;}
	}
	[SerializeField]
	private int resist; //Résistance de l'unité
	[SerializeField]
	private int movement;
	public int Movement{
		get{return movement;}
	}

	[SerializeField]
	private int range;
	public int Range{
		get{return range;}
	}

	[HideInInspector]
	public bool panelsCreated;
	private bool moving;

	private bool alreadySelected;
	public bool AlreadySelected{
		get{return alreadySelected;}
		set{alreadySelected = value;}
	}

	private List<GameObject> mvtPanels = new List<GameObject>();
	public List<GameObject> MvtPanels{
		get{return mvtPanels;}
	}

	private List<GameObject> rangePanels = new List<GameObject>();
	public List<GameObject> RangePanels{
		get{ return rangePanels;}
	}

    private List<Vector3> tempRangePanels;
    
    public Transform target;
    public TargetDetection targetSelector;
    [SerializeField]
    private float movementSpeed=2;
    private Vector3[] path;
    int targetIndex;
	
	// Use this for initialization
	public override void Start () {
		base.Start();
	}

    public void FindPath()
    {
        if (isEnemy)
        {
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if(pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while(true)
        {
            if(transform.position.x==currentWaypoint.x && transform.position.z == currentWaypoint.z)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    TurnEnded = true;
                    yield break;
                    
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentWaypoint.x, transform.position.y, currentWaypoint.z), movementSpeed*Time.deltaTime);
            yield return null;
           
        }

    }

    
    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void MovementPanelReset()
	{
		panelsCreated=false;
	}
	
	void RangePanelReset()
	{
		panelsCreated=false;
	}
	
	public void PanelReset()
	{
		MovementPanelReset();
		
		RangePanelReset ();
	}

	public void CreateMovementPanels(GameObject mvtObj)
	{
		GameObject tmpMvtClone;
		//Movement Display
		for(int i=0;i<Movement+1;i++)
		{
			for(int j=-i-1;j<i;j++)
			{
				tmpMvtClone =(GameObject)Instantiate(mvtObj, new Vector3(i-Movement, 1, j+1), Quaternion.identity);
				tmpMvtClone.transform.parent = transform;
				tmpMvtClone.transform.localPosition = new Vector3(i-Movement, -0.49f, j+1);
				mvtPanels.Add(tmpMvtClone);
			}
			
		}
		
		for(int i=0;i<Movement;i++)
		{
			for(int j=-i-1;j<i;j++)
			{
				tmpMvtClone =(GameObject)Instantiate(mvtObj, new Vector3(Movement-i, 1, j+1), Quaternion.identity);
				tmpMvtClone.transform.parent = transform;
                tmpMvtClone.transform.localPosition = new Vector3(Movement - i, -0.49f, j + 1);
				mvtPanels.Add(tmpMvtClone);
			}
			
		}
		alreadySelected = true;
	}

	public void Move(Vector3 destination)
	{
		if(moving)
		{
			gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, Time.deltaTime);
		}
	}

    public override void ChangeHP(int amount)
    {
        base.ChangeHP(amount);
        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    
}

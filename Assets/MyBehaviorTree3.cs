using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;

public class MyBehaviorTree3 : MonoBehaviour {

	public Transform[] wanders;
	public GameObject player;
	public GameObject guard;
	//public GameObject test;
	//private BehaviorMecanim gd;
	private BehaviorAgent behaviorAgent;
	// Use this for initialization
	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
		//gd = guard.GetComponent<BehaviorMecanim> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	protected Node ST_ApproachAndWait(GameObject agent, Transform target)
	{
		
		Val<Vector3> position = Val.V (() => (target.position + target.forward*2));
		return new Sequence(agent.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(2000));
	}

	protected Node BuildTreeRoot()
	{ 
		Val<Vector3> p = Val.V (() => player.transform.position);

		return new Sequence (ST_ApproachAndWait (guard, player.transform),
			guard.GetComponent<BehaviorMecanim> ().Node_OrientTowards (p),
			new LeafWait(2000),
			guard.GetComponent<BehaviorMecanim> ().ST_PlayHandGesture ("callover", 5000),
			guard.GetComponent<BehaviorMecanim> ().Node_RunTo (wanders [0].position)
		);
	}
}

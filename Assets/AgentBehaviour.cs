using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentBehaviour : MonoBehaviour {
	public Vector3 destination;
	NavMeshAgent agent;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetButtonDown("Fire1") ){
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				agent.SetDestination (hit.point);
			}
		}


	}*/
	void FixedUpdate()
	{
		//Collider[] hitColliders = Physics.OverlapSphere (transform.position, 10.0f);
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		int i = 0;
		/*while (i < hitColliders.Length) {
			if (hitColliders [i].gameObject.CompareTag ("Player") && Vector3.Distance (transform.position, destination) < 2.8f) {
				agent.isStopped = true;
				return;
			}
			i++;
		}*/
		if (Physics.SphereCast (transform.position, 12.0f, fwd, out hit, 0.00f) && hit.collider.gameObject.CompareTag ("Player")) {
			agent.isStopped = true;
			return;
		} 
		agent.isStopped = false;
	}
}

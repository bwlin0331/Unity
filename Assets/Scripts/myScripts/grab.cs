using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class grab : MonoBehaviour {

	#region Data
	[SerializeField]
	Transform myRightHandMiddleFinger;
	Transform myRightHand;
	[SerializeField]
	GameObject target;

	Animator animator;
	Transform Zoe;
	private readonly int iG = Animator.StringToHash("isGrab");
	static readonly Vector3 offset = new Vector3(0.2f, .04f, 0);

	Vector3 myRightMiddleFingerPosition, myRightHandPosition;
	Quaternion myRightMiddleFingerRotation;
	#endregion

	float percentComplete{
		get{
			AnimatorStateInfo currentAnimation = animator.GetCurrentAnimatorStateInfo (0);
			float percent = currentAnimation.normalizedTime % 1;
			percent *= 2;
			if (percent > 1) {
				percent = 2 - percent;
			}
			return percent;
		}
	}

	private void Awake(){
		animator = GetComponent<Animator> ();
		myRightHand = myRightHandMiddleFinger.parent;
	}



	void Update(){
		
		if (Input.GetKeyDown ("g") == true) {
			animator.SetBool (iG, true);
			myRightMiddleFingerPosition = myRightHandMiddleFinger.position;
			myRightMiddleFingerRotation = myRightHandMiddleFinger.rotation;
			myRightHandPosition = myRightHand.position;

		} 
	}
	void OnAnimatorIK(){
		Vector3 targetPosition = target.transform.position;
		targetPosition += myRightMiddleFingerPosition + myRightMiddleFingerRotation * offset - myRightHandPosition;
		animator.SetIKPosition (AvatarIKGoal.RightHand, targetPosition);
		animator.SetIKPositionWeight (AvatarIKGoal.RightHand, percentComplete);

	}
}

using UnityEngine;
using System.Collections;

public class Char : MonoBehaviour {

	public enum State {
		Idle,
		Walk,
		Run,
		Jump,
	}

	public enum MoveType { Xy, Yz, Zx }
	public MoveType moveType;
	float speed = 1;

	const int movePoint = 3;
	int stateNum = 0;
	int reverse = 1;
	float t = 0;
	Vector3 vec = Vector3.zero;
	Vector3 [] point = new Vector3 [movePoint];
	Quaternion quat = Quaternion.identity;

	void Start () {
		
		//	移動軸 (x, y)
		if (moveType == MoveType.Xy) {
			transform.position = new Vector3 (0.025f, 0.509f, -0.069f);
			quat = Quaternion.AngleAxis (90, Vector3.left);
			transform.rotation = quat;

			point [0] = new Vector3 (0.025f, 0.509f, -0.069f);
			point [1] = new Vector3 (0.025f, -0.014f, -0.069f);
			point [2] = new Vector3 (0.331f, -0.0235f, -0.069f);
		}

		//	移動軸 (y, z)
		if (moveType == MoveType.Yz) {
			transform.position = new Vector3 (0.064f, 0.49f, 0.286f);
			quat = Quaternion.AngleAxis (90, Vector3.back);
			transform.rotation = quat;

			point [0] = new Vector3 (0.064f, 0.102f, -0.011f);
			point [1] = new Vector3 (0.064f, 0.49f, -0.011f);
			point [2] = new Vector3 (0.064f, 0.49f, 0.394f);
		}

		//	移動軸 (x, z)
		if (moveType == MoveType.Zx) {
			transform.position = new Vector3 (0.02f, -0.063f, -0.005f);
			quat = Quaternion.AngleAxis (180, Vector3.forward);
			transform.rotation = quat;

			point [0] = new Vector3 (0.502f, -0.063f, -0.2486f);
			point [1] = new Vector3 (0.502f, -0.063f, -0.005f);
			point [2] = new Vector3 (0.02f, -0.063f, -0.005f);
		}
		GetComponent<Animator> ().SetInteger ("State", (int)State.Walk);
	}
	
	void Update () {
		MoveAlgorithm ();

		transform.position = vec;
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (point [stateNum+1] - transform.position, quat * Vector3.up), 0.1f);
	}

	void MoveAlgorithm () {

		for(int i = 0; i < movePoint; i++){

			int next_i = i + 1, c = 0;
			if(next_i == movePoint) { next_i = 0; }
			if(reverse < 0) { c = movePoint-1; }
			if(t > 1) { stateNum++; t = 0; }
			if(stateNum == movePoint-1) { stateNum = 0; reverse *= -1; }

			if(t < 1 && stateNum == i){
				vec = point [reverse * i + c] * (1 - t) + point [reverse * next_i + c] * t;
				vec = Leap(point [reverse * i + c], point [reverse * next_i + c], t);
				t += 0.005f * speed;
			}
		}
	}

	//	補間
	Vector3 Leap(Vector3 s, Vector3 e, float t){
		return ((e - s) * -2*t*t*t) + (e - s) * 3*t*t + s;
	}
}

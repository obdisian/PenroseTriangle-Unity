using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	Vector3 pos;
	Vector3 lookAt;

	float angle = 0;

	void Start () {

		pos = new Vector3 (9.11f, -8.71f, -6.88f);
		lookAt = Vector3.one * (Map.MaxLength * 0.1f) / 2;

		transform.position = pos;
	}
	
	void Update () {
		angle += 0.5f;
		transform.rotation = Quaternion.LookRotation (lookAt/3 - transform.position,Quaternion.AngleAxis (angle, lookAt/3 - transform.position) * Vector3.up * 4);
	}
}

using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public GameObject cube, hafeCube;

	public static readonly int MaxLength = 5;

	void Start () {

		float f = 0.1f;

		for (int i = 0; i < MaxLength; i++) {
			if (i == MaxLength - 1) {
				Instantiate (hafeCube, new Vector3 (i * f, 0, 0), Quaternion.AngleAxis (90, Vector3.up));
			} else {
				Instantiate (cube, new Vector3 (i * f, 0, 0), Quaternion.identity);
			}
		}
		for (int i = 0; i < MaxLength; i++) {
			Instantiate (cube, new Vector3 (0, i * f, 0), Quaternion.identity);
		}
		for (int i = 0; i < MaxLength; i++) {
			Instantiate (cube, new Vector3 (0, MaxLength * f, i * f), Quaternion.identity);
		}
	}
	
	void Update () {
	
	}
}

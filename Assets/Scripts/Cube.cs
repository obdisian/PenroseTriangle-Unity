using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public GameObject quad;

	void Start () {
		for (int i = 0; i < 4; i++) {
			GameObject obj = Instantiate (quad, transform.position, Quaternion.AngleAxis (90 * i, Vector3.up)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Rectangle);
			obj.GetComponent<Renderer> ().material.color = Color.gray;
			obj.transform.SetParent (transform);
		} {
			GameObject obj = Instantiate (quad, transform.position, Quaternion.AngleAxis (90, Vector3.right)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Rectangle);
			obj.transform.SetParent (transform);
		} {
			GameObject obj = Instantiate (quad, transform.position, Quaternion.AngleAxis (90, Vector3.left)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Rectangle);
//			obj.GetComponent<Renderer> ().material.color = Color.grey;
			obj.transform.SetParent (transform);
		}
	}
}

using UnityEngine;
using System.Collections;

public class HafeCube : MonoBehaviour {

	public GameObject quad;

	void Start () {
		{
			GameObject obj = Instantiate (quad, transform.position, transform.rotation * Quaternion.AngleAxis (90, Vector3.up) * Quaternion.AngleAxis (180, Vector3.forward)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Triangle);
			obj.GetComponent<Renderer> ().material.color = Color.gray;
			obj.transform.SetParent (transform);
		} {
			GameObject obj = Instantiate (quad, transform.position, transform.rotation * Quaternion.AngleAxis (90 * 2, Vector3.up)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Rectangle);
			obj.GetComponent<Renderer> ().material.color = Color.gray;
			obj.transform.SetParent (transform);
		} {
			GameObject obj = Instantiate (quad, transform.position, transform.rotation * Quaternion.AngleAxis (90 * 3, Vector3.up) * Quaternion.AngleAxis (90, Vector3.forward)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Triangle);
			obj.GetComponent<Renderer> ().material.color = Color.gray;
			obj.transform.SetParent (transform);
		} {
			GameObject obj = Instantiate (quad, transform.position, transform.rotation * Quaternion.AngleAxis (90, Vector3.right)) as GameObject;
			obj.GetComponent<Quad> ().Init (Quad.Polygon.Rectangle);
//			obj.GetComponent<Renderer> ().material.color = Color.grey;
			obj.transform.SetParent (transform);
		}
	}
}

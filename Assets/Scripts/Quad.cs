using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]
public class Quad : MonoBehaviour {

	Mesh mesh;

	float scale = 0.5f;


	public enum Polygon {
		Triangle,
		Rectangle,
		Cube,
		HafeCube,
	}

	public void Init (Polygon type)
	{
		mesh = new Mesh ();

		mesh.vertices = new Vector3[] {
			new Vector3 (-1,  1,  1) * scale,
			new Vector3 ( 1,  1,  1) * scale,
			new Vector3 (-1, -1,  1) * scale,
			new Vector3 ( 1, -1,  1) * scale,
			new Vector3 (-1,  1, -1) * scale,
			new Vector3 ( 1,  1, -1) * scale,
			new Vector3 (-1, -1, -1) * scale,
			new Vector3 ( 1, -1, -1) * scale,
		};

		switch (type) {
		case Polygon.Triangle 	: CreateTriangle (); 	break;
		case Polygon.Rectangle 	: CreateRectangle (); 	break;
		case Polygon.HafeCube 	: CreateHafeCube (); 	break;
		case Polygon.Cube 		: CreateCube (); 		break;
		}

//		mesh.RecalculateNormals();
//		mesh.RecalculateBounds();
		mesh.Optimize();

		GetComponent<MeshFilter> ().sharedMesh = mesh;
	}

//	void Start () {
//		Init (Polygon.Rectangle);
//	}

//	void Update () {
//		transform.rotation = Quaternion.AngleAxis (3, Vector3.up + Vector3.right) * transform.rotation;
//	}



	void CreateTriangle ()
	{
		mesh.triangles = new int[] {
			0, 2, 1,
		};
	}

	void CreateRectangle ()
	{
		mesh.triangles = new int[] {
			0, 2, 1, 3, 1, 2,
		};
	}

//================================================================================
//	三角形作成
//================================================================================
	void CreateHafeCube ()
	{
		mesh.triangles = new int[] {

			//	後面
			4, 5, 6, 7, 6, 5,

			//	右面
			7, 5, 3,

			//	左面
			6, 2, 4,

			//	下面
			6, 7, 2, 3, 2, 7,
		};
	}


//================================================================================
//	四角形作成
//================================================================================
	void CreateCube ()
	{
//		Vector3 [] rect = {
//			new Vector3 (-1,  1,  1),
//			new Vector3 ( 1,  1,  1),
//			new Vector3 (-1, -1,  1),
//			new Vector3 ( 1, -1,  1),
//		};
//
//		Vector3 [] vert = new Vector3 [6 * 4];
//
//		//	側面
//		for (int i = 0; i < 4; i++) {
//			vert [0 + i * 4] = Quaternion.AngleAxis (90 * i, Vector3.up) * rect [0] * scale;
//			vert [1 + i * 4] = Quaternion.AngleAxis (90 * i, Vector3.up) * rect [1] * scale;
//			vert [2 + i * 4] = Quaternion.AngleAxis (90 * i, Vector3.up) * rect [2] * scale;
//			vert [3 + i * 4] = Quaternion.AngleAxis (90 * i, Vector3.up) * rect [3] * scale;
//		}
//
//		//	上面
//		vert [4 * 4 + 0] = Quaternion.AngleAxis (90, Vector3.right) * rect [0] * scale;
//		vert [4 * 4 + 1] = Quaternion.AngleAxis (90, Vector3.right) * rect [1] * scale;
//		vert [4 * 4 + 2] = Quaternion.AngleAxis (90, Vector3.right) * rect [2] * scale;
//		vert [4 * 4 + 3] = Quaternion.AngleAxis (90, Vector3.right) * rect [3] * scale;
//
//		//	下面
//		vert [4 * 5 + 0] = Quaternion.AngleAxis (90, Vector3.left) * rect [0] * scale;
//		vert [4 * 5 + 1] = Quaternion.AngleAxis (90, Vector3.left) * rect [1] * scale;
//		vert [4 * 5 + 2] = Quaternion.AngleAxis (90, Vector3.left) * rect [2] * scale;
//		vert [4 * 5 + 3] = Quaternion.AngleAxis (90, Vector3.left) * rect [3] * scale;
//
//		//	ログ
//		for (int i = 0; i < 6; i++) {
//			Debug.Log ("vert ("
//				+ vert [0 + i] + ", "
//				+ vert [1 + i] + ", "
//				+ vert [2 + i] + ", "
//				+ vert [3 + i] + ")");
//		}
//
//		mesh.vertices = vert;
//
//
//		int [] quad = { 0, 2, 1, 3, 1, 2, };
//
//		int [] poly = new int [6 * 6];
//		for (int i = 0; i < 6; i++) {
//			
//			poly [0 + i] = quad [0] + i * 4;
//			poly [1 + i] = quad [1] + i * 4;
//			poly [2 + i] = quad [2] + i * 4;
//			poly [3 + i] = quad [3] + i * 4;
//			poly [4 + i] = quad [4] + i * 4;
//			poly [5 + i] = quad [5] + i * 4;
//
//			Debug.Log ("poly ("
//				+ poly [0 + i] + ", "
//				+ poly [1 + i] + ", "
//				+ poly [2 + i] + ", "
//				+ poly [3 + i] + ", "
//				+ poly [4 + i] + ", "
//				+ poly [5 + i] + ")");
//		}
//
//		mesh.triangles = poly;



		mesh.triangles = new int[] {

			//	前面
			0, 2, 1, 3, 1, 2,

			//	後面
			4, 5, 6, 7, 6, 5,

			//	右面
			1, 3, 5, 7, 5, 3,

			//	左面
			4, 6, 0, 2, 0, 6,

			//	上面
			4, 0, 5, 1, 5, 0,

			//	下面
			6, 7, 2, 3, 2, 7,
		};
	}
}

using UnityEngine;
using System.Collections;

public class Ground: MonoBehaviour {

	public GameObject ground1;
	public GameObject ground2;
	public bool parar = false;
	private float speedX = - 6;

	void Start(){		
		ground2.transform.position = CalculateNextFloorPos(ground2,ground1);
	}

	private Vector3 CalculateNextFloorPos(GameObject obj, GameObject refObj){
		
		float objPosX = refObj.GetComponent<Renderer>().bounds.size.x + refObj.transform.position.x;

		Vector3 newObjPos = new Vector3(objPosX,
			refObj.transform.position.y,
			refObj.transform.position.z);

		return newObjPos;
	}

	void Update () {

		if (!parar) {
			ground1.transform.Translate (new Vector3 (speedX, 0, 0) * Time.deltaTime);
			ground2.transform.Translate (new Vector3 (speedX, 0, 0) * Time.deltaTime);
		}

		if(ground1.transform.position.x < -60f){
			ground1.transform.position = CalculateNextFloorPos(ground1,ground2);
		}

		if(ground2.transform.position.x < -60f){
			ground2.transform.position = CalculateNextFloorPos(ground2,ground1);
		}

	}
}

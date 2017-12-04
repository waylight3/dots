using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//Singleton
	private GameManager instance;
	public GameManager Instance{
		get{
			return instance;
		}
	}

	private Camera main_camera;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else{
			Destroy(this.gameObject);
		}
	}

	void Start(){
		main_camera = GameObject.FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		// Check whether dot or not
		if(Input.GetMouseButton(0)){
			Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 100f);

			if(hit.collider != null){
				Debug.Log("check");
			}
		}
	}
}

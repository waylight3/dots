using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color{
	Red = 0,
	Green,
	Blue
}

public class Dot : MonoBehaviour {
	public Color color{
		get{
			return color;
		}
		set{
			color = value;
		}
	}
	

}

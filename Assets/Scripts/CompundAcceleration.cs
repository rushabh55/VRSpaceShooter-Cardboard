using UnityEngine;
using System.Collections;

public class CompundAcceleration : MonoBehaviour {
    public float speed = .001f;
	void Start () {
	
	}
	
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, speed);
	}
}

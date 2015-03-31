using UnityEngine;
using System.Collections;

public class SimpleAcceleration : MonoBehaviour {
    public Vector3 velocity = new Vector3();
    public float speed = 10;
    public Vector3? _target;
	void Start () {
	
	}
	
	void Update () {
	
	}

    void FixedUpdate() {
        if ( _target == null )
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + velocity, speed == 0 ? Time.deltaTime * 10: speed);
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _target.Value, speed);
        }
    }
}

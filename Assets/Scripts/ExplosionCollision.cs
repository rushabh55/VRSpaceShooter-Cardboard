using System.Linq;
using UnityEngine;
using System.Collections;

public class ExplosionCollision : MonoBehaviour {
    public GameObject _explosionParticleEffect = null;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Bullet")
        {
            // Debug.Break();
            GameObject.Destroy(c.gameObject);
            GameObject.Destroy(this.transform.parent.gameObject);
            var eff = (GameObject)GameObject.Instantiate(_explosionParticleEffect, c.contacts.FirstOrDefault().point, Quaternion.identity);
            GameObject.Destroy(eff, 10);
        }
        
    }

    void OnTriggerEnter()
    {
    }
}

using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

    public GameObject _lostGUI;
    public GameObject _camera;
    public GameObject _lcamera;
    public GameObject _rcamera;
    public int health = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "EnemyBullet")
        {
            health--;
            if (health <= 0)
            {
                _lostGUI.SetActive((true));
                Time.timeScale = 0;
                MakeStereo.DisposeGameObject();
                GameObject.Destroy(c.gameObject);
            }
        }
    }
}

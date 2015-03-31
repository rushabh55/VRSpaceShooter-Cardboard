using UnityEngine;
using System.Collections;

public class StarPlace : MonoBehaviour {
    public GameObject _starPrefab;
    public int maxStars = 1000; 
	void Start () {
        System.Random r = new System.Random(Random.Range(int.MinValue, int.MaxValue));
	    for(int i = 0; i< maxStars; i++)
        {
            r = new System.Random(Random.Range(int.MinValue, int.MaxValue));
            if ( _starPrefab )
            {
                var pos = new Vector3();
                pos.x = r.Next(int.MinValue / 4000, int.MaxValue / 4000);
                pos.y = r.Next(int.MinValue / 4000, int.MaxValue / 4000);
                pos.z = r.Next(int.MinValue / 4000, int.MaxValue / 4000);
                var star = (GameObject) GameObject.Instantiate(_starPrefab, pos, Quaternion.identity);
                var brightness = r.Next(0, int.MaxValue) * (0.125f / int.MaxValue);
                Debug.Log(brightness);

                var flare = star.GetComponent<LensFlare>();
                flare.brightness = (float)brightness;
            }
        }
	}
	
	void Update () {
	    
	}
}

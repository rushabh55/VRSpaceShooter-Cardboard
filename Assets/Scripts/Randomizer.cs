using UnityEngine;
using System.Collections;

public class Randomizer : MonoBehaviour {
    public bool tween = false;
    public int min = 0;
    public int max = 0;
    public TextMesh _mesh = null;
    public int tweenFactor = 5;

    private static System.Random r = new System.Random(Random.Range(0, int.MaxValue));
	// Use this for initialization
	void Start () {
        StartCoroutine(routine());
	}
	
    IEnumerator routine()
    {
        while (true)
        {
            r = new System.Random(Random.Range(0, int.MaxValue));
            if (tween)
            {
                var currValue = System.Convert.ToInt32(_mesh.text);
                var mn = (min > (currValue - tweenFactor)) ? min : currValue - tweenFactor;
                var mx = (max > (currValue + tweenFactor)) ? max : currValue + tweenFactor;
                _mesh.text = r.Next(mn, mx).ToString();

            }
            yield return new WaitForSeconds(1);
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        
	}
}

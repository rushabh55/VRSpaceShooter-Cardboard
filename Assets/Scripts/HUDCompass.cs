using UnityEngine;
using System.Collections;

public class HUDCompass : MonoBehaviour {
    public SpriteRenderer compTex;
    public float camAngle;
    public Camera leftCam;
    public float min, max;
    void Start()
    {
        CardboardGUI.onGUICallback += OnGUI;
    }

    void Destroy()
    {
        CardboardGUI.onGUICallback -= OnGUI;
    }

    void OnGUI()
    {
        camAngle = leftCam.transform.eulerAngles.magnitude;

        var range = max - min;
        var pos = compTex.transform.position;
        pos.x = camAngle / 360 * range + min;
        compTex.transform.position = pos;
        // // // Debug.Log(pos.x);

    }
	
	// Update is called once per frame
	void Update () {
	}
}

using UnityEngine;
using System.Collections;

public enum Eye
{
    Left,
    Right
}
public class MakeStereo : MonoBehaviour {
    public RectTransform _t;
    public Eye _eye;
    public Camera eye;
    public GameObject _player;
	void Start () {
	
	}
	
	void Update () {
        if ( _eye == Eye.Left )
        {
            var pos = _t.position;
            pos.x = -eye.pixelWidth / 2;
            _t.position = pos;
        }
        else
        {
            var pos = _t.position;
            pos.x = +eye.pixelWidth / 2;
            _t.position = pos;
        }
	}

    public static void DisposeGameObject()
    {
        var _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
        {
            GameObject.Destroy(_player);
            Debug.Log("Done");
        }
    }
}

using UnityEngine;
using System.Collections;

public class MissileApproaching : MonoBehaviour {
    public AudioSource _src;

	void Start () {
	
	}
	
	void Update () {
        StartCoroutine(PlaySoundIfNear());
	}

    private IEnumerator PlaySoundIfNear()
    {
        if (!_src.isPlaying)
        {
            var objs = GameObject.FindGameObjectsWithTag("EnemyBullet");
            foreach (var t in objs)
            {
                if (Vector3.Distance(t.transform.position, this.transform.position) < 250)
                {
                    _src.Play();
                    yield return new WaitForSeconds(_src.clip.length);
                }
            }
        }
    }
}

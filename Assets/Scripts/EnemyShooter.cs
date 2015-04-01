using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
    public GameObject _bullet = null;
    public GameObject _player = null;
    bool isActive = false;
    public GameObject TempObject = null;
	void Start () {
        if (!_player)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        isActive = true;
        StartCoroutine(ShootBullet());
	}

    ~EnemyShooter()
    {
        isActive = false;
    }

    private IEnumerator ShootBullet()
    {
        while(isActive && _player != null)
        {
            var bullet = GameObject.Instantiate(_bullet);
            var velocity = bullet.AddComponent<SimpleAcceleration>();
            bullet.transform.position = this.transform.position;
            bullet.tag = "EnemyBullet";
            velocity.velocity = _player.transform.position - bullet.transform.position;
            bullet.transform.LookAt(_player.transform);
            velocity.speed = 10;
            if (TempObject == null)
            {
                TempObject = GameObject.FindGameObjectWithTag("MissileTempObjectCollection");
            }

            bullet.transform.parent = TempObject.transform;
            GameObject.Destroy(bullet, 15);
            yield return new WaitForSeconds(2f);
        }
    }
	void Update () {
	    
	}
}

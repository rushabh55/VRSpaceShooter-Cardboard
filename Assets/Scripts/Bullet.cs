using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject bulletPrefab = null;
    private GameObject bullet { get { return bulletPrefab; } set { bulletPrefab = value; } }

    public GameObject controller = null;

    public Transform target = null;

    public float cooldown = 5; // sec

    private float prevTime = 0;

    public Texture crossHair = null;

    public Camera leftCamera, rightCamera;
    private Rect left_crossHairRect = new Rect();
    private Rect right_crossHairRect = new Rect();
    public int crossHairScaleFactor;

    public int adjustmentFactor = 1;
    
//    public GameObject _scouterTex = null;
    public GameObject[] spawnPoints = null;
	void Start () {
        left_crossHairRect.width = crossHairScaleFactor;
        left_crossHairRect.height = crossHairScaleFactor;
        right_crossHairRect.width = crossHairScaleFactor;
        right_crossHairRect.height = crossHairScaleFactor;
        left_crossHairRect.x = leftCamera.pixelRect.x + leftCamera.pixelWidth / 2 - left_crossHairRect.width / 2 + 40;
        left_crossHairRect.y = leftCamera.pixelRect.y + leftCamera.pixelHeight / 2 - left_crossHairRect.height ;
        right_crossHairRect.x = rightCamera.pixelRect.x + rightCamera.pixelWidth / 2 - right_crossHairRect.width / 2 - 40;
        right_crossHairRect.y = rightCamera.pixelRect.y + rightCamera.pixelHeight / 2 - right_crossHairRect.height;
        left_crossHairRect.x += (int)adjustmentFactor;
        right_crossHairRect.x -= (int)adjustmentFactor;
        CardboardGUI.onGUICallback += this.OnGUI;
	}
    void OnDestroy()
    {
        CardboardGUI.onGUICallback -= this.OnGUI;
        // ...
    }
	void Update () {
        if ( prevTime + cooldown <= Time.time  )
        {
            foreach (var pt in spawnPoints)
            {
                if (bullet != null && pt != null )
                {
                    var Bullet = (GameObject)GameObject.Instantiate(bullet, pt.transform.position, Quaternion.Euler(this.transform.forward));
                    var simpleAcc = Bullet.AddComponent<SimpleAcceleration>();
                    Bullet.tag = "Bullet";
                    if (target != null)
                    {
                        simpleAcc.velocity = target.transform.position - pt.transform.position;
                    }
                    else
                    {
                        simpleAcc.velocity = leftCamera.transform.forward;
                        simpleAcc.speed = 10;
                    }


                    GameObject.Destroy(Bullet, 5f);
                }
            }
            prevTime = Time.time;
        }
	}

    void OnGUI()
    {
        CardboardGUI.IsGUIVisible = true;
        GUI.DrawTexture(left_crossHairRect, crossHair);
        GUI.DrawTexture(right_crossHairRect, crossHair);
    }

    void DistanceAdjust()
    {
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public GameObject _enemy = null;
    public int count = 100;
    public int range = 1000;
    public GameObject _player = null;
	void Start () {
	    for(int i = 0; i < count; i++)
        {
            var enemy = (GameObject)GameObject.Instantiate(_enemy);
            System.Random r = new System.Random(Random.Range(1, System.DateTime.Now.Millisecond));
            if( enemy != null)
            {
                r = new System.Random(Random.Range(1, System.DateTime.Now.Millisecond));
                Vector3 pos = new Vector3();
                pos.x = r.Next(-range * 6, range * 6);
                pos.y = r.Next(-range * 3, range * 3);
                pos.z = r.Next(400 , 400 + range * 4);
                enemy.transform.position = pos;
                enemy.transform.LookAt(_player.transform);
                var diff = _player.transform.position - enemy.transform.position;
                var simpleAcc = enemy.AddComponent<SimpleAcceleration>();
                simpleAcc.velocity = diff;
                simpleAcc.speed = (float)r.NextDouble() + 1;
                simpleAcc._target = _player.transform.position;
                var playerInfo = enemy.GetComponent<GetPlayerInfo>();
                //var spriteRenderer = playerInfo._playerDP.GetComponent<SpriteRenderer>();
                var text = playerInfo._playerDP.GetComponent<TextMesh>();
                if ( MenuController._friendData.Count > i )
                    text.text
                        = MenuController._friendData[i].name;
                // StartCoroutine(LoadTex(spriteRenderer, i, enemy));                
            }
        }
	}

    //IEnumerator LoadTex(SpriteRenderer sp, int i, GameObject go)
    //{
    //    Texture2D tex = new Texture2D(100, 100, TextureFormat.DXT1, false);
    //    while (true)
    //    {
    //        // Start a download of the given URL
    //        var www = new WWW(MenuController._friendData[i].picture.url);

    //        // wait until the download is done
    //        yield return www;

    //        try
    //        {
    //            // assign the downloaded image to the main texture of the object
    //            www.LoadImageIntoTexture(tex);
    //        }
    //        catch(System.Exception e)
    //        {

    //        }
    //        Texture2D tex1 = new Texture2D(100, 100, TextureFormat.DXT1, false);
    //        tex1 = www.texture;
    //        Debug.Log(tex1);
    //        TexToSprite(tex1, sp);
    //        TexToSprite(tex, sp);
    //        go.transform.LookAt(_player.transform);
            
    //    }
    //}

    //void TexToSprite(Texture2D tex, SpriteRenderer sp)
    //{
    //    if( tex != null )
    //        sp.sprite = Sprite.Create(tex, new Rect(0, 0, 100, 100), Vector2.zero);
    //}
	
	void Update () {
	
	}
}

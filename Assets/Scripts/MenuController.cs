using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

    public abstract class FBData
    {
        public string[] data = null;
    }
    public class Picture    : FBData
    {
        public bool is_silhoutte = false;
        public string url = string.Empty;
    }
    public class FriendData : FBData
    {
        public string id = string.Empty;
        public string name = string.Empty;
        public Picture picture = null;
    }
public class MenuController : MonoBehaviour {
    public Texture tex;
    public RawImage img;
    public static List<FriendData> _friendData = new List<FriendData>();
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadSceneWithoutStereo()
    {

    }

    public void LoadScene(int levelId)
    {
        StartCoroutine(Load(levelId));
    }

    public IEnumerator Load(int levelId)
    {
        yield return new WaitForSeconds(1.5f);
        AsyncOperation nextLevel = Application.LoadLevelAsync(levelId);
        yield return nextLevel.isDone;    
    }

    public void FacebookLogin()
    {
        FB.Init(onInitComplete);
    }

    private void onInitComplete()
    {
        FB.Login("email,user_likes,user_friends,read_friendlists,user_friendlist,public_profile", loginComplete);
    }

    private void loginComplete(FBResult result)
    {
        FB.API(FB.UserId + "/taggable_friends?" + FB.AccessToken, Facebook.HttpMethod.GET, NameCallBack);
       // FB.API("/me/picture", Facebook.HttpMethod.GET, NameCallBack);
    }

    private void NameCallBack(FBResult result)
    {
        Debug.Log(result);
        var w = Facebook.MiniJSON.Json.Deserialize(result.Text) as IDictionary;
        Debug.Log(w.GetType());
        var ty = w["data"].GetType();
        foreach (var t in (IList)w["data"])
        {
            var data = t as IDictionary;
            FriendData fd = new FriendData();
            fd.id = (string)data["id"];
            fd.name = (string)data["name"];
            fd.picture = new Picture();
            var war = (IDictionary)data["picture"];
            var pt = ((IDictionary)war["data"])["url"].GetType();
            fd.picture.url = (string)((IDictionary)war["data"])["url"];
            _friendData.Add(fd);
        }
        img.texture = result.Texture;
    }
}

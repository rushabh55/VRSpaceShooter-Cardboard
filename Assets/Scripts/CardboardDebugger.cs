using UnityEngine;
using System.Collections;
using System.Text;

public class CardboardDebugger : MonoBehaviour {
    static StringBuilder sb = new StringBuilder();
	// Use this for initialization
    void Start()
    {
        CardboardGUI.IsGUIVisible = true;
        CardboardGUI.onGUICallback += this.OnGUI;
        appendString("100");
        // ...
    }

    void OnDestroy()
    {
        CardboardGUI.onGUICallback -= this.OnGUI;
        // ...
    }

    void OnGUI()
    {
        if (!CardboardGUI.OKToDraw(this)) return;
        GUI.Box(new Rect(Screen.height - 300, Screen.width - 100, 300, 100), sb.ToString());
 
    }

    public static void appendString(string s)
    {
        sb.Append(s);
    }

}

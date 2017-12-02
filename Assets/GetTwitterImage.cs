using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTwitterImage : MonoBehaviour {

	public InputField field;

	public IEnumerator LoadPlayerImage(){
		string username = field.textComponent.text;
		Debug.Log (username);
		Texture2D tex;
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW("https://twitter.com/"+username+"/profile_image?size=original");
		yield return www;
		www.LoadImageIntoTexture(tex);
		GetComponent<Renderer>().material.mainTexture = tex;
	}
}


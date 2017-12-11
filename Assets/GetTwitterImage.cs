using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTwitterImage : MonoBehaviour {

	string username;

	IEnumerator LoadPlayerImage(){
		Texture2D tex;
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW("https://twitter.com/"+username+"/profile_image?size=original");
		yield return www;
		www.LoadImageIntoTexture(tex);
		GetComponent<Renderer>().material.mainTexture = tex;
	}

	public void LoadImage(string username){
		this.username = username;
		StartCoroutine (LoadPlayerImage());
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTwitterImage : MonoBehaviour {

	public string url = "https://twitter.com/lucasrijllart/profile_image?size=original";
	IEnumerator Start() {
		Texture2D tex;
		tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
		WWW www = new WWW(url);
		yield return www;
		www.LoadImageIntoTexture(tex);
		GetComponent<Renderer>().material.mainTexture = tex;
	}
}


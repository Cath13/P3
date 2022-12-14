using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//source: https://github.com/yasirkula/UnityNativeCamera

public class AndroidCamera : MonoBehaviour
{
	GameObject quad;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// Don't attempt to use the camera if it is already open
			if (NativeCamera.IsCameraBusy())
				return;
		}

	}

	public void Destroy()
	{
		Destroy(quad);
	}

	public void TakePicture(int maxSize)
	{
		NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
		{
		
			if (path != null)
			{
				// Create a Texture2D from the captured image
				Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
				

				// Assign texture to a quad
				quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
				quad.transform.forward = Camera.main.transform.forward;
				quad.transform.localScale = new Vector3(1.4f, 2.3f, 1f);

				Material material = quad.GetComponent<Renderer>().material;
				if (!material.shader.isSupported) // happens when Standard shader is not included in the build
					material.shader = Shader.Find("Legacy Shaders/Diffuse");

				material.mainTexture = texture;

			}
		}, maxSize);
	}
}

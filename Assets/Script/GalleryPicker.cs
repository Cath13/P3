using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://github.com/yasirkula/UnityNativeGallery

public class GalleryPicker : MonoBehaviour
{
	GameObject quad;


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (NativeGallery.IsMediaPickerBusy())
					return;
		}

	}

	public void Destroy()
	{
		Destroy(quad);
	}

	public void PickImage(int maxSize)
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			
			if (path != null)
			{
				// Create Texture from selected image
				Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);

				// Assign texture to a temporary quad and destroy it after 5 seconds
				quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
				quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
				quad.transform.forward = Camera.main.transform.forward;
				quad.transform.localScale = new Vector3(1.4f, 2.3f, 1f);

				Material material = quad.GetComponent<Renderer>().material;
				if (!material.shader.isSupported) // happens when Standard shader is not included in the build
					material.shader = Shader.Find("Legacy Shaders/Diffuse");

				material.mainTexture = texture;

			}
		});

	}
}

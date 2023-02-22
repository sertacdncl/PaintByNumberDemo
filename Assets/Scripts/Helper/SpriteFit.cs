using UnityEngine;

public class SpriteFit : MonoBehaviour
{
	public float margin = 0.1f;
	
	void Start()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();

		// Getting cam size
		float cameraHeight = Camera.main.orthographicSize * 2;
		float cameraWidth = cameraHeight * Camera.main.aspect;

		// Getting sprite size
		float spriteHeight = spriteRenderer.bounds.size.y;
		float spriteWidth = spriteRenderer.bounds.size.x;

		// Getting scale ratio
		float scaleX = (cameraWidth - margin * 2) / spriteWidth;
		float scaleY = (cameraHeight - margin * 2) / spriteHeight;
		float scale = Mathf.Min(scaleX, scaleY);

		// If scale is bigger than 1, set it to 1
		if (scale >= 1.0f)
		{
			scale = 1.0f;
		}
		
		transform.localScale = new Vector3(scale, scale, 1f);
	}
}
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private void Start()
	{
		PaintManager.Instance.Prepare();
	}
}

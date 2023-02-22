using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private void Start()
	{
		PaintManager.Instance.Prepare();
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}

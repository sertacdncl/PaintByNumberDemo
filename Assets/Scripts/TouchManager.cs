public class TouchManager : Singleton<TouchManager>
{
	public static int touchCount = 0;
	public static int maxTouchCount = 1;
	public static bool IsTouching => touchCount > 0;
	public static bool CanTouch => touchCount < maxTouchCount;
}
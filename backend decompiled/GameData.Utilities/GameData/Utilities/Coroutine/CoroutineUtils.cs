using System;
using System.Collections;

namespace GameData.Utilities.Coroutine;

public class CoroutineUtils
{
	public static IEnumerator CallAfterFrames(Action callback, int fameCount)
	{
		for (int i = 0; i < fameCount; i++)
		{
			yield return null;
		}
		callback?.Invoke();
	}
}

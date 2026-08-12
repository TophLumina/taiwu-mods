using System.Collections;
using System.Collections.Generic;

namespace GameData.Utilities.Coroutine;

public class CoroutineManager
{
	private readonly Queue<CoroutineInstance> _coroutines = new Queue<CoroutineInstance>();

	public void Start(IEnumerator enumerator)
	{
		_coroutines.Enqueue(new CoroutineInstance(enumerator));
	}

	public void OnUpdate()
	{
		int count = _coroutines.Count;
		for (int i = 0; i < count; i++)
		{
			CoroutineInstance coroutine = _coroutines.Dequeue();
			coroutine.UpdateFrame();
			if (!coroutine.CheckFinish())
			{
				_coroutines.Enqueue(coroutine);
			}
		}
	}
}

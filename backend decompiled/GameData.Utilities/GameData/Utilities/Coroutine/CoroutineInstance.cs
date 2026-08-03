using System.Collections;

namespace GameData.Utilities.Coroutine;

public class CoroutineInstance
{
	private IEnumerator _current;

	private bool _isPaused;

	private bool _isFinished;

	public CoroutineInstance(IEnumerator enumerator)
	{
		_current = enumerator;
		_isFinished = false;
	}

	public void UpdateFrame()
	{
		if (!_isPaused && !_isFinished)
		{
			_isFinished = !_current.MoveNext();
		}
	}

	public bool CheckFinish()
	{
		return _isFinished;
	}

	public void Finish()
	{
		_isFinished = true;
		_current = null;
	}

	public void Pause()
	{
		_isPaused = true;
	}

	public void Unpause()
	{
		_isPaused = false;
	}
}

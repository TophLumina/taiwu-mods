using System.Threading;

namespace GameData.Common;

public static class DataContextManager
{
	private static readonly ThreadLocal<DataContext> Context = new ThreadLocal<DataContext>(() => new DataContext(Thread.CurrentThread.ManagedThreadId), trackAllValues: true);

	private static int _mainThreadId = -1;

	public static DataContext GetCurrentThreadDataContext()
	{
		return Context.Value;
	}

	public static void RegisterMainThread()
	{
		_mainThreadId = Thread.CurrentThread.ManagedThreadId;
	}

	public static bool IsMainThread(int threadId)
	{
		return threadId == _mainThreadId;
	}
}

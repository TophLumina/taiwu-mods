using System;

namespace GameData.GameDataBridge.VnPipe;

public abstract class NativeObject : IDisposable
{
	protected IntPtr m_ptr;

	public bool disposed => m_ptr == IntPtr.Zero;

	public NativeObject(IntPtr ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			throw new ArgumentNullException("ptr");
		}
		m_ptr = ptr;
	}

	~NativeObject()
	{
		_dispose();
	}

	public void Dispose()
	{
		_dispose();
		GC.SuppressFinalize(this);
	}

	private void _dispose()
	{
		if (m_ptr != IntPtr.Zero)
		{
			will_dispose();
			m_ptr = IntPtr.Zero;
		}
	}

	protected abstract void will_dispose();
}

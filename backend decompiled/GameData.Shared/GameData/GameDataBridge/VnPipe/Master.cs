using System;
using System.Text;

namespace GameData.GameDataBridge.VnPipe;

public class Master : NativeObject, IPipe
{
	public static Master Create(string name)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(name);
		IntPtr ptr = Bridge.master_create(bytes, bytes.Length);
		if (ptr == IntPtr.Zero)
		{
			return null;
		}
		return new Master(ptr);
	}

	public bool Wait()
	{
		if (base.disposed)
		{
			return false;
		}
		return Bridge.master_wait(m_ptr) != 0;
	}

	public unsafe int Read(byte[] buf, int off, int len)
	{
		if (base.disposed)
		{
			throw new Exception("Pipe broken: trying to read data after disposed.");
		}
		if (off < 0 || buf.Length < off + len)
		{
			throw new ArgumentException($"Offset {off} should be in range of [0, {buf.Length}(buffer length) + {len}(data size)]");
		}
		int ret;
		fixed (byte* ptr = buf)
		{
			ret = Bridge.master_read(m_ptr, ptr + off, len);
		}
		if (ret <= 0)
		{
			throw new Exception($"Pipe broken: {ret} received.");
		}
		return ret;
	}

	public unsafe int Write(byte[] buf, int off, int len)
	{
		if (base.disposed)
		{
			return -1;
		}
		if (off < 0 || buf.Length < off + len)
		{
			throw new ArgumentException($"Offset {off} should be in range of [0, {buf.Length}(buffer length) + {len}(data size)]");
		}
		int ret;
		fixed (byte* ptr = buf)
		{
			ret = Bridge.master_write(m_ptr, ptr + off, len);
		}
		if (ret < 0)
		{
			throw new Exception($"Pipe broken: {ret} written.");
		}
		return ret;
	}

	public bool Flush()
	{
		if (base.disposed)
		{
			return false;
		}
		return Bridge.master_flush(m_ptr) != 0;
	}

	protected override void will_dispose()
	{
		Bridge.master_release(m_ptr);
	}

	private Master(IntPtr ptr)
		: base(ptr)
	{
	}
}

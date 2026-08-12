using System;
using System.Runtime.InteropServices;

namespace GameData.GameDataBridge.VnPipe;

internal static class Bridge
{
	public const string PLUGIN_NAME = "vnpipe";

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr master_create(byte[] name, int name_len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern void master_release(IntPtr master);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern int master_wait(IntPtr master);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int master_read(IntPtr master, byte* buf, int len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int master_write(IntPtr master, byte* buf, int len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern int master_flush(IntPtr master);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr slaver_connect(byte[] name, int name_len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern void slaver_release(IntPtr slaver);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int slaver_read(IntPtr slaver, byte* buf, int len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public unsafe static extern int slaver_write(IntPtr slaver, byte* buf, int len);

	[DllImport("vnpipe", CallingConvention = CallingConvention.Cdecl)]
	public static extern int slaver_flush(IntPtr slaver);
}

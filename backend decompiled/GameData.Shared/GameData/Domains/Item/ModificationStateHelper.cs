namespace GameData.Domains.Item;

/// <summary>
/// 变动状态相关辅助方法
/// </summary>
public static class ModificationStateHelper
{
	/// <summary>
	/// 获取指定变动类型是否已激活
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Item.ModificationType" /></param>
	/// <returns></returns>
	public static bool IsActive(byte state, byte type)
	{
		return (state & type) != 0;
	}

	/// <summary>
	/// 获取是否有任意已激活的变动类型
	/// </summary>
	/// <param name="state"></param>
	/// <returns></returns>
	public static bool IsAnyActive(byte state)
	{
		return state != 0;
	}

	/// <summary>
	/// 激活指定变动类型
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Item.ModificationType" /></param>
	/// <returns></returns>
	public static byte Activate(byte state, byte type)
	{
		return (byte)(state | type);
	}

	/// <summary>
	/// 取消指定变动类型的激活
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Item.ModificationType" /></param>
	/// <returns></returns>
	public static byte Deactivate(byte state, byte type)
	{
		return (byte)(state & ~type);
	}
}

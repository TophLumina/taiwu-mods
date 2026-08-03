namespace GameData.Domains.Character;

/// <summary>
/// 角色的外部关联状态相关辅助方法
/// </summary>
public static class ExternalRelationStateHelper
{
	/// <summary>
	/// 获取指定外部关联类型是否已激活
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Character.ExternalRelationType" /></param>
	/// <returns></returns>
	public static bool IsActive(ulong state, ulong type)
	{
		return (state & type) != 0;
	}

	/// <summary>
	/// 激活指定外部关联类型
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Character.ExternalRelationType" /></param>
	/// <returns></returns>
	public static byte Activate(ulong state, ulong type)
	{
		return (byte)(state | type);
	}

	/// <summary>
	/// 取消指定外部关联类型的激活
	/// </summary>
	/// <param name="state"></param>
	/// <param name="type"><see cref="T:GameData.Domains.Character.ExternalRelationType" /></param>
	/// <returns></returns>
	public static byte Deactivate(ulong state, ulong type)
	{
		return (byte)(state & ~type);
	}
}

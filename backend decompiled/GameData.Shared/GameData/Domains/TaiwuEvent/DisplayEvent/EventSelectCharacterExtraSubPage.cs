namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件选人界面额外显示的页签类型（与 <see cref="!:ESelectCharacterSubPage" /> 解耦，便于扩展）
/// </summary>
public static class EventSelectCharacterExtraSubPage
{
	/// <summary>
	/// 无额外页签
	/// </summary>
	public const sbyte None = 0;

	/// <summary>
	/// 五圣秘浴
	/// </summary>
	public const sbyte WuShengMiYu = 1;

	/// <summary>
	/// 石牢静坐
	/// </summary>
	public const sbyte ShiLaoJingZuo = 2;
}

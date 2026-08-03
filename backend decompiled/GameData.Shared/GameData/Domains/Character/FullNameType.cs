namespace GameData.Domains.Character;

public static class FullNameType
{
	/// <summary>
	/// (值) 非随机姓名
	/// </summary>
	public const sbyte None = 0;

	/// <summary>
	/// (掩码) 汉族
	/// </summary>
	public const sbyte Han = 1;

	/// <summary>
	/// (掩码) 藏族
	/// </summary>
	public const sbyte Zang = 2;

	/// <summary>
	/// (掩码) 自定义姓
	/// </summary>
	public const sbyte CustomSurname = 4;

	/// <summary>
	/// (掩码) 自定义名
	/// </summary>
	public const sbyte CustomGivenName = 8;

	/// <summary>
	/// (掩码) 根据性别直接返回无名男婴或者无名女婴
	/// </summary>
	public const sbyte NoNameInfant = 16;
}

using GameData.Domains.Character.AvatarSystem;

namespace GameData.Domains.Character;

public class CharmType
{
	public const sbyte Unknown = -1;

	public const sbyte Child = -2;

	public const sbyte Naked = -3;

	/// <summary>
	/// 非人
	/// </summary>
	public const sbyte NonHuman = 0;

	/// <summary>
	/// 可憎
	/// </summary>
	public const sbyte Odious = 1;

	/// <summary>
	/// 不扬
	/// </summary>
	public const sbyte Ugly = 2;

	/// <summary>
	/// 寻常
	/// </summary>
	public const sbyte Normal = 3;

	/// <summary>
	/// 出众
	/// </summary>
	public const sbyte Outstanding = 4;

	/// <summary>
	/// 瑾瑜 / 瑶碧
	/// </summary>
	public const sbyte Beautiful = 5;

	/// <summary>
	/// 龙姿 / 凤仪
	/// </summary>
	public const sbyte Brilliant = 6;

	/// <summary>
	/// 绝世 / 出尘
	/// </summary>
	public const sbyte Stunning = 7;

	/// <summary>
	/// 天人
	/// </summary>
	public const sbyte Godlike = 8;

	/// <summary>
	/// 天人
	/// </summary>
	public const sbyte Max = 8;

	public static sbyte Get(short attraction, short age, short clothDisplayId, bool isFixedCharacter = false, bool faceVisible = true)
	{
		if (!faceVisible)
		{
			return -1;
		}
		if (!isFixedCharacter)
		{
			if (age < 16)
			{
				return -2;
			}
			if (clothDisplayId == 0)
			{
				return -3;
			}
		}
		sbyte charmLevel = 0;
		short[] charmLevel2 = AvatarData.CharmLevel;
		foreach (short level in charmLevel2)
		{
			if (attraction < level)
			{
				break;
			}
			charmLevel++;
		}
		if (charmLevel > 8)
		{
			charmLevel = 8;
		}
		return charmLevel;
	}
}

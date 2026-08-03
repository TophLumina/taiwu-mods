namespace GameData.Domains.Combat;

/// <summary>
/// 式类型
/// </summary>
public class TrickType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 掷
	/// </summary>
	public const sbyte Zhi = 0;

	/// <summary>
	/// 弹
	/// </summary>
	public const sbyte Tan = 1;

	/// <summary>
	/// 御
	/// </summary>
	public const sbyte Yu = 2;

	/// <summary>
	/// 劈
	/// </summary>
	public const sbyte Pi = 3;

	/// <summary>
	/// 刺
	/// </summary>
	public const sbyte Ci = 4;

	/// <summary>
	/// 撩
	/// </summary>
	public const sbyte Liao = 5;

	/// <summary>
	/// 崩
	/// </summary>
	public const sbyte Beng = 6;

	/// <summary>
	/// 点
	/// </summary>
	public const sbyte Dian = 7;

	/// <summary>
	/// 拿
	/// </summary>
	public const sbyte Na = 8;

	/// <summary>
	/// 音
	/// </summary>
	public const sbyte Yin = 9;

	/// <summary>
	/// 缠
	/// </summary>
	public const sbyte Chan = 10;

	/// <summary>
	/// 咒
	/// </summary>
	public const sbyte Zhou = 11;

	/// <summary>
	/// 机
	/// </summary>
	public const sbyte Ji = 12;

	/// <summary>
	/// 药
	/// </summary>
	public const sbyte Yao = 13;

	/// <summary>
	/// 毒
	/// </summary>
	public const sbyte Du = 14;

	/// <summary>
	/// 扫
	/// </summary>
	public const sbyte Sao = 15;

	/// <summary>
	/// 抓
	/// </summary>
	public const sbyte Zhua = 16;

	/// <summary>
	/// 撞
	/// </summary>
	public const sbyte Zhuang = 17;

	/// <summary>
	/// 噬
	/// </summary>
	public const sbyte Shi = 18;

	/// <summary>
	/// 杀
	/// </summary>
	public const sbyte Sha = 19;

	/// <summary>
	/// 无
	/// </summary>
	public const sbyte Wu = 20;

	/// <summary>
	/// 神
	/// </summary>
	public const sbyte Shen = 21;

	/// <summary>
	/// 式类型个数
	/// </summary>
	public const int Count = 22;

	/// <summary>
	/// 不会造成伤害和施加毒素的式
	/// </summary>
	public static readonly sbyte[] NoBodyDamageTrickType = new sbyte[3] { -1, 20, 19 };
}

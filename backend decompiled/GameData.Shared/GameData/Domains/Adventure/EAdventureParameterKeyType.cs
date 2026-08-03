using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇变量键类型
/// </summary>
[SerializeAs(typeof(byte))]
public enum EAdventureParameterKeyType
{
	Int,
	String
}

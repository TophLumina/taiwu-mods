using System.Collections.Generic;

namespace GameData.Domains.Character.AvatarSystem.AvatarRes;

/// <summary>
/// 每一个元素都有可能为空
/// </summary>
/// <summary>
/// 组合元素资源类
/// </summary>
public class BodyRes
{
	public short Id;

	public AvatarAsset Cloth;

	public AvatarAsset Skin;

	public AvatarAsset Color;

	public List<AvatarAsset> ClothParts;
}

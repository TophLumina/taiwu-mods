using System.Collections.Generic;

namespace GameData.Domains.Character.AvatarSystem.AvatarRes;

public class BodyRes
{
	public short Id;

	public AvatarAsset Cloth;

	public AvatarAsset Skin;

	public AvatarAsset Color;

	public List<AvatarAsset> ClothParts;
}

using System.IO;
using Config;

namespace GameData.Domains.Character.AvatarSystem.AvatarRes;

public class AvatarAsset
{
	public object ExternalObject;

	public EAvatarElementsType Type;

	public bool IsModAsset;

	public string Name;

	public short Id;

	public short SubId;

	public AvatarElementsItem Config;

	public AvatarHeadItem HeadConfig;

	public byte AvatarId;

	public AvatarAsset(AvatarElementsItem avatarElementsItem, bool isModAsset = false)
	{
		Config = avatarElementsItem;
		IsModAsset = isModAsset;
		AvatarId = avatarElementsItem.AvatarId;
		Id = Config.ElementId;
		Name = Path.GetFileNameWithoutExtension(Config.NameOrPath);
		Type = Config.Type;
		switch (Type)
		{
		case EAvatarElementsType.ClothPart:
		case EAvatarElementsType.Eye:
		case EAvatarElementsType.EyeBall:
		case EAvatarElementsType.MouthPart:
		case EAvatarElementsType.Hair1Part:
		case EAvatarElementsType.Hair2Part:
			if (avatarElementsItem.ParentId != 0)
			{
				Id = Config.ParentId;
				SubId = Config.ElementId;
			}
			break;
		case EAvatarElementsType.Feature1:
		case EAvatarElementsType.Feature2:
			SubId = (Config.Inherit ? ((short)1) : ((short)0));
			break;
		default:
			SubId = 0;
			break;
		}
	}

	public AvatarAsset(AvatarHeadItem avatarHeadItem, bool isModAsset = false)
	{
		HeadConfig = avatarHeadItem;
		IsModAsset = isModAsset;
		AvatarId = avatarHeadItem.AvatarId;
		Id = avatarHeadItem.HeadId;
		Name = Path.GetFileNameWithoutExtension(HeadConfig.NameOrPath);
		Type = EAvatarElementsType.Head;
	}
}

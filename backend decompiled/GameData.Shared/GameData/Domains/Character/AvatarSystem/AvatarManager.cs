using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character.AvatarSystem.AvatarRes;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.AvatarSystem;

/// <summary>
/// 人物形象管理系统
/// Mod要求记录：
/// 1、要求所有奇数体型为男性，偶数体型为女性
/// 2、奇数体型n和偶数体型n+1总是一一对应的体型关系
/// 3、人物形象的资源大小被限制不能超过360*440
/// </summary>
public class AvatarManager
{
	public static AvatarManager Instance;

	private List<AvatarGroup> _avatarGroupList;

	/// <summary>
	/// 皮肤的颜色权重配置
	/// </summary>
	public List<byte[]> SkinColorsWeight;

	/// <summary>
	/// 特征的颜色权重配置
	/// </summary>
	public List<byte[]> FeatureColorsWeight;

	/// <summary>
	/// 嘴唇的颜色权重配置
	/// </summary>
	public List<byte[]> LipColorsWeight;

	/// <summary>
	/// 衣服的颜色权重配置
	/// </summary>
	public List<byte[]> ClothColorsWeight;

	/// <summary>
	/// 眼睛的颜色权重配置
	/// </summary>
	public List<byte[]> EyeballColorsWeight;

	/// <summary>
	/// 毛发的颜色权重配置
	/// </summary>
	public List<byte[]> HairColorsWeight;

	private bool _avatarReady;

	public bool DisplayMode { get; private set; }

	/// <summary>
	/// 获取avatar系统是否准备完成
	/// </summary>
	/// <returns></returns>
	public bool AvatarSystemReady => _avatarReady;

	/// <summary>
	/// 获取一个体型数据组
	/// </summary>
	/// <returns></returns>
	public AvatarGroup GetAvatarGroup(int avatarId)
	{
		return _avatarGroupList.Find((AvatarGroup e) => e.Id == avatarId);
	}

	/// <summary>
	/// 获取满足条件的全部体型数据组
	/// </summary>
	/// <param name="predicate"></param>
	/// <returns></returns>
	public List<AvatarGroup> GetAvatarGroupList(Predicate<AvatarGroup> predicate)
	{
		return _avatarGroupList.FindAll(predicate);
	}

	/// <summary>
	/// 获取可用体型数量
	/// </summary>
	/// <returns></returns>
	public int GetCanUseAvatarGroupCount()
	{
		int count = 0;
		_avatarGroupList.ForEach(delegate(AvatarGroup e)
		{
			if (e.HasAsset)
			{
				count++;
			}
		});
		return count;
	}

	public int GetMaxAvatarId()
	{
		return _avatarGroupList[_avatarGroupList.Count - 1].Id;
	}

	/// <summary>
	/// 获取一个指定的最小资源对象
	/// </summary>
	/// <param name="avatarId"></param>
	/// <param name="elemType"></param>
	/// <param name="elemIds"></param>
	/// <returns></returns>
	public AvatarAsset GetAsset(int avatarId, EAvatarElementsType elemType, params short[] elemIds)
	{
		AvatarGroup group = _avatarGroupList.Find((AvatarGroup e) => e.Id == avatarId);
		if (group == null)
		{
			throw new Exception($"Avatar {avatarId} is not found!");
		}
		AvatarAsset asset = group.Get(elemType, elemIds);
		if (elemType != EAvatarElementsType.Hair1Part && elemType != EAvatarElementsType.Hair2Part && elemType != EAvatarElementsType.MouthPart && elemType != EAvatarElementsType.EyeBall && elemType != EAvatarElementsType.Beard1 && elemType != EAvatarElementsType.Beard2 && (elemIds[0] != 0 || elemType != EAvatarElementsType.ClothColor) && asset == null)
		{
			AdaptableLog.TagError("AvatarManager", string.Format("Avatar {0} failed to get asset {1}:Id = {2} {3}", avatarId, elemType, elemIds[0], (elemIds.Length > 1) ? ("SubId = " + elemIds[1]) : ""));
		}
		return asset;
	}

	public bool HasAsset(int avatarId, EAvatarElementsType elemType, params short[] elemIds)
	{
		AvatarGroup group = _avatarGroupList.Find((AvatarGroup e) => e.Id == avatarId);
		if (group == null)
		{
			throw new Exception($"Avatar {avatarId} is not found!");
		}
		AvatarAsset asset = group.Get(elemType, elemIds);
		return asset != null;
	}

	/// <summary>
	/// 根据人物体型和性别获取对应的体型id
	/// </summary>
	/// <param name="bodyType"></param>
	/// <param name="gender"></param>
	/// <returns></returns>
	public sbyte GetAvatarIdByBodyTypeAndGender(sbyte bodyType, sbyte gender)
	{
		sbyte id = 0;
		switch (bodyType)
		{
		case 0:
			id = 1;
			break;
		case 1:
			id = 3;
			break;
		case 2:
			id = 5;
			break;
		}
		if (gender == 0)
		{
			id++;
		}
		return id;
	}

	/// <summary>
	/// 获取一个随机的Avatar形象数据
	/// 不传入任何参数：全随机一个avatarData
	/// 传入性别：随机指定性别的avatarData
	/// 性别传入-1，同时传入父母：进行遗传算法造小人
	/// 性别和父母同时传入：进行指定性别的遗传算法
	/// </summary>
	/// <param name="random">随机器</param>
	/// <param name="gender">指定的性别</param>
	/// <param name="transgender">异性相 (性征和性别相反)</param>
	/// <param name="bodyType">指定的体型</param>
	/// <param name="father">指定的父亲的形象</param>
	/// <param name="mother">指定的母亲的形象</param>
	/// <returns></returns>
	public AvatarData GetRandomAvatar(IRandomSource random, sbyte gender = -1, bool transgender = false, sbyte bodyType = -1, AvatarData father = null, AvatarData mother = null)
	{
		if (gender == -1)
		{
			gender = Gender.GetRandom(random);
		}
		if (father == null && mother == null)
		{
			return GetTotalRandomAvatar(random, gender, transgender, bodyType);
		}
		return new AvatarInherit(father, mother, gender, bodyType, random).GetInheritAvatar();
	}

	/// <summary>
	/// 产生一个指定基础魅力的AvatarData
	/// </summary>
	/// <param name="random"></param>
	/// <param name="gender"></param>
	/// <param name="transgender">异性相 (性征和性别相反)</param>
	/// <param name="bodyType"></param>
	/// <param name="baseAttraction"></param>
	/// <returns></returns>
	public AvatarData GetRandomAvatar(IRandomSource random, sbyte gender, bool transgender, sbyte bodyType, short baseAttraction)
	{
		AvatarData totalRandomAvatar = GetTotalRandomAvatar(random, gender, transgender, bodyType);
		totalRandomAvatar.AdjustToBaseCharm(random, baseAttraction);
		return totalRandomAvatar;
	}

	/// <summary>
	/// 根据传入的avatarId获取一个幼儿时期的AvatarId
	/// </summary>
	/// <param name="avatarId"></param>
	/// <returns></returns>
	public byte GetChildAvatarIdByAvatarId(byte avatarId)
	{
		byte childAvatarHeadId = 6;
		if (avatarId % 6 <= 0 || avatarId % 6 >= 5)
		{
			childAvatarHeadId = (byte)((avatarId % 2 != 0) ? 8 : 9);
		}
		else if (avatarId % 2 == 0)
		{
			childAvatarHeadId = 7;
		}
		return AvatarHead.Instance[childAvatarHeadId].AvatarId;
	}

	/// <summary>
	/// 根据传入的avatarId获取一个幼儿时期的服装id
	/// </summary>
	/// <param name="random"></param>
	/// <param name="avatarId"></param>
	/// <returns></returns>
	public short GetRandomChildClothIdByAvatarId(IRandomSource random, byte avatarId)
	{
		byte childAvatarId = GetChildAvatarIdByAvatarId(avatarId);
		return GetAvatarGroup(childAvatarId)?.GetRandomCloth(random, canCreateOnly: false) ?? 255;
	}

	/// <summary>
	/// 产生一个全随机的AvatarData
	/// </summary>
	/// <param name="random"></param>
	/// <param name="gender"></param>
	/// <param name="transgender">异性相 (性征和性别相反)</param>
	/// <param name="bodyType"></param>
	/// <returns></returns>
	private AvatarData GetTotalRandomAvatar(IRandomSource random, sbyte gender, bool transgender, sbyte bodyType)
	{
		if (transgender)
		{
			gender = Gender.Flip(gender);
		}
		sbyte preferredId = -1;
		if (bodyType != -1)
		{
			preferredId = GetAvatarIdByBodyTypeAndGender(bodyType, gender);
		}
		List<AvatarGroup> list = new List<AvatarGroup>();
		list.AddRange(_avatarGroupList.FindAll(FindFunc));
		AvatarData data = null;
		AvatarGroup avatarGroup = list.GetRandom(random);
		if (DisplayMode)
		{
			(data, data.ClothDisplayId) = avatarGroup.GetRandomAvatar(random, randColor: true, randCloth: true);
		}
		else
		{
			data = avatarGroup.GetRandomAvatar(random).avatar;
		}
		return data;
		bool FindFunc(AvatarGroup e)
		{
			if (e.BodyRes.Count <= 0)
			{
				return false;
			}
			if (-1 != preferredId)
			{
				return e.Id == preferredId;
			}
			if (e.Id >= AvatarHead.Instance[(byte)6].AvatarId)
			{
				return false;
			}
			if (gender == 1)
			{
				return e.Id % 2 == 1;
			}
			if (gender == 0)
			{
				return e.Id % 2 == 0;
			}
			return false;
		}
	}

	/// <summary>
	/// 检查一个AvatarData,把超出范围的数据/无效的数据重新改成一个范围内的随机值.
	/// 迁移前为纯前端逻辑.
	/// </summary>
	public void AvatarDataClamp(AvatarData avatarData)
	{
		IRandomSource random = ExternalDataBridge.Context.Random;
		AvatarGroup group = GetAvatarGroup(avatarData.AvatarId);
		if (group == null)
		{
			group = _avatarGroupList.GetRandom(random);
		}
		avatarData.AvatarId = group.Id;
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Head, avatarData.HeadId))
		{
			avatarData.HeadId = (byte)group.GetRandomHead(random);
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Cloth, avatarData.ClothDisplayId))
		{
			avatarData.ClothPartId = 0;
			avatarData.ClothDisplayId = group.GetRandomCloth(random, canCreateOnly: true);
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Eye, avatarData.EyesMainId, avatarData.EyesLeftId))
		{
			(avatarData.EyesMainId, avatarData.EyesLeftId, avatarData.EyesRightId, avatarData.EyebrowId) = group.GetRandomEyes(random);
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Nose, avatarData.NoseId))
		{
			avatarData.NoseId = group.GetRandomNose(random);
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Mouth, avatarData.MouthId))
		{
			avatarData.MouthId = group.GetRandomMouth(random);
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Beard1, avatarData.Beard1Id))
		{
			avatarData.Beard1Id = group.GetRandomBeards(random).id1;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Beard2, avatarData.Beard2Id))
		{
			avatarData.Beard2Id = group.GetRandomBeards(random).id2;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Hair1, avatarData.FrontHairId))
		{
			avatarData.FrontHairId = group.GetRandomHairs(random).frontId;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Hair2, avatarData.BackHairId))
		{
			avatarData.BackHairId = group.GetRandomHairs(random).backId;
		}
		var (feature1Id, feature2Id, wrinkle1Id, wrinkle2Id, wrinkle3Id) = group.GetRandomMaskElems(random);
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Feature1, avatarData.Feature1Id))
		{
			avatarData.Feature1Id = feature1Id;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Feature2, avatarData.Feature2Id))
		{
			avatarData.Feature2Id = feature2Id;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Wrinkle1, avatarData.Wrinkle1Id))
		{
			avatarData.Wrinkle1Id = wrinkle1Id;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Wrinkle2, avatarData.Wrinkle2Id))
		{
			avatarData.Wrinkle2Id = wrinkle2Id;
		}
		if (!HasAsset(avatarData.AvatarId, EAvatarElementsType.Wrinkle3, avatarData.Wrinkle3Id))
		{
			avatarData.Wrinkle3Id = wrinkle3Id;
		}
	}

	public int GetColorWeightIndex()
	{
		return 1;
	}

	/// <summary>
	/// 加载组织捏脸系统资源
	/// </summary>
	public void InitAvatarCore(bool displayMode, Action loadExternalAvatars = null, bool forceInit = false)
	{
		if (_avatarReady && !forceInit)
		{
			return;
		}
		DisplayMode = displayMode;
		SkinColorsWeight = new List<byte[]>();
		AvatarSkinColors.Instance.Iterate(delegate(AvatarSkinColorsItem colorItem)
		{
			SkinColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		FeatureColorsWeight = new List<byte[]>();
		AvatarFeatureColors.Instance.Iterate(delegate(AvatarFeatureColorsItem colorItem)
		{
			FeatureColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		LipColorsWeight = new List<byte[]>();
		AvatarLipColors.Instance.Iterate(delegate(AvatarLipColorsItem colorItem)
		{
			LipColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		ClothColorsWeight = new List<byte[]>();
		AvatarClothColors.Instance.Iterate(delegate(AvatarClothColorsItem colorItem)
		{
			ClothColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		EyeballColorsWeight = new List<byte[]>();
		AvatarEyeballColors.Instance.Iterate(delegate(AvatarEyeballColorsItem colorItem)
		{
			EyeballColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		HairColorsWeight = new List<byte[]>();
		AvatarHairColors.Instance.Iterate(delegate(AvatarHairColorsItem colorItem)
		{
			HairColorsWeight.Add(new byte[5] { colorItem.TemplateId, colorItem.ObbCn, colorItem.ObbChn, colorItem.ObbJp, colorItem.ObbEn });
			return true;
		});
		_avatarGroupList = new List<AvatarGroup>();
		List<byte> headIdList = AvatarHead.Instance.GetAllKeys();
		for (int i = 0; i < headIdList.Count; i++)
		{
			AvatarHeadItem item = AvatarHead.Instance[headIdList[i]];
			if (item != null)
			{
				AvatarAsset avatarAsset = new AvatarAsset(item);
				AvatarGroup avatarGroup = GetAvatarGroup(avatarAsset.AvatarId);
				if (avatarGroup == null)
				{
					avatarGroup = new AvatarGroup();
					avatarGroup.Id = avatarAsset.AvatarId;
					_avatarGroupList.Add(avatarGroup);
				}
				avatarGroup.Add(avatarAsset);
			}
		}
		List<uint> elementsIdList = AvatarElements.Instance.GetAllKeys();
		for (int i2 = 0; i2 < elementsIdList.Count; i2++)
		{
			AvatarAsset avatarAsset2 = new AvatarAsset(AvatarElements.Instance[elementsIdList[i2]]);
			AvatarGroup avatarGroup2 = GetAvatarGroup(avatarAsset2.AvatarId);
			if (avatarGroup2 == null)
			{
				avatarGroup2 = new AvatarGroup();
				avatarGroup2.Id = avatarAsset2.AvatarId;
				_avatarGroupList.Add(avatarGroup2);
			}
			avatarGroup2.Add(avatarAsset2);
		}
		loadExternalAvatars?.Invoke();
		byte childFirstAvatarId = GetChildAvatarIdByAvatarId(1);
		List<AvatarGroup> disableAvatarList = new List<AvatarGroup>();
		_avatarGroupList.Sort((AvatarGroup left, AvatarGroup right) => left.Id - right.Id);
		for (int i3 = 0; i3 < _avatarGroupList.Count; i3++)
		{
			AvatarGroup avatarGroup3 = _avatarGroupList[i3];
			avatarGroup3.Sort();
			avatarGroup3.ConstructEyesGroup();
			if (avatarGroup3.Id > 6 && avatarGroup3.Id < childFirstAvatarId)
			{
				string checkInfo = ModUsabilityCheck(avatarGroup3);
				if (!string.IsNullOrEmpty(checkInfo))
				{
					disableAvatarList.Add(avatarGroup3);
					AdaptableLog.TagError("AvatarManager", checkInfo);
				}
			}
		}
		for (int i4 = 0; i4 < disableAvatarList.Count; i4++)
		{
			_avatarGroupList.Remove(disableAvatarList[i4]);
		}
		_avatarReady = true;
	}

	private string ModUsabilityCheck(AvatarGroup checkGroup)
	{
		return string.Empty;
	}
}

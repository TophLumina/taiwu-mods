using GameData.Domains.Character.AvatarSystem.AvatarRes;
using Redzen.Random;

namespace GameData.Domains.Character.AvatarSystem;

public class AvatarInherit
{
	private AvatarManager _avatarManager;

	private readonly AvatarData _father;

	private readonly AvatarData _mother;

	private readonly sbyte _specifiedBodyType;

	private sbyte _gender;

	private readonly int _avatarChanceMutation;

	private IRandomSource _customRandom;

	public AvatarInherit(AvatarData father, AvatarData mother, sbyte gender, sbyte bodyType, IRandomSource random)
	{
		_father = father;
		_mother = mother;
		_gender = gender;
		_specifiedBodyType = bodyType;
		_avatarChanceMutation = GlobalConfig.Instance.AvatarChanceMutation;
		_customRandom = random;
		_avatarManager = AvatarManager.Instance;
	}

	public AvatarData GetInheritAvatar()
	{
		if (_father == null && _mother == null)
		{
			return null;
		}
		int avatarId = 0;
		if (_gender == 1)
		{
			if (_father != null)
			{
				avatarId = _father.AvatarId;
			}
			else if (_mother != null)
			{
				avatarId = (byte)(_mother.AvatarId - 1);
			}
		}
		else if (_gender == 0)
		{
			if (_mother != null)
			{
				avatarId = _mother.AvatarId;
			}
			else if (_father != null)
			{
				avatarId = (byte)(_father.AvatarId + 1);
			}
		}
		if (_gender == -1)
		{
			_gender = Gender.GetRandom(_customRandom);
		}
		if (_specifiedBodyType != -1)
		{
			avatarId = _avatarManager.GetAvatarIdByBodyTypeAndGender(_specifiedBodyType, _gender);
		}
		if (avatarId == 0)
		{
			avatarId = _customRandom.Next(1, 4) * 2;
			if (_gender == 1)
			{
				avatarId--;
			}
		}
		AvatarGroup avatarGroup = _avatarManager.GetAvatarGroup(avatarId);
		AvatarData avatarData = avatarGroup.GetRandomAvatar(_customRandom).avatar;
		InheritColorSkin(avatarData);
		InheritEyesId(avatarData);
		InheritEyesScale(avatarData);
		InheritEyesHeight(avatarData);
		InheritEyesDistance(avatarData);
		InheritEyesRotate(avatarData);
		InheritEyebrowsId(avatarData);
		InheritEyebrowsScale(avatarData);
		InheritEyebrowsHeight(avatarData);
		InheritEyebrowsDistance(avatarData);
		InheritEyebrowsRotate(avatarData);
		InheritEyebrowsColor(avatarData);
		InheritEyeballsColor(avatarData);
		InheritMouthId(avatarData);
		InheritMouthScale(avatarData);
		InheritMouthHeight(avatarData);
		InheritMouthColor(avatarData);
		InheritNoseId(avatarData);
		InheritNoseScale(avatarData);
		InheritNoseHeight(avatarData);
		InheritBeard1Id(avatarData);
		InheritBeard2Id(avatarData);
		InheritBeardColor(avatarData);
		InheritFeature1Id(avatarData);
		InheritFeature1Color(avatarData);
		InheritFeature2Id(avatarData);
		InheritFeature2Color(avatarData);
		InheritHeadId(avatarData);
		if (avatarData.Gender == 1)
		{
			(short id1, short id2) randomBeards = _avatarManager.GetAvatarGroup(avatarData.AvatarId).GetRandomBeards(_customRandom);
			short beard1Id = randomBeards.id1;
			short beard2Id = randomBeards.id2;
			AvatarAsset beard1Asset = avatarGroup.Get(EAvatarElementsType.Beard1, avatarData.Beard1Id);
			if (beard1Asset == null)
			{
				avatarData.Beard1Id = beard1Id;
			}
			AvatarAsset beard2Asset = avatarGroup.Get(EAvatarElementsType.Beard2, avatarData.Beard2Id);
			if (beard2Asset == null)
			{
				avatarData.Beard2Id = beard2Id;
			}
		}
		_avatarManager = null;
		_customRandom = null;
		return avatarData;
	}

	/// <summary>
	/// 获取遗传状态位码
	/// </summary>
	/// <returns>0-发生突变 1-从父亲处遗传 2-从母亲处遗传</returns>
	private int GetInheritCode()
	{
		int inheritRandValue = _customRandom.Next(10000);
		if (inheritRandValue < _avatarChanceMutation)
		{
			return 0;
		}
		if (_father != null && _mother != null)
		{
			if (inheritRandValue >= 5000)
			{
				return 2;
			}
			return 1;
		}
		if (_father == null && _mother != null)
		{
			return 2;
		}
		if (_mother == null && _father != null)
		{
			return 1;
		}
		return 0;
	}

	/// <summary>
	/// 肤色的遗传
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritColorSkin(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (1 == inheritCode)
		{
			avatarData.ColorSkinId = _father.ColorSkinId;
		}
		else if (2 == inheritCode)
		{
			avatarData.ColorSkinId = _mother.ColorSkinId;
		}
	}

	/// <summary>
	/// 眼睛id的遗传
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyesId(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		AvatarData inheritAvatar = _father;
		if (2 == inheritCode)
		{
			inheritAvatar = _mother;
		}
		if (inheritAvatar != null)
		{
			avatarData.EyesMainId = inheritAvatar.EyesMainId;
			if (_avatarManager.GetAsset(avatarData.AvatarId, EAvatarElementsType.Eye, avatarData.EyesMainId, inheritAvatar.EyesLeftId) != null)
			{
				avatarData.EyesLeftId = inheritAvatar.EyesLeftId;
			}
			if (_avatarManager.GetAsset(avatarData.AvatarId, EAvatarElementsType.Eye, avatarData.EyesMainId, inheritAvatar.EyesRightId) != null)
			{
				avatarData.EyesRightId = inheritAvatar.EyesRightId;
			}
		}
	}

	/// <summary>
	/// 眼睛高度的遗传
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyesHeight(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			AvatarData inheritAvatar = null;
			if (1 == inheritCode && _father != null)
			{
				inheritAvatar = _father;
			}
			if (2 == inheritCode && _mother != null)
			{
				inheritAvatar = _mother;
			}
			if (inheritAvatar != null)
			{
				avatarData.EyesHeight = inheritAvatar.EyesHeight;
			}
		}
	}

	/// <summary>
	/// 眼睛间距参数
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyesDistance(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			AvatarData inheritAvatar = null;
			if (1 == inheritCode && _father != null)
			{
				inheritAvatar = _father;
			}
			if (2 == inheritCode && _mother != null)
			{
				inheritAvatar = _mother;
			}
			if (inheritAvatar != null)
			{
				avatarData.EyesDistance = inheritAvatar.EyesDistance;
			}
		}
	}

	/// <summary>
	/// 眼睛旋转角度
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyesRotate(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyesAngle = _father.EyesAngle;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyesAngle = _mother.EyesAngle;
			}
		}
	}

	/// <summary>
	/// 眼睛缩放
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyesScale(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyesScale = _father.EyesScale;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyesScale = _mother.EyesScale;
			}
		}
	}

	/// <summary>
	/// 眉毛高度坐标
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsHeight(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyebrowHeight = _father.EyebrowHeight;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyebrowHeight = _mother.EyebrowHeight;
			}
		}
	}

	/// <summary>
	/// 眉毛间距参数
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsDistance(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			AvatarData inheritAvatar = null;
			if (1 == inheritCode && _father != null)
			{
				inheritAvatar = _father;
			}
			if (2 == inheritCode && _mother != null)
			{
				inheritAvatar = _mother;
			}
			if (inheritAvatar != null)
			{
				avatarData.EyebrowDistance = inheritAvatar.EyebrowDistance;
			}
		}
	}

	/// <summary>
	/// 眉毛旋转角度
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsRotate(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyebrowAngle = _father.EyebrowAngle;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyebrowAngle = _mother.EyebrowAngle;
			}
		}
	}

	/// <summary>
	/// 眉毛缩放
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsScale(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyebrowScale = _father.EyebrowScale;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyebrowScale = _mother.EyebrowScale;
			}
		}
	}

	/// <summary>
	/// 眉毛样式id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsId(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.EyebrowId = _father.EyebrowId;
			}
			else if (2 == inheritCode)
			{
				avatarData.EyebrowId = _mother.EyebrowId;
			}
		}
	}

	/// <summary>
	/// 眉毛颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyebrowsColor(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorEyebrowId = _father.ColorEyebrowId;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorEyebrowId = _mother.ColorEyebrowId;
			}
		}
	}

	/// <summary>
	/// 眼珠颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritEyeballsColor(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorEyeballId = _father.ColorEyeballId;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorEyeballId = _mother.ColorEyeballId;
			}
		}
	}

	/// <summary>
	/// 鼻子样式id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritNoseId(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.NoseId = _father.NoseId;
			}
			else if (2 == inheritCode)
			{
				avatarData.NoseId = _mother.NoseId;
			}
		}
	}

	/// <summary>
	/// 鼻子高度
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritNoseHeight(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			AvatarData inheritAvatar = null;
			if (1 == inheritCode && _father != null)
			{
				inheritAvatar = _father;
			}
			if (2 == inheritCode && _mother != null)
			{
				inheritAvatar = _mother;
			}
			if (inheritAvatar != null)
			{
				avatarData.NoseHeight = inheritAvatar.NoseHeight;
			}
		}
	}

	/// <summary>
	/// 鼻子缩放
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritNoseScale(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.NoseScale = _father.NoseScale;
			}
			else if (2 == inheritCode)
			{
				avatarData.NoseScale = _mother.NoseScale;
			}
		}
	}

	/// <summary>
	/// 嘴巴id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritMouthId(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.MouthId = _father.MouthId;
			}
			else if (2 == inheritCode)
			{
				avatarData.MouthId = _mother.MouthId;
			}
		}
	}

	/// <summary>
	/// 嘴巴高度
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritMouthHeight(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			AvatarData inheritAvatar = null;
			if (1 == inheritCode && _father != null)
			{
				inheritAvatar = _father;
			}
			if (2 == inheritCode && _mother != null)
			{
				inheritAvatar = _mother;
			}
			if (inheritAvatar != null)
			{
				avatarData.MouthHeight = inheritAvatar.MouthHeight;
			}
		}
	}

	/// <summary>
	/// 嘴巴缩放
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritMouthScale(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.MouthScale = _father.MouthScale;
			}
			else if (2 == inheritCode)
			{
				avatarData.MouthScale = _mother.MouthScale;
			}
		}
	}

	/// <summary>
	/// 嘴巴颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritMouthColor(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorMouthId = _father.ColorMouthId;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorMouthId = _mother.ColorMouthId;
			}
		}
	}

	/// <summary>
	/// 胡须颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritBeardColor(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode == 0)
		{
			return;
		}
		if (1 == inheritCode)
		{
			avatarData.ColorBeard1Id = _father.ColorBeard1Id;
		}
		else if (2 == inheritCode)
		{
			avatarData.ColorBeard1Id = _mother.ColorBeard1Id;
		}
		inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorBeard2Id = _father.ColorBeard2Id;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorBeard2Id = _mother.ColorBeard2Id;
			}
		}
	}

	/// <summary>
	/// 上嘴唇胡须样式id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritBeard1Id(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.Beard1Id = _father.Beard1Id;
			}
			else if (2 == inheritCode)
			{
				avatarData.Beard1Id = _mother.Beard1Id;
			}
		}
	}

	/// <summary>
	/// 下嘴唇胡须样式id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritBeard2Id(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.Beard2Id = _father.Beard2Id;
			}
			else if (2 == inheritCode)
			{
				avatarData.Beard2Id = _mother.Beard2Id;
			}
		}
	}

	/// <summary>
	/// 特征1id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritFeature1Id(AvatarData avatarData)
	{
		AvatarAsset fatherFeature1Asset = null;
		if (_father != null)
		{
			fatherFeature1Asset = _avatarManager.GetAsset(_father.AvatarId, EAvatarElementsType.Feature1, _father.Feature1Id);
		}
		AvatarAsset motherFeature1Asset = null;
		if (_mother != null)
		{
			motherFeature1Asset = _avatarManager.GetAsset(_mother.AvatarId, EAvatarElementsType.Feature1, _mother.Feature1Id);
		}
		bool fatherFeature1Inherit = false;
		if (fatherFeature1Asset != null)
		{
			fatherFeature1Inherit = fatherFeature1Asset.Config.Inherit;
		}
		bool motherFeature1Inherit = false;
		if (motherFeature1Asset != null)
		{
			motherFeature1Inherit = motherFeature1Asset.Config.Inherit;
		}
		int inheritCode = GetInheritCode();
		if (fatherFeature1Inherit != motherFeature1Inherit)
		{
			if (fatherFeature1Inherit)
			{
				avatarData.Feature1Id = _father.Feature1Id;
			}
			if (motherFeature1Inherit)
			{
				avatarData.Feature1Id = _mother.Feature1Id;
			}
		}
		else if (fatherFeature1Inherit || inheritCode != 0)
		{
			if (1 == inheritCode && _father != null)
			{
				avatarData.Feature1Id = _father.Feature1Id;
			}
			if (2 == inheritCode && _mother != null)
			{
				avatarData.Feature1Id = _mother.Feature1Id;
			}
		}
	}

	/// <summary>
	/// 特征2id
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritFeature2Id(AvatarData avatarData)
	{
		AvatarAsset fatherFeature2Asset = null;
		if (_father != null)
		{
			fatherFeature2Asset = _avatarManager.GetAsset(_father.AvatarId, EAvatarElementsType.Feature2, _father.Feature2Id);
		}
		AvatarAsset motherFeature2Asset = null;
		if (_mother != null)
		{
			motherFeature2Asset = _avatarManager.GetAsset(_mother.AvatarId, EAvatarElementsType.Feature2, _mother.Feature2Id);
		}
		bool fatherFeature2Inherit = false;
		if (fatherFeature2Asset != null)
		{
			fatherFeature2Inherit = fatherFeature2Asset.Config.Inherit;
		}
		bool motherFeature2Inherit = false;
		if (motherFeature2Asset != null)
		{
			motherFeature2Inherit = motherFeature2Asset.Config.Inherit;
		}
		int inheritCode = GetInheritCode();
		if (fatherFeature2Inherit != motherFeature2Inherit)
		{
			if (fatherFeature2Inherit)
			{
				avatarData.Feature2Id = _father.Feature2Id;
			}
			if (motherFeature2Inherit)
			{
				avatarData.Feature2Id = _mother.Feature2Id;
			}
		}
		else if (fatherFeature2Inherit || inheritCode != 0)
		{
			if (1 == inheritCode && _father != null)
			{
				avatarData.Feature2Id = _father.Feature2Id;
			}
			if (2 == inheritCode && _mother != null)
			{
				avatarData.Feature2Id = _mother.Feature2Id;
			}
		}
	}

	/// <summary>
	/// 特征1颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritFeature1Color(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorFeature1Id = _father.ColorFeature1Id;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorFeature1Id = _mother.ColorFeature1Id;
			}
		}
	}

	/// <summary>
	/// 特征2颜色
	/// </summary>
	/// <param name="avatarData"></param>
	private void InheritFeature2Color(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode != 0)
		{
			if (1 == inheritCode)
			{
				avatarData.ColorFeature2Id = _father.ColorFeature2Id;
			}
			else if (2 == inheritCode)
			{
				avatarData.ColorFeature2Id = _mother.ColorFeature2Id;
			}
		}
	}

	/// <summary>
	/// 头型Id的遗传
	/// </summary>
	private void InheritHeadId(AvatarData avatarData)
	{
		int inheritCode = GetInheritCode();
		if (inheritCode == 0)
		{
			return;
		}
		AvatarData inheritAvatar = null;
		if (1 == inheritCode && _father != null)
		{
			inheritAvatar = _father;
		}
		else if (2 == inheritCode && _mother != null)
		{
			inheritAvatar = _mother;
		}
		if (inheritAvatar != null)
		{
			byte headId = inheritAvatar.HeadId;
			if (_avatarManager.HasAsset(avatarData.AvatarId, EAvatarElementsType.Head, headId))
			{
				avatarData.HeadId = headId;
			}
		}
	}
}

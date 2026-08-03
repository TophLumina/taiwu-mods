using System.Collections.Generic;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 角色姓名法号相关数据 (前端生成姓名法号所需要的数据)
/// </summary>
[SerializableGameData]
public struct NameRelatedData : ISerializableGameData
{
	/// <summary>
	/// 角色模板 ID.
	/// 小于 0 表示无法找到角色相关信息.
	/// </summary>
	[SerializableGameDataField]
	public short CharTemplateId;

	/// <summary>
	/// 性别
	/// </summary>
	[SerializableGameDataField]
	public sbyte Gender;

	/// <summary>
	/// 出家类型
	/// </summary>
	[SerializableGameDataField]
	public byte MonkType;

	/// <summary>
	/// 随机姓名
	/// </summary>
	[SerializableGameDataField]
	public FullName FullName;

	/// <summary>
	/// 团体模板 ID
	/// </summary>
	[SerializableGameDataField]
	public sbyte OrgTemplateId;

	/// <summary>
	/// 团体级别
	/// </summary>
	[SerializableGameDataField]
	public sbyte OrgGrade;

	/// <summary>
	/// 法号
	/// </summary>
	[SerializableGameDataField]
	public MonasticTitle MonasticTitle;

	/// <summary>
	/// 自定义显示名 ID
	/// </summary>
	[SerializableGameDataField]
	public int CustomDisplayNameId;

	/// <summary>
	/// 昵称。现在关注者才配有。
	/// </summary>
	[SerializableGameDataField]
	public int NickNameId;

	/// <summary>
	/// ExtraNameText对应的模板id
	/// </summary>
	[SerializableGameDataField]
	public int ExtraNameTextTemplateId;

	public NameRelatedData()
	{
		CharTemplateId = 0;
		Gender = 0;
		MonkType = 0;
		FullName = default(FullName);
		OrgTemplateId = 0;
		OrgGrade = 0;
		MonasticTitle = default(MonasticTitle);
		CustomDisplayNameId = -1;
		NickNameId = -1;
		ExtraNameTextTemplateId = -1;
	}

	public NameRelatedData(FullName fullName, sbyte gender)
	{
		CharTemplateId = 0;
		Gender = gender;
		MonkType = 0;
		FullName = fullName;
		OrgTemplateId = 0;
		OrgGrade = 0;
		MonasticTitle = new MonasticTitle
		{
			SeniorityId = -1,
			SuffixId = -1
		};
		CustomDisplayNameId = -1;
		NickNameId = -1;
		ExtraNameTextTemplateId = -1;
	}

	public (string surname, string givenName) GetMonasticTitleOrDisplayName(bool isTaiwu)
	{
		return GetMonasticTitleOrDisplayNameDetailed(isTaiwu, ignoreNickName: false);
	}

	/// <summary>
	/// 获取角色的法号或姓名
	/// </summary>
	/// <param name="isTaiwu"></param>
	/// <param name="ignoreNickName">是否忽略昵称</param>
	/// <returns></returns>
	public (string surname, string givenName) GetMonasticTitleOrDisplayNameDetailed(bool isTaiwu, bool ignoreNickName)
	{
		string nickName = GetNickName();
		if (!ignoreNickName && nickName != null)
		{
			return (surname: null, givenName: nickName);
		}
		string extraName = GetExtraName();
		if (extraName != null)
		{
			return (surname: null, givenName: extraName);
		}
		string monasticTitle = GetMonasticTitle(isTaiwu);
		if (!string.IsNullOrEmpty(monasticTitle))
		{
			return (surname: null, givenName: monasticTitle);
		}
		return GetDisplayNameDetailed(isTaiwu, ignoreNickName);
	}

	public string GetNickName()
	{
		IReadOnlyDictionary<int, string> customTexts = GetCustomTexts();
		if (NickNameId >= 0 && customTexts.TryGetValue(NickNameId, out var nickName))
		{
			return nickName;
		}
		return null;
	}

	private string GetExtraName()
	{
		if (ExtraNameTextTemplateId >= 0)
		{
			return ExtraNameText.Instance[ExtraNameTextTemplateId].Content;
		}
		return null;
	}

	/// <summary>
	/// 获取角色的真实姓名
	/// </summary>
	/// <returns>真实姓氏，真实名称</returns>
	public (string surname, string givenName) GetRealName()
	{
		if (CharTemplateId < 0)
		{
			return (surname: null, givenName: ExtraNameText.Instance[5].Content);
		}
		CharacterItem template = Config.Character.Instance[CharTemplateId];
		if (FullName.Type == 0)
		{
			return (surname: template.Surname, givenName: template.GivenName);
		}
		var (surname, givenName) = FullName.GetName(Gender, GetCustomTexts());
		return (surname: surname, givenName: givenName);
	}

	public (string surname, string givenName) GetDisplayName(bool isTaiwu)
	{
		return GetDisplayNameDetailed(isTaiwu, ignoreNickName: false);
	}

	/// <summary>
	/// 获取角色的显示名
	/// </summary>
	/// <param name="isTaiwu">是否为太吾</param>
	/// <param name="ignoreNickName"></param>
	/// <returns>显示姓氏，显示名称</returns>
	public (string surname, string givenName) GetDisplayNameDetailed(bool isTaiwu, bool ignoreNickName)
	{
		if (CharTemplateId < 0)
		{
			return (surname: null, givenName: ExtraNameText.Instance[5].Content);
		}
		string nickName = GetNickName();
		if (!ignoreNickName && nickName != null)
		{
			return (surname: null, givenName: nickName);
		}
		string extraName = GetExtraName();
		if (extraName != null)
		{
			return (surname: null, givenName: extraName);
		}
		CharacterItem template = Config.Character.Instance[CharTemplateId];
		if (FullName.Type == 0)
		{
			return (surname: template.Surname, givenName: template.GivenName);
		}
		IReadOnlyDictionary<int, string> customTexts = GetCustomTexts();
		var (surname, givenName) = FullName.GetName(Gender, customTexts);
		if (isTaiwu && ShowTaiwuSurname())
		{
			surname = ExtraNameText.Instance[0].Content;
		}
		short orgMemberId = Config.Organization.Instance[OrgTemplateId].Members[OrgGrade];
		OrganizationMemberItem orgMemberCfg = OrganizationMember.Instance[orgMemberId];
		if (orgMemberCfg.SurnameId >= 0)
		{
			surname = LocalSurnames.Instance.SurnameCore[orgMemberCfg.SurnameId].Surname;
		}
		if (CustomDisplayNameId >= 0 && customTexts.TryGetValue(CustomDisplayNameId, out var customDisplayName))
		{
			givenName = customDisplayName;
		}
		return (surname: surname, givenName: givenName);
	}

	/// <summary>
	/// 获取角色的道号
	/// </summary>
	/// <param name="isTaiwu">是否为太吾</param>
	/// <returns>道号字符串文本</returns>
	public string GetMonasticTitle(bool isTaiwu)
	{
		if (MonkType == 0)
		{
			return null;
		}
		CharacterItem template = Config.Character.Instance[CharTemplateId];
		if (FullName.Type == 0 && template.CreatingType == 0)
		{
			return null;
		}
		if ((MonkType & 0x80) != 0)
		{
			if (MonasticTitle.SeniorityId < 0 || MonasticTitle.SuffixId < 0)
			{
				return null;
			}
			MonasticTitleItem[] monasticTitles = LocalMonasticTitles.Instance.MonasticTitles;
			string seniorityName = monasticTitles[MonasticTitle.SeniorityId].Name;
			string suffixName = monasticTitles[MonasticTitle.SuffixId].Name;
			short orgMemberId = Config.Organization.Instance[OrgTemplateId].Members[OrgGrade];
			string titleSuffix = OrganizationMember.Instance[orgMemberId].MonasticTitleSuffixes[Gender];
			return seniorityName + suffixName + titleSuffix;
		}
		(string surname, string givenName) displayName = GetDisplayName(isTaiwu);
		string surname = displayName.surname;
		string givenName = displayName.givenName;
		string obj = ((!string.IsNullOrEmpty(surname)) ? surname : givenName);
		ExtraNameTextItem titleSuffixCfg = (((MonkType & 1) == 0) ? ((Gender == 1) ? ExtraNameText.Instance[4] : ExtraNameText.Instance[3]) : ((Gender == 1) ? ExtraNameText.Instance[2] : ExtraNameText.Instance[1]));
		return obj + titleSuffixCfg.Content;
	}

	/// <summary>
	/// 当前设置是否显示太吾姓氏
	/// </summary>
	private bool ShowTaiwuSurname()
	{
		if (ExternalDataBridge.Context.HideTaiwuOriginalSurname)
		{
			return ExternalDataBridge.Context.GetWorldFunctionsStatus(26);
		}
		return false;
	}

	/// <summary>
	/// 自定义文本集合
	/// </summary>
	private IReadOnlyDictionary<int, string> GetCustomTexts()
	{
		return ExternalDataBridge.Context.CustomTexts;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 32;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = CharTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = MonkType;
		pCurrData++;
		pCurrData += FullName.Serialize(pCurrData);
		*pCurrData = (byte)OrgTemplateId;
		pCurrData++;
		*pCurrData = (byte)OrgGrade;
		pCurrData++;
		pCurrData += MonasticTitle.Serialize(pCurrData);
		*(int*)pCurrData = CustomDisplayNameId;
		pCurrData += 4;
		*(int*)pCurrData = NickNameId;
		pCurrData += 4;
		*(int*)pCurrData = ExtraNameTextTemplateId;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CharTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		MonkType = *pCurrData;
		pCurrData++;
		pCurrData += FullName.Deserialize(pCurrData);
		OrgTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		OrgGrade = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += MonasticTitle.Deserialize(pCurrData);
		CustomDisplayNameId = *(int*)pCurrData;
		pCurrData += 4;
		NickNameId = *(int*)pCurrData;
		pCurrData += 4;
		ExtraNameTextTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

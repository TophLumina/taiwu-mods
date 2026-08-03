using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Map.TeammateBubble;

/// <summary>
/// 同道气泡文本集合
/// </summary>
/// <summary>
/// 同道气泡文本集合
/// </summary>
public class TeammateBubbleCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有同道气泡文本的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<TeammateBubbleRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			TeammateBubbleRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定索引的同道气泡文本的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe TeammateBubbleRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int index = *(int*)(pCurrData + 1);
			int subtype = ((int*)(pCurrData + 1))[1];
			short recordType = ((short*)(pCurrData + 1 + 4))[2];
			short charTemplateId = (short)((subtype == 5) ? ((short*)(pCurrData + 1 + 4 + 4))[1] : 0);
			pCurrData += 11 + ((subtype == 5) ? 2 : 0);
			TeammateBubbleItem config = Config.TeammateBubble.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render teammate bubble with template id {recordType}");
				return null;
			}
			TeammateBubbleRenderInfo info = new TeammateBubbleRenderInfo(recordType, GetStringByType(config, subtype, charTemplateId), index);
			string[] parameters = config.Parameters;
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadonlyRecordCollection.ReadArgumentAndGetIndex(paramType, &pCurrData, argumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	private string GetStringByType(TeammateBubbleItem config, int subType, short templateId)
	{
		return subType switch
		{
			0 => config.SpecialDesc0, 
			1 => config.SpecialDesc1, 
			2 => config.SpecialDesc2, 
			3 => config.SpecialDesc3, 
			4 => config.SpecialDesc4, 
			6 => config.FamilyDesc, 
			7 => config.FriendDesc, 
			5 => config.Cricket[GetIndexByCricketCharTemplateId(templateId)], 
			8 => config.BehaviorDesc[0], 
			9 => config.BehaviorDesc[1], 
			10 => config.BehaviorDesc[2], 
			11 => config.BehaviorDesc[3], 
			12 => config.BehaviorDesc[4], 
			_ => string.Empty, 
		};
	}

	public static int GetIndexByCricketCharTemplateId(short templateId)
	{
		return (templateId - 968) / 2;
	}

	/// <summary>
	/// 开始添加同道气泡文本
	/// </summary>
	/// <param name="index">出战同道的索引</param>
	/// <param name="recordType">即时通知类型</param>
	/// <param name="subtype"></param>
	/// <returns>当前即时通知的起始偏移</returns>
	private unsafe int BeginAddingRecord(int index, short recordType, int subtype)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = index;
			((int*)(num + 1))[1] = subtype;
			((short*)(num + 1 + 4))[2] = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 添加无参数的同道气泡文本
	/// </summary>
	public int AddNoneParameterBubble(TeammateBubbleItem config, int index, int subtype)
	{
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[0]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加单独角色的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="charId"></param>
	/// <returns></returns>
	public int AddSingleCharacterParameterBubble(TeammateBubbleItem config, int index, int subtype, int charId)
	{
		Tester.Assert(config.Parameters[0] == "Character");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 角色身份同道气泡
	/// </summary>
	public int AddCharacterIdentityBubble(TeammateBubbleItem config, int index, int subtype, int charId, OrganizationInfo orgInfo, sbyte gender)
	{
		Tester.Assert(config.Parameters[0] == "Settlement");
		Tester.Assert(config.Parameters[1] == "OrgGrade");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendSettlement(orgInfo.SettlementId);
		AppendOrgGrade(orgInfo.OrgTemplateId, orgInfo.Grade, orgInfo.Principal, gender);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加单独角色模板的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int AddSingleCharacterTemplateNoneParameterBubble(TeammateBubbleItem config, int index, int subtype, short templateId)
	{
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[0]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendCharacterTemplate(templateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加元鸡的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="location"></param>
	/// <param name="chickenTemplateId"></param>
	/// <returns></returns>
	public int AddChickenParameterBubble(TeammateBubbleItem config, int index, int subtype, Location location, short chickenTemplateId)
	{
		Tester.Assert(config.Parameters[0] == "Location");
		Tester.Assert(config.Parameters[1] == "Chicken");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendLocation(location);
		AppendChicken(chickenTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加带有位置的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="location"></param>
	/// <returns></returns>
	public int AddLocationParameterBubble(TeammateBubbleItem config, int index, int subtype, Location location)
	{
		Tester.Assert(config.Parameters[0] == "Location");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendLocation(location);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加奇遇的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="location"></param>
	/// <param name="adventureTemplateId"></param>
	/// <returns></returns>
	public int AddLocationParameterBubble(TeammateBubbleItem config, int index, int subtype, Location location, short adventureTemplateId)
	{
		Tester.Assert(config.Parameters[0] == "Location");
		Tester.Assert(config.Parameters[1] == "Adventure");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendLocation(location);
		AppendAdventure(adventureTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加奇遇的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="adventureTemplateId"></param>
	/// <returns></returns>
	public int AddAdventureParameterBubble(TeammateBubbleItem config, int index, int subtype, int adventureTemplateId)
	{
		Tester.Assert(config.Parameters[0] == "Adventure");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendAdventure(adventureTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加秘闻角色的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="charId"></param>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int AddSecretInformationCharacterParameterBubble(TeammateBubbleItem config, int index, int subtype, int charId, short templateId)
	{
		Tester.Assert(config.Parameters[0] == "Character");
		Tester.Assert(config.Parameters[1] == "SecretInformation");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendCharacter(charId);
		AppendSecretInformationTemplate(templateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加奇书入魔角色的同道气泡文本
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="charId"></param>
	/// <param name="bookKey"></param>
	/// <returns></returns>
	public int AddLegendaryBookInsaneCharacterParameterBubble(TeammateBubbleItem config, int index, int subtype, int charId, ItemKey bookKey)
	{
		Tester.Assert(config.Parameters[0] == "Character");
		Tester.Assert(config.Parameters[1] == "Item");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendCharacter(charId);
		AppendItem(bookKey.ItemType, bookKey.TemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加单独的功法类别名气泡
	/// </summary>
	/// <param name="config"></param>
	/// <param name="index"></param>
	/// <param name="subtype"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	public int AddSingleCombatSkillTypeParameterBubble(TeammateBubbleItem config, int index, int subtype, sbyte type)
	{
		Tester.Assert(config.Parameters[0] == "CombatSkillType");
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[1]));
		Tester.Assert(string.IsNullOrEmpty(config.Parameters[2]));
		int beginOffset = BeginAddingRecord(index, config.TemplateId, subtype);
		AppendCombatSkillType(type);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}

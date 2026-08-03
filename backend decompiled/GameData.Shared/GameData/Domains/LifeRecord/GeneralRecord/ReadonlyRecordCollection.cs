using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 只读的通用记录的集合.
/// 每个记录数据必定包含一个记录类型, 以及一个变长的参数列表. 之后会根据类型和参数列表生成对应的文本以供展示.
/// 记录数据的第一字节固定为该记录的长度 (包括长度数据自身). 因此记录的长度不能超过 255 字节.
///
/// 前端渲染流程:
/// - 调用 GetRenderInfos 获取经历渲染信息, 主体数据放在 RenderInfo 中, 实参放在 ArgumentCollection 中.
/// - 对于前端可以独立渲染的实参, 直接渲染后放入 RenderedArgumentCollection.
/// - 前端无法独立渲染的实参, 调用一系列批量获取渲染相关数据的后端接口, 获取渲染相关数据. 获取到数据并渲染后放入 RenderedArgumentCollection.
/// - 结合 RenderInfo 和 RenderedArgumentCollection 中的数据, 渲染出最终文本, 显示到界面上.
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class ReadonlyRecordCollection : RawDataBlock, IBinary, ISerializableGameData
{
	/// <summary>
	/// 包含的记录的条数
	/// </summary>
	public int Count { get; set; }

	/// <summary>
	/// 只读的通用记录的集合
	/// </summary>
	public ReadonlyRecordCollection()
	{
		Count = 0;
	}

	/// <summary>
	/// 只读的通用记录的集合
	/// </summary>
	/// <param name="initialCapacity">原始数据容器的初始容量</param>
	public ReadonlyRecordCollection(int initialCapacity)
		: base(initialCapacity)
	{
		Count = 0;
	}

	public new bool IsSerializedSizeFixed()
	{
		return false;
	}

	public new int GetSerializedSize()
	{
		return base.GetSerializedSize() + 4;
	}

	public new unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.Serialize(pCurrData);
		*(int*)pCurrData = Count;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	public new unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += base.Deserialize(pCurrData);
		Count = *(int*)pCurrData;
		pCurrData += 4;
		return (int)(pCurrData - pData);
	}

	/// <summary>
	/// 清空数据
	/// </summary>
	public new void Clear()
	{
		Size = 0;
		Count = 0;
	}

	/// <summary>
	/// 获取序列化后的元数据的固定长度.
	/// 元数据必须定长, 且不能超过 64KB.
	/// </summary>
	/// <returns></returns>
	public new ushort GetSerializedFixedSizeOfMetadata()
	{
		return 8;
	}

	/// <summary>
	/// 序列化元数据
	/// </summary>
	/// <param name="pData">生成的数据不包含元数据长度</param>
	/// <returns>序列化后的数据长度</returns>
	public new unsafe int SerializeMetadata(byte* pData)
	{
		*(int*)pData = Size;
		((int*)pData)[1] = Count;
		return 8;
	}

	/// <summary>
	/// 反序列化并应用元数据
	/// </summary>
	/// <param name="pData">此内存中不包含元数据长度</param>
	/// <returns>实际读取的字节数</returns>
	public new unsafe int DeserializeMetadata(byte* pData)
	{
		Size = *(int*)pData;
		Count = ((int*)pData)[1];
		EnsureCapacity(Size);
		return 8;
	}

	/// <summary>
	/// 传入当前的记录索引和数据偏移, 获取下一条的索引和数据偏移
	/// </summary>
	/// <param name="index">当前记录的索引. 开始遍历时, 传入 -1.</param>
	/// <param name="offset">当前记录的数据偏移. 开始遍历时, 传入 -1.</param>
	/// <returns>是否存在下一条记录</returns>
	public bool Next(ref int index, ref int offset)
	{
		if (index < 0)
		{
			if (Count > 0)
			{
				index = 0;
				offset = 0;
				return true;
			}
			return false;
		}
		if (++index >= Count)
		{
			return false;
		}
		byte recordSize = RawData[offset];
		offset += recordSize;
		return true;
	}

	/// <summary>
	/// 传入当前记录的数据偏移, 获取下一条的数据偏移
	/// </summary>
	/// <param name="offset">当前记录的数据偏移. 开始遍历时, 传入 -1.</param>
	/// <returns>返回值大于等于 0 表示存在下一条记录, 小于 0 表示不存在.</returns>
	public int Next(int offset)
	{
		if (offset < 0)
		{
			if (Size <= 0)
			{
				return -1;
			}
			return 0;
		}
		byte recordSize = RawData[offset];
		offset += recordSize;
		if (offset >= Size)
		{
			return -1;
		}
		return offset;
	}

	public int GetOffsetByIndex(int index)
	{
		if (index < 0 || index >= Count)
		{
			return -1;
		}
		int offset = 0;
		for (int i = 0; i < index; i++)
		{
			offset += RawData[offset];
		}
		return offset;
	}

	/// <summary>
	/// 获取当前记录的大小
	/// </summary>
	/// <param name="offset"></param>
	/// <returns></returns>
	public int GetRecordSize(int offset)
	{
		return RawData[offset];
	}

	/// <summary>
	/// 获取所有记录的渲染信息.
	/// 各个派生类需要各自实现自己的此方法, 参数也会各不相同.
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<RenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			RenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定索引的记录的渲染信息.
	/// 各个派生类需要各自实现自己的此方法, 返回值也会各不相同.
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public RenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// 从指定位置读取实参数据, 并存入实参集合, 返回该实参的索引
	/// 修改时应当同步修改这个接口：
	/// ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, TransferableArgumentCollection argumentCollection)
	/// </summary>
	/// <param name="paramType"></param>
	/// <param name="ppData"></param>
	/// <param name="argumentCollection"></param>
	/// <returns></returns>
	protected unsafe static int ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, ArgumentCollection argumentCollection)
	{
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			return argumentCollection.AddCharacter(charId);
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			return argumentCollection.AddLocation(location);
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			return argumentCollection.AddItem(itemType, itemTemplateId);
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			return argumentCollection.AddCombatSkill(combatSkillId);
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			return argumentCollection.AddResource(resourceType);
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			return argumentCollection.AddSettlement(settlementId);
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			return argumentCollection.AddOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			return argumentCollection.AddBuilding(buildingTemplateId);
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			return argumentCollection.AddSwordTomb(xiangshuAvatarId2);
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			return argumentCollection.AddJuniorXiangshu(xiangshuAvatarId);
		}
		case 10:
		{
			int adventureCoreId = ReadAdventure(ppData);
			return argumentCollection.AddAdventure(adventureCoreId);
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			return argumentCollection.AddBehaviorType(behaviorType);
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			return argumentCollection.AddFavorabilityType(favorabilityType);
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			return argumentCollection.AddCricket(colorId, partId, nameId);
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			return argumentCollection.AddItemSubType(itemSubType);
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			return argumentCollection.AddChicken(chickenId);
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			return argumentCollection.AddCharacterPropertyReferencedType(characterPropertyReferencedType);
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			return argumentCollection.AddBodyPartType(bodyPartType);
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			return argumentCollection.AddInjuryType(injuryType);
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			return argumentCollection.AddPoisonType(poisonType);
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			return argumentCollection.AddCharacterTemplate(charTemplate);
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			return argumentCollection.AddFeature(featureId);
		}
		case 22:
		{
			int value29 = ReadInteger(ppData);
			return argumentCollection.AddInteger(value29);
		}
		case 23:
		{
			short value28 = ReadLifeSkill(ppData);
			return argumentCollection.AddLifeSkill(value28);
		}
		case 24:
		{
			sbyte value27 = ReadMerchantType(ppData);
			return argumentCollection.AddMerchantType(value27);
		}
		case 25:
		{
			ulong value26 = ReadItemKey(ppData);
			return argumentCollection.AddItemKey(value26);
		}
		case 26:
		{
			sbyte value25 = ReadCombatType(ppData);
			return argumentCollection.AddCombatType(value25);
		}
		case 27:
		{
			sbyte value24 = ReadLifeSkillType(ppData);
			return argumentCollection.AddLifeSkillType(value24);
		}
		case 28:
		{
			sbyte value23 = ReadCombatSkillType(ppData);
			return argumentCollection.AddCombatSkillType(value23);
		}
		case 29:
		{
			short value22 = ReadInformation(ppData);
			return argumentCollection.AddInformation(value22);
		}
		case 30:
		{
			short value21 = ReadSecretInformationTemplate(ppData);
			return argumentCollection.AddSecretInformationTemplate(value21);
		}
		case 31:
		{
			short value20 = ReadPunishmentType(ppData);
			return argumentCollection.AddPunishmentType(value20);
		}
		case 32:
		{
			short value19 = ReadCharacterTitle(ppData);
			return argumentCollection.AddCharacterTitle(value19);
		}
		case 33:
		{
			float value18 = ReadFloat(ppData);
			return argumentCollection.AddFloat(value18);
		}
		case 34:
		{
			int value17 = ReadCharacter(ppData);
			return argumentCollection.AddCharacterRealName(value17);
		}
		case 35:
		{
			sbyte value16 = ReadMonth(ppData);
			return argumentCollection.AddMonth(value16);
		}
		case 36:
		{
			int value15 = ReadInt(ppData);
			return argumentCollection.AddProfession(value15);
		}
		case 37:
		{
			int value14 = ReadInt(ppData);
			return argumentCollection.AddProfessionSkill(value14);
		}
		case 38:
		{
			sbyte value13 = ReadSByte(ppData);
			return argumentCollection.AddItemGrade(value13);
		}
		case 39:
		{
			string value12 = ReadText(ppData);
			return argumentCollection.AddText(value12);
		}
		case 40:
		{
			short value11 = ReadGeneric<short>(ppData);
			return argumentCollection.AddMusic(value11);
		}
		case 41:
		{
			sbyte value10 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMapState(value10);
		}
		case 42:
		{
			int value9 = ReadGeneric<int>(ppData);
			return argumentCollection.AddJiaoLoong(value9);
		}
		case 43:
		{
			short value8 = ReadGeneric<short>(ppData);
			return argumentCollection.AddJiaoProperty(value8);
		}
		case 44:
		{
			sbyte value7 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddDestinyType(value7);
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			return argumentCollection.AddSecretInformation(templateId, id);
		case 46:
		{
			sbyte value6 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMerchant(value6);
		}
		case 47:
		{
			short value5 = ReadGeneric<short>(ppData);
			return argumentCollection.AddLegacy(value5);
		}
		case 48:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddCharGrade(value4);
		}
		case 49:
		{
			sbyte value3 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddFeast(value3);
		}
		case 50:
		{
			int value2 = ReadGeneric<int>(ppData);
			return argumentCollection.AddAdventureElement(value2);
		}
		case 51:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddPersonalityType(value);
		}
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}

	/// <summary>
	/// 从指定位置读取实参数据, 并存入实参集合, 返回该实参的索引
	/// 此处的代码应与这个同名函数一致（或许应该弃用同名实现 or 提个接口）
	/// ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, ArgumentCollection argumentCollection)
	/// </summary>
	/// <param name="paramType"></param>
	/// <param name="ppData"></param>
	/// <param name="argumentCollection"></param>
	/// <returns></returns>
	protected unsafe static int ReadArgumentAndGetIndex(sbyte paramType, byte** ppData, TransferableArgumentCollection argumentCollection)
	{
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			return argumentCollection.AddCharacter(charId);
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			return argumentCollection.AddLocation(location);
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			return argumentCollection.AddItem(itemType, itemTemplateId);
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			return argumentCollection.AddCombatSkill(combatSkillId);
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			return argumentCollection.AddResource(resourceType);
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			return argumentCollection.AddSettlement(settlementId);
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			return argumentCollection.AddOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			return argumentCollection.AddBuilding(buildingTemplateId);
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			return argumentCollection.AddSwordTomb(xiangshuAvatarId2);
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			return argumentCollection.AddJuniorXiangshu(xiangshuAvatarId);
		}
		case 10:
		{
			int adventureCoreId = ReadAdventure(ppData);
			return argumentCollection.AddAdventure(adventureCoreId);
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			return argumentCollection.AddBehaviorType(behaviorType);
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			return argumentCollection.AddFavorabilityType(favorabilityType);
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			return argumentCollection.AddCricket(colorId, partId, nameId);
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			return argumentCollection.AddItemSubType(itemSubType);
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			return argumentCollection.AddChicken(chickenId);
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			return argumentCollection.AddCharacterPropertyReferencedType(characterPropertyReferencedType);
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			return argumentCollection.AddBodyPartType(bodyPartType);
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			return argumentCollection.AddInjuryType(injuryType);
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			return argumentCollection.AddPoisonType(poisonType);
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			return argumentCollection.AddCharacterTemplate(charTemplate);
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			return argumentCollection.AddFeature(featureId);
		}
		case 22:
		{
			int value29 = ReadInteger(ppData);
			return argumentCollection.AddInteger(value29);
		}
		case 23:
		{
			short value28 = ReadLifeSkill(ppData);
			return argumentCollection.AddLifeSkill(value28);
		}
		case 24:
		{
			sbyte value27 = ReadMerchantType(ppData);
			return argumentCollection.AddMerchantType(value27);
		}
		case 25:
		{
			ulong value26 = ReadItemKey(ppData);
			return argumentCollection.AddItemKey(value26);
		}
		case 26:
		{
			sbyte value25 = ReadCombatType(ppData);
			return argumentCollection.AddCombatType(value25);
		}
		case 27:
		{
			sbyte value24 = ReadLifeSkillType(ppData);
			return argumentCollection.AddLifeSkillType(value24);
		}
		case 28:
		{
			sbyte value23 = ReadCombatSkillType(ppData);
			return argumentCollection.AddCombatSkillType(value23);
		}
		case 29:
		{
			short value22 = ReadInformation(ppData);
			return argumentCollection.AddInformation(value22);
		}
		case 30:
		{
			short value21 = ReadSecretInformationTemplate(ppData);
			return argumentCollection.AddSecretInformationTemplate(value21);
		}
		case 31:
		{
			short value20 = ReadPunishmentType(ppData);
			return argumentCollection.AddPunishmentType(value20);
		}
		case 32:
		{
			short value19 = ReadCharacterTitle(ppData);
			return argumentCollection.AddCharacterTitle(value19);
		}
		case 33:
		{
			float value18 = ReadFloat(ppData);
			return argumentCollection.AddFloat(value18);
		}
		case 34:
		{
			int value17 = ReadCharacter(ppData);
			return argumentCollection.AddCharacterRealName(value17);
		}
		case 35:
		{
			sbyte value16 = ReadMonth(ppData);
			return argumentCollection.AddMonth(value16);
		}
		case 36:
		{
			int value15 = ReadInt(ppData);
			return argumentCollection.AddProfession(value15);
		}
		case 37:
		{
			int value14 = ReadInt(ppData);
			return argumentCollection.AddProfessionSkill(value14);
		}
		case 38:
		{
			sbyte value13 = ReadSByte(ppData);
			return argumentCollection.AddItemGrade(value13);
		}
		case 39:
		{
			string value12 = ReadText(ppData);
			return argumentCollection.AddText(value12);
		}
		case 40:
		{
			short value11 = ReadGeneric<short>(ppData);
			return argumentCollection.AddMusic(value11);
		}
		case 41:
		{
			sbyte value10 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMapState(value10);
		}
		case 42:
		{
			int value9 = ReadGeneric<int>(ppData);
			return argumentCollection.AddJiaoLoong(value9);
		}
		case 43:
		{
			short value8 = ReadGeneric<short>(ppData);
			return argumentCollection.AddJiaoProperty(value8);
		}
		case 44:
		{
			sbyte value7 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddDestinyType(value7);
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			return argumentCollection.AddSecretInformation(templateId, id);
		case 46:
		{
			sbyte value6 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddMerchant(value6);
		}
		case 47:
		{
			short value5 = ReadGeneric<short>(ppData);
			return argumentCollection.AddLegacy(value5);
		}
		case 48:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddCharGrade(value4);
		}
		case 49:
		{
			sbyte value3 = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddFeast(value3);
		}
		case 50:
		{
			int value2 = ReadGeneric<int>(ppData);
			return argumentCollection.AddAdventureElement(value2);
		}
		case 51:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			return argumentCollection.AddPersonalityTypes(value);
		}
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}

	/// <summary>
	/// 从指定位置读取角色数据
	/// </summary>
	private unsafe static int ReadCharacter(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	/// <summary>
	/// 从指定位置读取地点数据
	/// </summary>
	private unsafe static Location ReadLocation(byte** ppData)
	{
		short areaId = *(short*)(*ppData);
		short blockId = ((short*)(*ppData))[1];
		*ppData += 4;
		return new Location(areaId, blockId);
	}

	/// <summary>
	/// 从指定位置读取物品数据
	/// </summary>
	private unsafe static (sbyte itemType, short itemTemplateId) ReadItem(byte** ppData)
	{
		byte item = *(*ppData);
		short itemTemplateId = *(short*)(*ppData + 1);
		*ppData += 3;
		return (itemType: (sbyte)item, itemTemplateId: itemTemplateId);
	}

	/// <summary>
	/// 从指定位置读取功法数据
	/// </summary>
	private unsafe static short ReadCombatSkill(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取资源数据
	/// </summary>
	private unsafe static sbyte ReadResource(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取定居点数据
	/// </summary>
	private unsafe static short ReadSettlement(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取团体级别数据
	/// </summary>
	private unsafe static (sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender) ReadOrgGrade(byte** ppData)
	{
		byte item = *(*ppData);
		sbyte orgGrade = (sbyte)(*ppData)[1];
		bool orgPrincipal = (*ppData + 1)[1] != 0;
		sbyte gender = (sbyte)(*ppData + 1 + 1)[1];
		*ppData += 4;
		return (orgTemplateId: (sbyte)item, orgGrade: orgGrade, orgPrincipal: orgPrincipal, gender: gender);
	}

	/// <summary>
	/// 从指定位置读取产业建筑数据
	/// </summary>
	private unsafe static short ReadBuilding(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取剑冢数据
	/// </summary>
	private unsafe static sbyte ReadSwordTomb(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取紫竹化身数据
	/// </summary>
	private unsafe static sbyte ReadJuniorXiangshu(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取奇遇数据
	/// </summary>
	private unsafe static int ReadAdventure(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	/// <summary>
	/// 从指定位置读取角色立场数据
	/// </summary>
	private unsafe static sbyte ReadBehaviorType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取好感类型数据
	/// </summary>
	private unsafe static sbyte ReadFavorabilityType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取促织数据
	/// </summary>
	private unsafe static (short colorId, short partId, int nameId) ReadCricket(byte** ppData)
	{
		short item = *(short*)(*ppData);
		short partId = ((short*)(*ppData))[1];
		int nameId = *(int*)(*ppData + 2 + 2);
		*ppData += 8;
		return (colorId: item, partId: partId, nameId: nameId);
	}

	/// <summary>
	/// 从指定位置读取物品子类数据
	/// </summary>
	private unsafe static short ReadItemSubType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取鸡数据
	/// </summary>
	private unsafe static short ReadChicken(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取角色属性引用类型数据
	/// </summary>
	private unsafe static short ReadCharacterPropertyReferencedType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取身体部位类型数据
	/// </summary>
	private unsafe static sbyte ReadBodyPartType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取伤势类型数据
	/// </summary>
	private unsafe static sbyte ReadInjuryType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取毒素类型数据
	/// </summary>
	private unsafe static sbyte ReadPoisonType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取角色模板数据
	/// </summary>
	private unsafe static short ReadCharacterTemplate(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取角色特性数据
	/// </summary>
	private unsafe static short ReadFeature(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取整型数值
	/// </summary>
	private unsafe static int ReadInteger(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	/// <summary>
	/// 从指定位置读取技艺模板数据
	/// </summary>
	private unsafe static short ReadLifeSkill(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取商会类型
	/// </summary>
	private unsafe static sbyte ReadMerchantType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取物品Key
	/// </summary>
	private unsafe static ulong ReadItemKey(byte** ppData)
	{
		long result = *(long*)(*ppData);
		*ppData += 8;
		return (ulong)result;
	}

	/// <summary>
	/// 从指定位置读取战斗类型
	/// </summary>
	private unsafe static sbyte ReadCombatType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取技艺类型
	/// </summary>
	private unsafe static sbyte ReadLifeSkillType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取功法类型
	/// </summary>
	private unsafe static sbyte ReadCombatSkillType(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取见闻
	/// </summary>
	private unsafe static short ReadInformation(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取秘闻模板
	/// </summary>
	private unsafe static short ReadSecretInformationTemplate(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取惩罚类型
	/// </summary>
	private unsafe static short ReadPunishmentType(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取角色称号
	/// </summary>
	private unsafe static short ReadCharacterTitle(byte** ppData)
	{
		short result = *(short*)(*ppData);
		*ppData += 2;
		return result;
	}

	/// <summary>
	/// 从指定位置读取浮点数
	/// </summary>
	private unsafe static float ReadFloat(byte** ppData)
	{
		float result = *(float*)(*ppData);
		*ppData += 4;
		return result;
	}

	/// <summary>
	/// 从指定位置读取月份
	/// </summary>
	private unsafe static sbyte ReadMonth(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取 Int
	/// </summary>
	private unsafe static int ReadInt(byte** ppData)
	{
		int result = *(int*)(*ppData);
		*ppData += 4;
		return result;
	}

	/// <summary>
	/// 从指定位置读取 SByte
	/// </summary>
	/// <param name="ppData"></param>
	/// <returns></returns>
	private unsafe static sbyte ReadSByte(byte** ppData)
	{
		byte result = *(*ppData);
		(*ppData)++;
		return (sbyte)result;
	}

	/// <summary>
	/// 从指定位置读取非托管类型
	/// </summary>
	/// <param name="ppData"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	private unsafe static T ReadGeneric<T>(byte** ppData) where T : unmanaged
	{
		T result = *(T*)(*ppData);
		*ppData += sizeof(T);
		return result;
	}

	/// <summary>
	/// 从指定位置读取文本
	/// </summary>
	/// <param name="ppData"></param>
	/// <returns></returns>
	private unsafe static string ReadText(byte** ppData)
	{
		string val;
		int size = SerializationHelper.Deserialize(*ppData, out val);
		*ppData += size;
		return val;
	}

	/// <summary>
	/// 从指定位置读取秘闻实例
	/// </summary>
	/// <param name="ppData"></param>
	/// <returns></returns>
	public unsafe static (short templateId, int id) ReadSecretInformation(byte** ppData)
	{
		short item = *(short*)(*ppData);
		int id = *(int*)(*ppData + 2);
		*ppData += 6;
		return (templateId: item, id: id);
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadData(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		int index = -1;
		int offset = -1;
		int date = -1;
		while (Next(ref index, ref offset))
		{
			TransferableRecord record = ReadRenderInfo(offset, data, getParameters);
			if (data.Record.Count == 0)
			{
				data.AddSeparateLine(data.EndDate = (date = record.Date));
			}
			else if (record.Date < date)
			{
				data.AddDate(date);
				date = record.Date;
				data.AddSeparateLine(date);
			}
			else if (record.Date > date)
			{
				record.Date = date;
			}
			data.Record.Add(record);
		}
		data.StartDate = date;
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadRenderInfo);
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// "WithNormalOrder"指的是，读取数据的顺序正常（顺序存储），而读取结果也正常（逆序存储）
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <param name="readRenderInfo">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters, Func<int, TransferableRecordDataBase, Func<int, string[]>, TransferableRecord> readRenderInfo)
	{
		int index = -1;
		int offset = -1;
		int date = -1;
		while (Next(ref index, ref offset))
		{
			TransferableRecord record = readRenderInfo(offset, data, getParameters);
			if (record == null)
			{
				break;
			}
			if (data.Record.Count == 0 || record.Date > date)
			{
				if (data.Record.Count == 0)
				{
					data.StartDate = record.Date;
				}
				else
				{
					data.AddSeparateLine(date);
				}
				date = record.Date;
				data.AddDate(date);
			}
			else if (record.Date < date)
			{
				record.Date = date;
			}
			data.Record.Add(record);
		}
		data.AddSeparateLine(data.EndDate = date);
		data.Record.Reverse();
	}

	/// <summary>
	/// 获取指定索引的经历的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="data">实参集合</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public unsafe TransferableRecord ReadRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			int date = *(int*)(pCurrData + 1);
			short recordType = ((short*)(pCurrData + 1))[2];
			pCurrData += 7;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadTaiwuVillageDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTaiwuVillageRenderInfo);
	}

	/// <summary>
	/// 获取指定索引的经历的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="data">实参集合</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public unsafe TransferableRecord ReadTaiwuVillageRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			sbyte storageType = (sbyte)(*pCurrData);
			pCurrData++;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, storageType));
			return info;
		}
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadOrganizationRecordDataWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadOrganizationRecordRenderInfo);
	}

	/// <summary>
	/// 获取指定索引的经历的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="data">实参集合</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public unsafe TransferableRecord ReadOrganizationRecordRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short settlementId = *(short*)pCurrData;
			pCurrData += 2;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, settlementId));
			return info;
		}
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadTeaHorseEventWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTeaHorseEventRenderInfo);
	}

	/// <summary>
	/// 获取指定索引的经历的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="data">实参集合</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public unsafe TransferableRecord ReadTeaHorseEventRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData += 5;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(date, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	/// <summary>
	/// 获取所有经历的渲染信息 - 新版
	/// </summary>
	/// <param name="data">要渲染的数据，需保证Record为空</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public void ReadTeammateBubbleWithNormalOrder(TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		ReadDataWithNormalOrder(data, getParameters, ReadTeammateBubbleRenderInfo);
	}

	/// <summary>
	/// 获取指定索引的经历的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="data">实参集合</param>
	/// <param name="getParameters">获取参数信息的函数，需注意：null == 出错，Array.Empty == 无参</param>
	/// <returns></returns>
	public unsafe TransferableRecord ReadTeammateBubbleRenderInfo(int offset, TransferableRecordDataBase data, Func<int, string[]> getParameters)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset + 1;
			int index = *(int*)pCurrData;
			pCurrData += 4;
			int subtype = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			int charTemplateId = ((subtype == 5) ? (*(short*)pCurrData) : 0);
			if (subtype == 5)
			{
				pCurrData += 2;
			}
			string[] parameters = getParameters(recordType);
			if (parameters == null)
			{
				return null;
			}
			TransferableRecord info = new TransferableRecord(0, recordType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadArgumentAndGetIndex(paramType, &pCurrData, data.ArgumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			info.Arguments.Add((22, charTemplateId));
			info.Arguments.Add((22, index));
			info.Arguments.Add((22, subtype));
			return info;
		}
	}

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
	/// 将指定位置的一条记录的全部参数填充到事件参数盒子
	/// </summary>
	/// <param name="offset">记录所在位置</param>
	/// <param name="eventArgBox">需要填充的事件参数盒子</param>
	public virtual void FillEventArgBox(int offset, IVariantCollection<string> eventArgBox)
	{
	}

	/// <summary>
	/// 读取一个参数并将其填充到事件参数盒子
	/// </summary>
	protected unsafe void ReadArgumentToEventArgBox(string keyPrefix, int argIndex, sbyte paramType, byte** ppData, IVariantCollection<string> argBox)
	{
		string argKey = $"{keyPrefix}{argIndex}";
		switch (paramType)
		{
		case 0:
		{
			int charId = ReadCharacter(ppData);
			argBox.Set(argKey, charId);
			break;
		}
		case 1:
		{
			Location location = ReadLocation(ppData);
			argBox.Set(argKey, location);
			break;
		}
		case 2:
			var (itemType, itemTemplateId) = ReadItem(ppData);
			argBox.Set(argKey + "_itemType", itemType);
			argBox.Set(argKey + "_itemTemplateId", itemTemplateId);
			break;
		case 3:
		{
			short combatSkillId = ReadCombatSkill(ppData);
			argBox.Set(argKey, combatSkillId);
			break;
		}
		case 4:
		{
			sbyte resourceType = ReadResource(ppData);
			argBox.Set(argKey, resourceType);
			break;
		}
		case 5:
		{
			short settlementId = ReadSettlement(ppData);
			argBox.Set(argKey, settlementId);
			break;
		}
		case 6:
			var (orgTemplateId, orgGrade, orgPrincipal, gender) = ReadOrgGrade(ppData);
			argBox.Set(argKey + "_orgTemplateId", orgTemplateId);
			argBox.Set(argKey + "_orgGrade", orgGrade);
			argBox.Set(argKey + "_orgPrincipal", orgPrincipal);
			argBox.Set(argKey + "_gender", gender);
			break;
		case 7:
		{
			short buildingTemplateId = ReadBuilding(ppData);
			argBox.Set(argKey, buildingTemplateId);
			break;
		}
		case 8:
		{
			sbyte xiangshuAvatarId2 = ReadSwordTomb(ppData);
			argBox.Set(argKey, xiangshuAvatarId2);
			break;
		}
		case 9:
		{
			sbyte xiangshuAvatarId = ReadJuniorXiangshu(ppData);
			argBox.Set(argKey, xiangshuAvatarId);
			break;
		}
		case 10:
		{
			int adventureTemplateId = ReadAdventure(ppData);
			argBox.Set(argKey, adventureTemplateId);
			break;
		}
		case 11:
		{
			sbyte behaviorType = ReadBehaviorType(ppData);
			argBox.Set(argKey, behaviorType);
			break;
		}
		case 12:
		{
			sbyte favorabilityType = ReadFavorabilityType(ppData);
			argBox.Set(argKey, favorabilityType);
			break;
		}
		case 13:
			var (colorId, partId, nameId) = ReadCricket(ppData);
			argBox.Set(argKey + "_colorId", colorId);
			argBox.Set(argKey + "_partId", partId);
			argBox.Set(argKey + "_nameId", nameId);
			break;
		case 14:
		{
			short itemSubType = ReadItemSubType(ppData);
			argBox.Set(argKey, itemSubType);
			break;
		}
		case 15:
		{
			short chickenId = ReadChicken(ppData);
			argBox.Set(argKey, chickenId);
			break;
		}
		case 16:
		{
			short characterPropertyReferencedType = ReadCharacterPropertyReferencedType(ppData);
			argBox.Set(argKey, characterPropertyReferencedType);
			break;
		}
		case 17:
		{
			sbyte bodyPartType = ReadBodyPartType(ppData);
			argBox.Set(argKey, bodyPartType);
			break;
		}
		case 18:
		{
			sbyte injuryType = ReadInjuryType(ppData);
			argBox.Set(argKey, injuryType);
			break;
		}
		case 19:
		{
			sbyte poisonType = ReadPoisonType(ppData);
			argBox.Set(argKey, poisonType);
			break;
		}
		case 20:
		{
			short charTemplate = ReadCharacterTemplate(ppData);
			argBox.Set(argKey, charTemplate);
			break;
		}
		case 21:
		{
			short featureId = ReadFeature(ppData);
			argBox.Set(argKey, featureId);
			break;
		}
		case 22:
		{
			int value23 = ReadInteger(ppData);
			argBox.Set(argKey, value23);
			break;
		}
		case 23:
		{
			short value22 = ReadLifeSkill(ppData);
			argBox.Set(argKey, value22);
			break;
		}
		case 24:
		{
			sbyte value21 = ReadMerchantType(ppData);
			argBox.Set(argKey, value21);
			break;
		}
		case 25:
		{
			ulong value20 = ReadItemKey(ppData);
			argBox.Set(argKey, (ItemKey)value20);
			break;
		}
		case 26:
		{
			sbyte value19 = ReadCombatType(ppData);
			argBox.Set(argKey, value19);
			break;
		}
		case 27:
		{
			sbyte value18 = ReadLifeSkillType(ppData);
			argBox.Set(argKey, value18);
			break;
		}
		case 28:
		{
			sbyte value17 = ReadCombatSkillType(ppData);
			argBox.Set(argKey, value17);
			break;
		}
		case 29:
		{
			short value16 = ReadInformation(ppData);
			argBox.Set(argKey, value16);
			break;
		}
		case 30:
		{
			short value15 = ReadSecretInformationTemplate(ppData);
			argBox.Set(argKey, value15);
			break;
		}
		case 31:
		{
			short value14 = ReadPunishmentType(ppData);
			argBox.Set(argKey, value14);
			break;
		}
		case 32:
		{
			short value13 = ReadCharacterTitle(ppData);
			argBox.Set(argKey, value13);
			break;
		}
		case 33:
		{
			float value12 = ReadFloat(ppData);
			argBox.Set(argKey, value12);
			break;
		}
		case 34:
		{
			int value11 = ReadCharacter(ppData);
			argBox.Set(argKey, value11);
			break;
		}
		case 35:
		{
			sbyte value10 = ReadMonth(ppData);
			argBox.Set(argKey, value10);
			break;
		}
		case 36:
		{
			int value9 = ReadInt(ppData);
			argBox.Set(argKey, value9);
			break;
		}
		case 37:
		{
			int value8 = ReadInt(ppData);
			argBox.Set(argKey, value8);
			break;
		}
		case 38:
		{
			sbyte value7 = ReadSByte(ppData);
			argBox.Set(argKey, value7);
			break;
		}
		case 39:
		{
			string value6 = ReadText(ppData);
			argBox.Set(argKey, value6);
			break;
		}
		case 40:
		{
			short value5 = ReadGeneric<short>(ppData);
			argBox.Set(argKey, value5);
			break;
		}
		case 41:
		{
			sbyte value4 = ReadGeneric<sbyte>(ppData);
			argBox.Set(argKey, value4);
			break;
		}
		case 42:
		{
			int value3 = ReadGeneric<int>(ppData);
			argBox.Set(argKey, value3);
			break;
		}
		case 43:
		{
			short value2 = ReadGeneric<short>(ppData);
			argBox.Set(argKey, value2);
			break;
		}
		case 44:
		{
			sbyte value = ReadGeneric<sbyte>(ppData);
			argBox.Set(argKey, value);
			break;
		}
		case 45:
			var (templateId, id) = ReadSecretInformation(ppData);
			argBox.Set(argKey + "_templateId", templateId);
			argBox.Set(argKey + "_id", id);
			break;
		default:
			throw new Exception($"Unsupported ParameterType: {paramType}");
		}
	}
}

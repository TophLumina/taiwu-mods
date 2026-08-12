using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.Merchant;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 事件中目标角色显示的额外信息
/// ！！！生成后需要手动注释SelectItemData在Serialize方法里的长度断言，否则会再次触发由于背包过大送礼时导致的报错！！！
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class TaiwuEventDisplayExtraData : ISerializableGameData
{
	/// <summary>
	/// 是否隐藏右边人物的好感度
	/// </summary>
	[SerializableGameDataField]
	public bool HideRightFavorability;

	/// <summary>
	/// 是否打开左边人物的好感度
	/// </summary>
	[SerializableGameDataField]
	public bool HideLeftFavorability;

	/// <summary>
	/// 是否禁止查看目标人物
	/// </summary>
	[SerializableGameDataField]
	public bool ForbidViewCharacter;

	/// <summary>
	/// 是否禁止查看主要人物
	/// </summary>
	[SerializableGameDataField]
	public bool ForbidViewSelf;

	/// <summary>
	/// 做选择的角色名字显示使用代称
	/// </summary>
	[SerializableGameDataField]
	public bool MainRoleUseAlternativeName;

	/// <summary>
	/// 目标交谈角色名字显示使用代称
	/// </summary>
	[SerializableGameDataField]
	public bool TargetRoleUseAlternativeName;

	/// <summary>
	/// 主要人物是否害羞标记位
	/// </summary>
	[SerializableGameDataField]
	public bool MainRoleShyFlag;

	/// <summary>
	/// 目标人物是否害羞标记位
	/// </summary>
	[SerializableGameDataField]
	public bool TargetRoleShyFlag;

	/// <summary>
	/// 左侧人物是否显示伤病信息
	/// </summary>
	[SerializableGameDataField]
	public bool LeftRoleShowInjuryInfo;

	/// <summary>
	/// 右侧人物是否显示伤病信息
	/// </summary>
	[SerializableGameDataField]
	public bool RightRoleShowInjuryInfo;

	/// <summary>
	/// 主要人物临时穿搭的衣装id
	/// 如果值为负数，表示该值没有意义
	/// </summary>
	[SerializableGameDataField]
	public short MainRoleAdjustClothDisplayId;

	/// <summary>
	/// 目标人物临时穿搭的衣装id
	/// 如果值为负数，表示该值没有意义
	/// </summary>
	[SerializableGameDataField]
	public short TargetRoleAdjustClothDisplayId;

	/// <summary>
	/// 当外道在地图上未生成时,使用此id以显示剪影
	/// </summary>
	[SerializableGameDataField]
	public short HereticTemplateId;

	/// <summary>
	/// 正在互动的商队Id，此字段赋值后商队形象代替交互目标角色显示
	/// </summary>
	[SerializableGameDataField]
	public CaravanDisplayData CaravanData;

	/// <summary>
	/// 选择物品的信息，如果事件带有这个信息，将会刷新为选择物品的显示模式
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public EventSelectItemData SelectItemData;

	/// <summary>
	/// 选择人物的信息，如果事件带有这个信息，将会刷新为选择人物的显示模式
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public EventSelectCharacterData SelectCharacterData;

	/// <summary>
	/// 选择研读书籍次数数据
	/// </summary>
	[SerializableGameDataField]
	public EventSelectReadingBookCountData SelectReadingBookCountData;

	/// <summary>
	/// 选择功法运转次数数据
	/// </summary>
	[SerializableGameDataField]
	public EventSelectNeigongLoopingCountData SelectNeigongLoopingCountData;

	/// <summary>
	/// 选择伏虞心念数据
	/// </summary>
	[SerializableGameDataField]
	public EventSelectFuyuFaithCountData SelectFuyuFaithCountData;

	/// <summary>
	/// 选择名誉的信息，如果事件带有这个信息，将会刷新为选择名誉的显示模式
	/// </summary>
	[SerializableGameDataField]
	public EventSelectFameData SelectFameData;

	/// <summary>
	/// 要求用户输入的信息，如果事件带有这个信息，将会刷新为输入状态模式
	/// </summary>
	[SerializableGameDataField]
	public EventInputRequestData InputRequestData;

	/// <summary>
	/// 演员相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public EventActorData ActorData;

	/// <summary>
	/// 左侧显示为演员的相关显示数据
	/// </summary>
	[SerializableGameDataField]
	public EventActorData LeftActorData;

	/// <summary>
	/// 用于从多个avatar里选择一个avatar的数据列表
	/// </summary>
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<AvatarRelatedData> SelectOneAvatarRelatedDataList;

	/// <summary>
	/// 右侧普通角色使用剪影
	/// </summary>
	[SerializableGameDataField]
	public bool RightCharacterShadow;

	/// <summary>
	/// 右侧普通角色禁止显示精纯
	/// </summary>
	[SerializableGameDataField]
	public bool RightForbiddenConsummateLevel;

	/// <summary>
	/// 左侧是否显示好感变化特效
	/// </summary>
	[SerializableGameDataField]
	public bool LeftForbidShowFavorChangeEffect;

	/// <summary>
	/// 右侧是否显示好感变化特效
	/// </summary>
	[SerializableGameDataField]
	public bool RightForbidShowFavorChangeEffect;

	/// <summary>
	/// 要显示的蛟tips需要的数据
	/// 看代码目前只需要ItemDisplayData，若需要则以后修改这里
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData JiaoDisplayData;

	/// <summary>
	/// 左侧演员显示婚服1
	/// </summary>
	[SerializableGameDataField]
	public bool LeftActorShowMarriageLook1;

	/// <summary>
	/// 左侧演员显示婚服2
	/// </summary>
	[SerializableGameDataField]
	public bool LeftActorShowMarriageLook2;

	/// <summary>
	/// 右侧演员显示婚服1
	/// </summary>
	[SerializableGameDataField]
	public bool RightActorShowMarriageLook1;

	/// <summary>
	/// 右侧演员显示婚服2
	/// </summary>
	[SerializableGameDataField]
	public bool RightActorShowMarriageLook2;

	/// <summary>
	/// 是否显示通用快捷按键
	/// </summary>
	[SerializableGameDataField]
	public sbyte ShowCommonOptionIndex;

	/// <summary>
	/// 是否显示互动toggle
	/// </summary>
	[SerializableGameDataField]
	public bool ShowInteractOption;

	/// <summary>
	/// 是否显示志向预览
	/// </summary>
	[SerializableGameDataField]
	public bool ShowProfessionReview;

	/// <summary>
	/// 是否显示地格人物背景
	/// </summary>
	[SerializableGameDataField]
	public bool ShowBlockCharacterBack;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 28;
		totalSize = ((CaravanData == null) ? (totalSize + 2) : (totalSize + (2 + CaravanData.GetSerializedSize())));
		totalSize = ((SelectItemData == null) ? (totalSize + 4) : (totalSize + (4 + SelectItemData.GetSerializedSize())));
		totalSize = ((SelectCharacterData == null) ? (totalSize + 4) : (totalSize + (4 + SelectCharacterData.GetSerializedSize())));
		totalSize = ((SelectReadingBookCountData == null) ? (totalSize + 2) : (totalSize + (2 + SelectReadingBookCountData.GetSerializedSize())));
		totalSize = ((SelectNeigongLoopingCountData == null) ? (totalSize + 2) : (totalSize + (2 + SelectNeigongLoopingCountData.GetSerializedSize())));
		totalSize = ((SelectFuyuFaithCountData == null) ? (totalSize + 2) : (totalSize + (2 + SelectFuyuFaithCountData.GetSerializedSize())));
		totalSize = ((SelectFameData == null) ? (totalSize + 2) : (totalSize + (2 + SelectFameData.GetSerializedSize())));
		totalSize = ((InputRequestData == null) ? (totalSize + 2) : (totalSize + (2 + InputRequestData.GetSerializedSize())));
		totalSize = ((ActorData == null) ? (totalSize + 2) : (totalSize + (2 + ActorData.GetSerializedSize())));
		totalSize = ((LeftActorData == null) ? (totalSize + 2) : (totalSize + (2 + LeftActorData.GetSerializedSize())));
		if (SelectOneAvatarRelatedDataList != null)
		{
			totalSize += 2;
			int elementsCount = SelectOneAvatarRelatedDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				AvatarRelatedData element = SelectOneAvatarRelatedDataList[i];
				totalSize = ((element == null) ? (totalSize + 4) : (totalSize + (4 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((JiaoDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + JiaoDisplayData.GetSerializedSize())));
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
		*pCurrData = (HideRightFavorability ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HideLeftFavorability ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ForbidViewCharacter ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ForbidViewSelf ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (MainRoleUseAlternativeName ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TargetRoleUseAlternativeName ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (MainRoleShyFlag ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TargetRoleShyFlag ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (LeftRoleShowInjuryInfo ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RightRoleShowInjuryInfo ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = MainRoleAdjustClothDisplayId;
		pCurrData += 2;
		*(short*)pCurrData = TargetRoleAdjustClothDisplayId;
		pCurrData += 2;
		*(short*)pCurrData = HereticTemplateId;
		pCurrData += 2;
		if (CaravanData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CaravanData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectItemData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 4;
			int fieldSize2 = SelectItemData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= int.MaxValue);
			*(int*)intPtr2 = fieldSize2;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SelectCharacterData != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 4;
			int fieldSize3 = SelectCharacterData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= int.MaxValue);
			*(int*)intPtr3 = fieldSize3;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SelectReadingBookCountData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = SelectReadingBookCountData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectNeigongLoopingCountData != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = SelectNeigongLoopingCountData.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectFuyuFaithCountData != null)
		{
			byte* intPtr6 = pCurrData;
			pCurrData += 2;
			int fieldSize6 = SelectFuyuFaithCountData.Serialize(pCurrData);
			pCurrData += fieldSize6;
			Tester.Assert(fieldSize6 <= 65535);
			*(ushort*)intPtr6 = (ushort)fieldSize6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectFameData != null)
		{
			byte* intPtr7 = pCurrData;
			pCurrData += 2;
			int fieldSize7 = SelectFameData.Serialize(pCurrData);
			pCurrData += fieldSize7;
			Tester.Assert(fieldSize7 <= 65535);
			*(ushort*)intPtr7 = (ushort)fieldSize7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InputRequestData != null)
		{
			byte* intPtr8 = pCurrData;
			pCurrData += 2;
			int fieldSize8 = InputRequestData.Serialize(pCurrData);
			pCurrData += fieldSize8;
			Tester.Assert(fieldSize8 <= 65535);
			*(ushort*)intPtr8 = (ushort)fieldSize8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ActorData != null)
		{
			byte* intPtr9 = pCurrData;
			pCurrData += 2;
			int fieldSize9 = ActorData.Serialize(pCurrData);
			pCurrData += fieldSize9;
			Tester.Assert(fieldSize9 <= 65535);
			*(ushort*)intPtr9 = (ushort)fieldSize9;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LeftActorData != null)
		{
			byte* intPtr10 = pCurrData;
			pCurrData += 2;
			int fieldSize10 = LeftActorData.Serialize(pCurrData);
			pCurrData += fieldSize10;
			Tester.Assert(fieldSize10 <= 65535);
			*(ushort*)intPtr10 = (ushort)fieldSize10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SelectOneAvatarRelatedDataList != null)
		{
			int elementsCount = SelectOneAvatarRelatedDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				AvatarRelatedData element = SelectOneAvatarRelatedDataList[i];
				if (element != null)
				{
					byte* intPtr11 = pCurrData;
					pCurrData += 4;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= int.MaxValue);
					*(int*)intPtr11 = subDataSize;
				}
				else
				{
					*(int*)pCurrData = 0;
					pCurrData += 4;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (RightCharacterShadow ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RightForbiddenConsummateLevel ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (LeftForbidShowFavorChangeEffect ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RightForbidShowFavorChangeEffect ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (JiaoDisplayData != null)
		{
			byte* intPtr12 = pCurrData;
			pCurrData += 2;
			int fieldSize11 = JiaoDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize11;
			Tester.Assert(fieldSize11 <= 65535);
			*(ushort*)intPtr12 = (ushort)fieldSize11;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (LeftActorShowMarriageLook1 ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (LeftActorShowMarriageLook2 ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RightActorShowMarriageLook1 ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (RightActorShowMarriageLook2 ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)ShowCommonOptionIndex;
		pCurrData++;
		*pCurrData = (ShowInteractOption ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowProfessionReview ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (ShowBlockCharacterBack ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		HideRightFavorability = *pCurrData != 0;
		pCurrData++;
		HideLeftFavorability = *pCurrData != 0;
		pCurrData++;
		ForbidViewCharacter = *pCurrData != 0;
		pCurrData++;
		ForbidViewSelf = *pCurrData != 0;
		pCurrData++;
		MainRoleUseAlternativeName = *pCurrData != 0;
		pCurrData++;
		TargetRoleUseAlternativeName = *pCurrData != 0;
		pCurrData++;
		MainRoleShyFlag = *pCurrData != 0;
		pCurrData++;
		TargetRoleShyFlag = *pCurrData != 0;
		pCurrData++;
		LeftRoleShowInjuryInfo = *pCurrData != 0;
		pCurrData++;
		RightRoleShowInjuryInfo = *pCurrData != 0;
		pCurrData++;
		MainRoleAdjustClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		TargetRoleAdjustClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		HereticTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (CaravanData == null)
			{
				CaravanData = new CaravanDisplayData();
			}
			pCurrData += CaravanData.Deserialize(pCurrData);
		}
		else
		{
			CaravanData = null;
		}
		int num2 = *(int*)pCurrData;
		pCurrData += 4;
		if (num2 > 0)
		{
			if (SelectItemData == null)
			{
				SelectItemData = new EventSelectItemData();
			}
			pCurrData += SelectItemData.Deserialize(pCurrData);
		}
		else
		{
			SelectItemData = null;
		}
		int num3 = *(int*)pCurrData;
		pCurrData += 4;
		if (num3 > 0)
		{
			if (SelectCharacterData == null)
			{
				SelectCharacterData = new EventSelectCharacterData();
			}
			pCurrData += SelectCharacterData.Deserialize(pCurrData);
		}
		else
		{
			SelectCharacterData = null;
		}
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			if (SelectReadingBookCountData == null)
			{
				SelectReadingBookCountData = new EventSelectReadingBookCountData();
			}
			pCurrData += SelectReadingBookCountData.Deserialize(pCurrData);
		}
		else
		{
			SelectReadingBookCountData = null;
		}
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			if (SelectNeigongLoopingCountData == null)
			{
				SelectNeigongLoopingCountData = new EventSelectNeigongLoopingCountData();
			}
			pCurrData += SelectNeigongLoopingCountData.Deserialize(pCurrData);
		}
		else
		{
			SelectNeigongLoopingCountData = null;
		}
		ushort num6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num6 > 0)
		{
			if (SelectFuyuFaithCountData == null)
			{
				SelectFuyuFaithCountData = new EventSelectFuyuFaithCountData();
			}
			pCurrData += SelectFuyuFaithCountData.Deserialize(pCurrData);
		}
		else
		{
			SelectFuyuFaithCountData = null;
		}
		ushort num7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num7 > 0)
		{
			if (SelectFameData == null)
			{
				SelectFameData = new EventSelectFameData();
			}
			pCurrData += SelectFameData.Deserialize(pCurrData);
		}
		else
		{
			SelectFameData = null;
		}
		ushort num8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num8 > 0)
		{
			if (InputRequestData == null)
			{
				InputRequestData = new EventInputRequestData();
			}
			pCurrData += InputRequestData.Deserialize(pCurrData);
		}
		else
		{
			InputRequestData = null;
		}
		ushort num9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num9 > 0)
		{
			if (ActorData == null)
			{
				ActorData = new EventActorData();
			}
			pCurrData += ActorData.Deserialize(pCurrData);
		}
		else
		{
			ActorData = null;
		}
		ushort num10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num10 > 0)
		{
			if (LeftActorData == null)
			{
				LeftActorData = new EventActorData();
			}
			pCurrData += LeftActorData.Deserialize(pCurrData);
		}
		else
		{
			LeftActorData = null;
		}
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (SelectOneAvatarRelatedDataList == null)
			{
				SelectOneAvatarRelatedDataList = new List<AvatarRelatedData>(elementsCount);
			}
			else
			{
				SelectOneAvatarRelatedDataList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int num11 = *(int*)pCurrData;
				pCurrData += 4;
				if (num11 > 0)
				{
					AvatarRelatedData element = new AvatarRelatedData();
					pCurrData += element.Deserialize(pCurrData);
					SelectOneAvatarRelatedDataList.Add(element);
				}
				else
				{
					SelectOneAvatarRelatedDataList.Add(null);
				}
			}
		}
		else
		{
			SelectOneAvatarRelatedDataList?.Clear();
		}
		RightCharacterShadow = *pCurrData != 0;
		pCurrData++;
		RightForbiddenConsummateLevel = *pCurrData != 0;
		pCurrData++;
		LeftForbidShowFavorChangeEffect = *pCurrData != 0;
		pCurrData++;
		RightForbidShowFavorChangeEffect = *pCurrData != 0;
		pCurrData++;
		ushort num12 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num12 > 0)
		{
			if (JiaoDisplayData == null)
			{
				JiaoDisplayData = new ItemDisplayData();
			}
			pCurrData += JiaoDisplayData.Deserialize(pCurrData);
		}
		else
		{
			JiaoDisplayData = null;
		}
		LeftActorShowMarriageLook1 = *pCurrData != 0;
		pCurrData++;
		LeftActorShowMarriageLook2 = *pCurrData != 0;
		pCurrData++;
		RightActorShowMarriageLook1 = *pCurrData != 0;
		pCurrData++;
		RightActorShowMarriageLook2 = *pCurrData != 0;
		pCurrData++;
		ShowCommonOptionIndex = (sbyte)(*pCurrData);
		pCurrData++;
		ShowInteractOption = *pCurrData != 0;
		pCurrData++;
		ShowProfessionReview = *pCurrData != 0;
		pCurrData++;
		ShowBlockCharacterBack = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

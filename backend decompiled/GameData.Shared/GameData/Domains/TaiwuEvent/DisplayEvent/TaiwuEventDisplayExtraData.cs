using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Domains.Item.Display;
using GameData.Domains.Merchant;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class TaiwuEventDisplayExtraData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool HideRightFavorability;

	[SerializableGameDataField]
	public bool HideLeftFavorability;

	[SerializableGameDataField]
	public bool ForbidViewCharacter;

	[SerializableGameDataField]
	public bool ForbidViewSelf;

	[SerializableGameDataField]
	public bool MainRoleUseAlternativeName;

	[SerializableGameDataField]
	public bool TargetRoleUseAlternativeName;

	[SerializableGameDataField]
	public bool MainRoleShyFlag;

	[SerializableGameDataField]
	public bool TargetRoleShyFlag;

	[SerializableGameDataField]
	public bool LeftRoleShowInjuryInfo;

	[SerializableGameDataField]
	public bool RightRoleShowInjuryInfo;

	[SerializableGameDataField]
	public short MainRoleAdjustClothDisplayId;

	[SerializableGameDataField]
	public short TargetRoleAdjustClothDisplayId;

	[SerializableGameDataField]
	public short HereticTemplateId;

	[SerializableGameDataField]
	public CaravanDisplayData CaravanData;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public EventSelectItemData SelectItemData;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public EventSelectCharacterData SelectCharacterData;

	[SerializableGameDataField]
	public EventSelectReadingBookCountData SelectReadingBookCountData;

	[SerializableGameDataField]
	public EventSelectNeigongLoopingCountData SelectNeigongLoopingCountData;

	[SerializableGameDataField]
	public EventSelectFuyuFaithCountData SelectFuyuFaithCountData;

	[SerializableGameDataField]
	public EventSelectFameData SelectFameData;

	[SerializableGameDataField]
	public EventInputRequestData InputRequestData;

	[SerializableGameDataField]
	public EventActorData ActorData;

	[SerializableGameDataField]
	public EventActorData LeftActorData;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public List<AvatarRelatedData> SelectOneAvatarRelatedDataList;

	[SerializableGameDataField]
	public bool RightCharacterShadow;

	[SerializableGameDataField]
	public bool RightForbiddenConsummateLevel;

	[SerializableGameDataField]
	public bool LeftForbidShowFavorChangeEffect;

	[SerializableGameDataField]
	public bool RightForbidShowFavorChangeEffect;

	[SerializableGameDataField]
	public ItemDisplayData JiaoDisplayData;

	[SerializableGameDataField]
	public bool LeftActorShowMarriageLook1;

	[SerializableGameDataField]
	public bool LeftActorShowMarriageLook2;

	[SerializableGameDataField]
	public bool RightActorShowMarriageLook1;

	[SerializableGameDataField]
	public bool RightActorShowMarriageLook2;

	[SerializableGameDataField]
	public sbyte ShowCommonOptionIndex;

	[SerializableGameDataField]
	public bool ShowInteractOption;

	[SerializableGameDataField]
	public bool ShowProfessionReview;

	[SerializableGameDataField]
	public bool ShowBlockCharacterBack;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

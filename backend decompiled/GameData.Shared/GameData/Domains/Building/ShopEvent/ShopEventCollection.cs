using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Building.ShopEvent;

public class ShopEventCollection : WriteableRecordCollection
{
	public void GetRenderInfos(List<ShopEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			ShopEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return ((short*)(pRawData + offset + 1))[2];
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	public new unsafe ShopEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			ShopEventItem config = Config.ShopEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			ShopEventRenderInfo info = new ShopEventRenderInfo(recordType, config.Desc, date);
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

	private unsafe int BeginAddingRecord(int date, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = recordType;
		}
		return offset;
	}

	public int AddCollectResourceSuccess0(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess1(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess2(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 2);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 3);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 4);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 5);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess6(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 6);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess7(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 7);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess8(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 8);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccess9(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 9);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess0(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 10);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess1(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 11);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess2(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 12);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 13);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 14);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 15);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess6(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 16);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess7(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 17);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess8(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 18);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceSuccess9(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 19);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 20);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 21);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 22);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 23);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 24);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 25);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 26);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 27);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail8(int date)
	{
		int beginOffset = BeginAddingRecord(date, 28);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceFail9(int date)
	{
		int beginOffset = BeginAddingRecord(date, 29);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 30);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 31);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 32);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 33);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 34);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 35);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 36);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 37);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail8(int date)
	{
		int beginOffset = BeginAddingRecord(date, 38);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectBetterResourceFail9(int date)
	{
		int beginOffset = BeginAddingRecord(date, 39);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 40);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 41);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 42);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 43);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 44);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 45);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 46);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 47);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 48);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 49);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 50);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMusicBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 51);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 52);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 53);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 54);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 55);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 56);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageChessBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 57);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 58);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 59);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 60);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 61);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 62);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePoemBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 63);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 64);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 65);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 66);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 67);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 68);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManagePaintingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 69);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 70);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 71);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 72);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 73);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 74);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMathBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 75);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 76);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess1(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 77);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 78);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess3(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 79);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 80);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 81);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 82);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 83);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 84);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 85);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 86);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageAppraisalBuildingFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 87);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 88);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 89);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 90);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 91);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 92);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 93);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 94);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 95);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 96);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageForgingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 97);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 98);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 99);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 100);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 101);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 102);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 103);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 104);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 105);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 106);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWoodworkingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 107);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 108);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 109);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 110);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 111);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 112);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 113);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 114);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 115);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 116);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageMedicineBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 117);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 118);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 119);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 120);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 121);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 122);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 123);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 124);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 125);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 126);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageToxicologyBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 127);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 128);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 129);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 130);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 131);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 132);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 133);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 134);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 135);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 136);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageWeavingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 137);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 138);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 139);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 140);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 141);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 142);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 143);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 144);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 145);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 146);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageJadeBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 147);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 148);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 149);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 150);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 151);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 152);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageTaoismBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 153);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 154);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 155);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 156);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 157);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 158);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageBuddhismBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 159);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 160);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 161);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 162);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 163);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 164);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 165);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 166);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 167);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 168);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCookingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 169);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 170);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess1(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 171);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 172);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 173);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 174);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess5(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 175);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess6(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 176);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingSuccess7(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 177);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 178);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 179);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 180);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 181);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 182);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 183);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 184);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageEclecticBuildingFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 185);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnLifeSkillSuccess(int date, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 186);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnCombatSkillSuccess(int date, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 187);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnLifeSkillFail(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 188);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnCombatSkillFail(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 189);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageLifeSkillAbilityUp(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 190);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddManageCombatSkillAbilityUp(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 191);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBaseDevelopLifeSkill(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 192);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBaseDevelopCombatSkill(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 193);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPersonalityDevelopLifeSkill(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 194);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddPersonalityDevelopCombatSkill(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 195);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLeaderDevelopLifeSkill(int date, int charId, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 196);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLeaderDevelopCombatSkill(int date, int charId, int charId1, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 197);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnLifeSkill(int date, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 198);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddLearnCombatSkill(int date, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 199);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSalaryReceived(int date, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, 200);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_1(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 201);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_2(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 202);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_3(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 203);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_4(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 204);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_5(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 205);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_6(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 206);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_7(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 207);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_8(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 208);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_9(int date, int charId)
	{
		int beginOffset = BeginAddingRecord(date, 209);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddBanquet_10(int date, int charId)
	{
		int beginOffset = BeginAddingRecord(date, 210);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectItemSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte itemType, short itemTemplateId)
	{
		if (shopEventCfg.Parameters[0] != "Item" || !string.IsNullOrEmpty(shopEventCfg.Parameters[1]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard collect item success record: {shopEventCfg.Desc}", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecruitSuccessRecord(ShopEventItem shopEventCfg, int date)
	{
		Tester.Assert(string.IsNullOrEmpty(shopEventCfg.Parameters[0]));
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddRecruitWithCostSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte resourceType, int amount)
	{
		if (shopEventCfg.Parameters[0] != "Resource" || shopEventCfg.Parameters[1] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[2]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard recruit people success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendResource(resourceType);
		AppendInteger(amount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddCollectResourceSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte resourceType, int resourceAmount)
	{
		if (shopEventCfg.Parameters[0] != "Resource" || shopEventCfg.Parameters[1] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[2]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard collect resource success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendResource(resourceType);
		AppendInteger(resourceAmount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddSellItemSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int amount)
	{
		if (shopEventCfg.Parameters[0] != "Item" || shopEventCfg.Parameters[1] != "Resource" || shopEventCfg.Parameters[2] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[3]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard sell item success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(amount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFailureRecord(ShopEventItem shopEventCfg, int date)
	{
		if (!string.IsNullOrEmpty(shopEventCfg.Parameters[0]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard failure record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	public int AddFeastRecord(int charId, sbyte happiness, ItemKey dish, ItemKey gift, short feastType, bool loveItem)
	{
		int date = ExternalDataBridge.Context.CurrDate;
		short defKey = (short)((happiness <= GlobalConfig.Instance.FeastLowHappiness) ? ((feastType != 0) ? ((!loveItem) ? 203 : 204) : ((!loveItem) ? 201 : 202)) : ((feastType != 0) ? ((!loveItem) ? 207 : 208) : ((!loveItem) ? 205 : 206)));
		int beginOffset = BeginAddingRecord(date, defKey);
		AppendCharacter(charId);
		AppendItem(dish.ItemType, dish.TemplateId);
		AppendItem(gift.ItemType, gift.TemplateId);
		if (feastType != 0)
		{
			AppendFeast(feastType);
		}
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}

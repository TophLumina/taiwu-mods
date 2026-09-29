using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.TeaHorseCaravanEvent;

public class TeaHorseCaravanEventCollection : WriteableRecordCollection
{
	private unsafe int BeginAddingRecord(int startMonthAndDistanceToTaiwuVillage, int date, short type)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = startMonthAndDistanceToTaiwuVillage;
			((int*)(num + 1))[1] = date;
			((short*)(num + 1 + 4))[2] = type;
		}
		return offset;
	}

	public void AddFindMirage(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 0);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindBigfoot(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 1);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindAnimal(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 2);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindPlant(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 3);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddGetInformation(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 4);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindSettlement(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 5);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindWeather(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 6);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddLost(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 7);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMeetTheif(int startMonthAndDistanceToTaiwuVillage, int date)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 8);
		EndAddingRecord(beginOffset);
	}

	public void AddMeetTheif1(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 9);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddMeetTheif2(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 10);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
	}

	public void AddMeetTheif3(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 11);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		EndAddingRecord(beginOffset);
	}

	public void AddGoodsDamage(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 12);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddFindWreckage(int startMonthAndDistanceToTaiwuVillage, int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 13);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
	}

	public void AddHelpPasserby(int startMonthAndDistanceToTaiwuVillage, int date, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 14);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
	}

	public void AddUnacclimatized(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 15);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddGetHelp(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 16);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindVenison(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 17);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindFruit(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 18);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddFindVillage(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 19);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}

	public void AddMeetMerchan(int startMonthAndDistanceToTaiwuVillage, int date, int value)
	{
		int beginOffset = BeginAddingRecord(startMonthAndDistanceToTaiwuVillage, date, 20);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
	}
}

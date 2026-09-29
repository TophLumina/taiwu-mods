namespace GameData.Domains.LifeRecord;

public class TransferableLifeRecordData : TransferableRecordDataBase
{
	public override void AddSeparateLine(int date, bool increaseExtraCount = true)
	{
		Record.Add(new TransferableRecord(date, -3));
		if (increaseExtraCount)
		{
			ExtraCount++;
		}
	}

	public override void AddBirth(int date)
	{
		TransferableRecord dateLine = new TransferableRecord(date, -1);
		dateLine.Arguments.Add((-1, date));
		Record.Add(dateLine);
	}
}

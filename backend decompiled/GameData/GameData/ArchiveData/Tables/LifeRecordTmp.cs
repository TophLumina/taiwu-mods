using System;
using SQLite;

namespace GameData.ArchiveData.Tables;

[DatabaseEntry]
public class LifeRecordTmp
{
	[PrimaryKey]
	[AutoIncrement]
	public int Id { get; set; }

	[Indexed]
	[NotNull]
	public int Self { get; set; }

	[NotNull]
	public int Date { get; set; }

	[NotNull]
	public int Type { get; set; }

	public byte[] Param { get; set; }

	public LifeRecordTmp()
	{
	}

	public LifeRecordTmp(LifeRecordTmp other, bool deep = false)
	{
		Self = other.Self;
		Date = other.Date;
		Type = other.Type;
		if (deep)
		{
			byte[] param = other.Param;
			int len = ((param != null) ? param.Length : 0);
			if (len > 0)
			{
				Param = new byte[len];
				Buffer.BlockCopy(other.Param, 0, Param, 0, len);
			}
		}
		else
		{
			Param = other.Param;
		}
	}
}

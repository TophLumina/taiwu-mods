using System.Collections.Generic;

namespace GameData.Domains.LifeRecord.GeneralRecord;

public class RenderInfo
{
	public readonly short RecordType;

	public readonly string Text;

	public readonly List<(sbyte paramType, int index)> Arguments;

	public RenderInfo(short recordType, string text)
	{
		RecordType = recordType;
		Text = text;
		Arguments = new List<(sbyte, int)>();
	}
}

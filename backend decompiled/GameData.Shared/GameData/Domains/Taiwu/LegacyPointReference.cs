using System;

namespace GameData.Domains.Taiwu;

[Serializable]
public class LegacyPointReference
{
	public short TemplateId { get; private set; }

	public int WinPercent { get; private set; }

	public int FailPercent { get; private set; }

	public LegacyPointReference(short templateId, int winPercent, int failPercent)
	{
		TemplateId = templateId;
		WinPercent = winPercent;
		FailPercent = failPercent;
	}
}

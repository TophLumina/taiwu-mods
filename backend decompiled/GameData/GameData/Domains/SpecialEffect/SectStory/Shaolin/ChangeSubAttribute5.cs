using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class ChangeSubAttribute5 : ChangeSubAttributeBase
{
	protected override IReadOnlyList<ushort> SubAttributes { get; } = new ushort[2] { 15, 16 };

	public ChangeSubAttribute5(int charId, IReadOnlyList<int> parameters)
		: base(charId, parameters)
	{
	}
}

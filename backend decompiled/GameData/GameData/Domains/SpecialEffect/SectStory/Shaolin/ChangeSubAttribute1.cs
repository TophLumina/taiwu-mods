using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class ChangeSubAttribute1 : ChangeSubAttributeBase
{
	protected override IReadOnlyList<ushort> SubAttributes { get; } = new ushort[2] { 8, 7 };

	public ChangeSubAttribute1(int charId, IReadOnlyList<int> parameters)
		: base(charId, parameters)
	{
	}
}

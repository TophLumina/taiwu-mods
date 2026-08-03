using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class ChangeSubAttribute2 : ChangeSubAttributeBase
{
	protected override IReadOnlyList<ushort> SubAttributes { get; } = new ushort[2] { 9, 10 };

	public ChangeSubAttribute2(int charId, IReadOnlyList<int> parameters)
		: base(charId, parameters)
	{
	}
}

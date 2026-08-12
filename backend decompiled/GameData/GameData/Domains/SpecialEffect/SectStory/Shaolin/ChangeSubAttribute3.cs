using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class ChangeSubAttribute3 : ChangeSubAttributeBase
{
	protected override IReadOnlyList<ushort> SubAttributes { get; } = new ushort[2] { 11, 12 };

	public ChangeSubAttribute3(int charId, IReadOnlyList<int> parameters)
		: base(charId, parameters)
	{
	}
}

using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class ChangeSubAttribute4 : ChangeSubAttributeBase
{
	protected override IReadOnlyList<ushort> SubAttributes { get; } = new ushort[2] { 14, 13 };

	public ChangeSubAttribute4(int charId, IReadOnlyList<int> parameters)
		: base(charId, parameters)
	{
	}
}

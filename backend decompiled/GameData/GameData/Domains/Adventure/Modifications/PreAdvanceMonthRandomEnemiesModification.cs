using System.Collections.Generic;
using GameData.Domains.Map;

namespace GameData.Domains.Adventure.Modifications;

public class PreAdvanceMonthRandomEnemiesModification
{
	public short AreaId;

	public List<(int charId, MapTemplateEnemyInfo enemyInfo)> RandomEnemyAttackRecords = new List<(int, MapTemplateEnemyInfo)>();

	public List<(int charId, int animal)> AnimalAttackRecords = new List<(int, int)>();
}

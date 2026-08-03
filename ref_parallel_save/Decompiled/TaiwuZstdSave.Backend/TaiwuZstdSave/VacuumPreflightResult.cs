namespace TaiwuZstdSave;

internal readonly record struct VacuumPreflightResult(bool ShouldVacuum, double EstimatedReclaimableBytes, double ThresholdBytes, bool UsedSecondSample);

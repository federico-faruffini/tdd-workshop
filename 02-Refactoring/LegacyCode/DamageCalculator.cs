
using LegacyCode;

public class DamageCalculator
{
    public static int ComputeDamage(Player? a, Enemy? e)
    {
        if (a == null || e == null)
        {
            throw new ArgumentNullException(nameof(a));
        }

        int d = a.Atk + a.Bonus - e.Defense;

        if (d < 0)
        {
            d = 0;
        }

        if (e.IsVulnerable)
        {
            d += 5;
        }

        if (a.DamageType != DamageType.Basic)
        {
            if (a.DamageType == e.ResistanceToType)
            {
                d -= 3;
            }
        }

        if (d < 0)
        {
            d = 0;
        }

        if (d > e.LifePoints)
        {
            d = e.LifePoints;
        }

        return d;
    }
}


using LegacyCode;

public class DamageCalculator
{
    private const int vulnerabilityDamage = 5;

    public static int ComputeDamage(Player? player, Enemy? enemy)
    {
        if (player == null || enemy == null)
        {
            throw new ArgumentNullException(nameof(player));
        }

        int totalDamage = player.Attack + player.Bonus - enemy.Defense;

        totalDamage = ResetDamageIfNegative(totalDamage);

        totalDamage = ApplyVulnerabilityDamage(enemy, totalDamage);

        if (player.DamageType != DamageType.Basic)
        {
            if (player.DamageType == enemy.ResistanceToType)
            {
                totalDamage -= 3;
            }
        }

        totalDamage = ResetDamageIfNegative(totalDamage);

        if (totalDamage > enemy.LifePoints)
        {
            totalDamage = enemy.LifePoints;
        }

        return totalDamage;
    }

    private static int ResetDamageIfNegative(int totalDamage)
    {
        if (totalDamage < 0)
        {
            totalDamage = 0;
        }

        return totalDamage;
    }

    private static int ApplyVulnerabilityDamage(Enemy enemy, int totalDamage)
    {
        if (enemy.IsVulnerable)
        {
            totalDamage += vulnerabilityDamage;
        }

        return totalDamage;
    }
}

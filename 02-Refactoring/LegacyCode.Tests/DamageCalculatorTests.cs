using Xunit;
using LegacyCode;
using System;

public class DamageCalculatorTests
{
    [Fact]
    public void GivenAttackGreaterThanDefenseAndNoModifiers_WhenComputeDamage_ThenReturnsCorrectDamage()
    {
        // Arrange
        var playerAttack = 10;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack - enemyDefense;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenAttackLessThanDefenseAndNoModifiers_WhenComputeDamage_ThenReturnsZero()
    {
        // Arrange
        var playerAttack = 3;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = 0;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenBonusPresent_WhenComputeDamage_ThenBonusIsAdded()
    {
        // Arrange
        var playerAttack = 5;
        var playerBonus = 3;
        var enemyDefense = 6;
        var playerDamageType = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, Bonus = playerBonus, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack + playerBonus - enemyDefense;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenEnemyIsVulnerable_WhenComputeDamage_ThenAddsFive()
    {
        // Arrange
        var playerAttack = 8;
        var playerBonus = 2;
        var enemyDefense = 5;
        var enemyIsVulnerable = true;
        var playerDamageType = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, Bonus = playerBonus, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, IsVulnerable = enemyIsVulnerable, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack + playerBonus - enemyDefense + 5;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenDamageTypeMatchesResistanceAndIsNotBasic_WhenComputeDamage_ThenSubtractsThree()
    {
        // Arrange
        var playerAttack = 10;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Fire;
        var enemyResistance = DamageType.Fire;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, ResistanceToType = enemyResistance, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack - enemyDefense - 3;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenDamageTypeIsBasicAndMatchesResistance_WhenComputeDamage_ThenNoPenaltyApplied()
    {
        // Arrange
        var playerAttack = 10;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Basic;
        var enemyResistance = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, ResistanceToType = enemyResistance, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack - enemyDefense;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenResistanceNotMatchingAndDamageTypeIsNotBasic_WhenComputeDamage_ThenNoMalusApplied()
    {
        // Arrange
        var playerAttack = 10;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Frost;
        var enemyResistance = DamageType.Fire;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, ResistanceToType = enemyResistance, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack - enemyDefense;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenAllModifiersActiveAndDamageExceedsLifePoints_WhenComputeDamage_ThenReturnsClampedToLifePoints()
    {
        // Arrange
        var playerAttack = 30;
        var playerBonus = 10;
        var enemyDefense = 5;
        var enemyIsVulnerable = true;
        var playerDamageType = DamageType.Frost;
        var enemyResistance = DamageType.Fire;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, Bonus = playerBonus, DamageType = playerDamageType };
        var enemy = new Enemy
        {
            Defense = enemyDefense,
            IsVulnerable = enemyIsVulnerable,
            ResistanceToType = enemyResistance,
            LifePoints = enemyLifePoints
        };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = enemyLifePoints;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenDamageEqualsLifePoints_WhenComputeDamage_ThenReturnsExactLifePoints()
    {
        // Arrange
        var playerAttack = 25;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Basic;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = playerAttack - enemyDefense;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenDamageLessThanLifePointsAndEnemyIsVulnerable_WhenComputeDamage_ThenReturnsDamageFromVulnerability()
    {
        // Arrange
        var playerAttack = 5;
        var enemyDefense = 8;
        var enemyLifePoints = 10;
        var enemyIsVulnerable = true;

        var player = new Player { Atk = playerAttack };
        var enemy = new Enemy { Defense = enemyDefense, IsVulnerable = enemyIsVulnerable, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = 5;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenDamageBelowZeroAfterAllModifiers_WhenComputeDamage_ThenReturnsZero()
    {
        // Arrange
        var playerAttack = 3;
        var playerBonus = 0;
        var enemyDefense = 5;
        var playerDamageType = DamageType.Frost;
        var enemyResistance = DamageType.Frost;
        var enemyLifePoints = 20;

        var player = new Player { Atk = playerAttack, Bonus = playerBonus, DamageType = playerDamageType };
        var enemy = new Enemy { Defense = enemyDefense, ResistanceToType = enemyResistance, LifePoints = enemyLifePoints };

        // Act
        var result = DamageCalculator.ComputeDamage(player, enemy);

        // Assert
        var expectedValue = 0;
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GivenNullPlayer_WhenComputeDamage_ThenThrowsArgumentNullException()
    {
        // Arrange
        var enemyDefense = 5;
        var enemyLifePoints = 10;
        var enemy = new Enemy { Defense = enemyDefense, LifePoints = enemyLifePoints };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => DamageCalculator.ComputeDamage(null, enemy));
    }

    [Fact]
    public void GivenNullEnemy_WhenComputeDamage_ThenThrowsArgumentNullException()
    {
        // Arrange
        var player = new Player { Atk = 5 };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => DamageCalculator.ComputeDamage(player, null));
    }

    [Fact]
    public void GivenNullPlayerAndNullEnemy_WhenComputeDamage_ThenThrowsArgumentNullException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentNullException>(() => DamageCalculator.ComputeDamage(null, null));
    }
}

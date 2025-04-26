using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class EnemyTypeNameMapper
{
    public static int ToInt(EnemyTypeName enemyTypeName)
    {
        return (int)enemyTypeName;
    }

    public static EnemyTypeName ToEnemyTypeName(int enemyTypeNameIndex)
    {
        switch (enemyTypeNameIndex)
        {
        case 0 : return EnemyTypeName.Robot; 
        case 1 : return EnemyTypeName.Naturelle;
        case 2 : return EnemyTypeName.Extraterrestre;
        case 3 : return EnemyTypeName.Paranormal;
        case 4 : return EnemyTypeName.Animal;
        case 5 : return EnemyTypeName.Expérience;
        default: return EnemyTypeName.Humanoïde;
        }
    }
}
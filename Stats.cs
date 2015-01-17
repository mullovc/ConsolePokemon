using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Stats
        {
            public int index;
            public string name;

            public Type type1;
            public Type type2;
            public Nature nature;
            public LevelingSpeed levelingSpeed;
            public int[] learnableMoves = new int[100];
            public bool wild;

            public float baseHp;
            public float baseDef;
            public float baseAtk;
            public float baseSpDef;
            public float baseSpAtk;
            public float baseInit;
            public float baseXpYield;

            public float hpEVYield;
            public float atkEVYield;
            public float defEVYield;
            public float spAtkEVYield;
            public float spDefEVYield;
            public float initEVYield;


            public enum Type
            {
                None,
                Normal,
                Fighting,
                Rock,
                Ground,
                Flying,
                Dark,
                Ghost,
                Bug,
                Fire,
                Water,
                Grass,
                Electric,
                Psychic,
                Steel,
                Ice,
                Dragon,
                Poison
            }

            public enum Nature
            {
                //...
            }

            public enum LevelingSpeed
            {
                Erratic,
                Fast,
                MediumFast,
                MediumSlow,
                Slow,
                Fluctuating
            }

            public Stats(int index, string name, float baseHp, float baseAtk, float baseDef, float baseSpAtk, float baseSpDef, float baseInit,
                         float baseXpYield, float hpEVYield, float atkEVYield, float defEVYield, float spAtkEVYield, float spDefEVYield, float initEVYield,
                         Type type1, Type type2, LevelingSpeed levelingSpeed)
            {
                this.index = index;
                this.name = name;
                this.baseHp = baseHp;
                this.baseAtk = baseAtk;
                this.baseDef = baseDef;
                this.baseSpAtk = baseSpAtk;
                this.baseSpDef = baseSpDef;
                this.baseInit = baseInit;
                this.type1 = type1;
                this.type2 = type2;
                this.levelingSpeed = levelingSpeed;
                this.baseXpYield = baseXpYield;
                this.hpEVYield = hpEVYield;
                this.atkEVYield = atkEVYield;
                this.defEVYield = defEVYield;
                this.spAtkEVYield = spAtkEVYield;
                this.spDefEVYield = spDefEVYield;
                this.initEVYield = initEVYield;
            }

            public Stats()
            {

            }
        }
    }
}

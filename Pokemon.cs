using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    namespace Model
    {
        class Pokemon
        {
            public Stats stats;

            public float xp;
            public int level;
            public Status primaryStatus;
            public Status secondaryStatus = Status.None;

            public Move[] moves = new Move[4];

            public float maxHp;
            public float hp;
            public float def;
            public float atk;
            public float spDef;
            public float spAtk;
            public float init;

            public float hpEV;
            public float defEV;
            public float atkEV;
            public float spDefEV;
            public float spAtkEV;
            public float initEV;

            float hpDV;
            float defDV;
            float atkDV;
            float spDefDV;
            float spAtkDV;
            float initDV;


            public enum Status
            {
                None,
                Fainted,
                Asleep,
                Paralyzed,
                Confused,
                Burned,
                Poisoned,
                BadlyPoisoned,
                Frozen,
                Fleeing
            }

            public Pokemon(Stats stats)
            {
                this.stats = stats;
            }


            public void initialize(int lvl)
            {
                Random rand = new Random();
                hpDV = rand.Next(32);
                atkDV = rand.Next(32);
                defDV = rand.Next(32);
                spAtkDV = rand.Next(32);
                spDefDV = rand.Next(32);
                initDV = rand.Next(32);
                stats.nature = (Stats.Nature)rand.Next(0);

                level = lvl;
                xp = getXpForLvlUp(lvl);

                update(true);
                heal();
            }


            public void update(bool resetStats = false)
            {
                if (xp >= getXpForLvlUp(level + 1))
                {
                    levelUp();
                }


                if (resetStats)
                {
                    float n = level;

                    maxHp = (int)((hpDV + 2f * stats.baseHp + hpEV / 4 + 100f) * (n / 100f) + 10f);
                    atk = (int)((atkDV + 2f * stats.baseAtk + atkEV / 4) * (n / 100f) + 5f);
                    spAtk = (int)((spAtkDV + 2f * stats.baseSpAtk + spAtkEV / 4) * (n / 100f) + 5f);
                    def = (int)((defDV + 2f * stats.baseDef + defEV / 4) * (n / 100f) + 5f);
                    spDef = (int)((spDefDV + 2f * stats.baseSpDef + spDefEV / 4) * (n / 100f) + 5f);
                    init = (int)((initDV + 2f * stats.baseInit + initEV / 4) * (n / 100f) + 5f);

                    secondaryStatus = Status.None;
                }
            }

            public void win(Pokemon loser)
            {
                xp += (int)(loser.stats.baseXpYield * loser.level / 7);

                hpEV += loser.stats.hpEVYield;
                atkEV += loser.stats.atkEVYield;
                defEV += loser.stats.defEVYield;
                spAtkEV += loser.stats.spAtkEVYield;
                spDefEV += loser.stats.spDefEVYield;
                initEV += loser.stats.initEVYield;

                update(true);
            }

            public void faint()
            {
                primaryStatus = Status.Fainted;
                hp = 0;
            }


            public void damage(int amount)
            {
                hp -= (int)amount;
            }

            public bool ableToFight()
            {
                return !(primaryStatus == Status.Fainted | primaryStatus == Status.Frozen | primaryStatus == Status.Asleep);
            }

            void levelUp()
            {
                level++;

                if (stats.learnableMoves[level] != 0)
                {
                    //learnMove(learnableMoves[level]);
                }

                update(true);
            }


            public int getXpForLvlUp(float n)
            {
                double result = 0;

                if (stats.levelingSpeed == Stats.LevelingSpeed.Erratic)
                {
                    if (n <= 50)
                        result = Math.Pow(n, 3) * ((100 - n) / 50);
                    else if (n > 50 && n <= 68)
                        result = Math.Pow(n, 3) * ((150 - n) / 100);
                    else if (n > 68 && n <= 98)
                        result = Math.Pow(n, 3) * ((1911 - 10 * n) / 1500);
                    else if (n > 98 && n <= 100)
                        result = Math.Pow(n, 3) * ((160 - n) / 100);
                }
                else if (stats.levelingSpeed == Stats.LevelingSpeed.Fast)
                {
                    result = (4 * Math.Pow(n, 3)) / 5;
                }
                else if (stats.levelingSpeed == Stats.LevelingSpeed.MediumFast)
                {
                    result = Math.Pow(n, 3);
                }
                else if (stats.levelingSpeed == Stats.LevelingSpeed.MediumSlow)
                {
                    result = (6 / 5) * Math.Pow(n, 3) - 15 * n * n + 100 * n - 140;
                }
                else if (stats.levelingSpeed == Stats.LevelingSpeed.Slow)
                {
                    result = (5 / 4) * Math.Pow(n, 3);
                }
                else if (stats.levelingSpeed == Stats.LevelingSpeed.Fluctuating)
                {
                    if (n <= 15)
                        result = Math.Pow(n, 3) * ((((n + 1) / 3) + 24) / 50);
                    else if (n > 15 && n <= 36)
                        result = Math.Pow(n, 3) * ((n + 14) / 50);
                    else if (n > 36 && n <= 100)
                        result = Math.Pow(n, 3) * (((n / 2) + 32) / 50);
                }

                return (int)result;
            }

            public void heal()
            {
                update(true);
                hp = maxHp;
                primaryStatus = Status.None;
            }

            public String getName()
            {
                return stats.name;
            }
        }
    }
}

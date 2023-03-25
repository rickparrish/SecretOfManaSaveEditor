using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavLibrary {
    public static class ExperienceFaq {
        private static Dictionary<CharacterType, List<Level>> CharacterLevels = new Dictionary<CharacterType, List<Level>>();

        static ExperienceFaq() {
            // Load the level data from Experience FAQ
            string[] lines = Properties.Resources.Experience_FAQ.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            CharacterLevels.Add(CharacterType.Boy, new List<Level>());
            for (int i = 60; i <= 158; i++) {
                CharacterLevels[CharacterType.Boy].Add(new Level(lines[i]));
            }

            CharacterLevels.Add(CharacterType.Girl, new List<Level>());
            for (int i = 272; i <= 370; i++) {
                CharacterLevels[CharacterType.Girl].Add(new Level(lines[i]));
            }

            CharacterLevels.Add(CharacterType.Sprite, new List<Level>());
            for (int i = 166; i <= 264; i++) {
                CharacterLevels[CharacterType.Sprite].Add(new Level(lines[i]));
            }
        }

        public static Level GetLevel(CharacterType characterType, int levelNumber) {
            return CharacterLevels[characterType].Single(x => x.Number == levelNumber);
        }

        public static Level GetLevelByExperience(CharacterType characterType, int experience) {
            return CharacterLevels[characterType].Last(x => x.Experience <= experience);
        }
    }

    public class Level {
        public int Number { get; set; }
        public int Experience { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Hit { get; set; }
        public int Defense { get; set; }
        public int Evade { get; set; }
        public int MagicDefense { get; set; }



        public Level(string line) {
            // Example for Boy
            // | Level |   Exp   |  HP | Str | Agl | Con | Int | Wis | Hit | Def | Eva | MDef|
            // -------------------------------------------------------------------------------
            // |  01   |       0 |  50 |  15 |  15 |  13 |   5 |   5 |  78 |  13 |   3 |   5 |

            // Example for Girl and Sprite
            // | Lvl|   Exp  |  HP | MP | Str | Agl | Con | Int | Wis | Hit | Def | Eva |MDef|
            // -------------------------------------------------------------------------------
            // | 01 |      0 |  40 |  8 |   7 |  12 |  10 |  15 |  5  |  78 |  10 |   3 |  5 |

            int i = 0;
            int[] values = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => int.Parse(x.Trim()))
                               .ToArray();

            Number = values[i++];
            Experience = values[i++];
            HitPoints = values[i++];
            if (values.Length == 13) {
                ManaPoints = values[i++];
            }
            Strength = values[i++];
            Agility = values[i++];
            Constitution = values[i++];
            Intelligence = values[i++];
            Wisdom = values[i++];
            Hit = values[i++];
            Defense = values[i++];
            Evade = values[i++];
            MagicDefense = values[i++];
        }
    }
}

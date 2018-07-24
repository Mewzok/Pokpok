using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokpok
{
    public class Abilites
    {
        // A
        private string name = "";
        private Activation? activation = null;
        private string effect = "";

        public class setAdaptability
        {
            public string name { get { return name; } set { name = "Adaptability"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Static; } }
            public string description { get { return description; } set {description = "When using Moves that deal damage and are the same elemental Type as the Pokémon with Adaptability," + "" +
                        " add 2 STAB instead of 1."; } }

            private void effect()
            {

            }

            public string adaptabilityInfo()
            {
                return $"Name: {name}\nActivation Type: {activation}\nEffect: {description}";
            }
        }

        //public string getAdaptabilityInfo { get { return ada; } }

        private class Aftermath
        {
            public string name { get { return name; } set { name = "Aftermath"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Trigger; } }
            public string effect
            {
                get { return effect; }
                set
                {
                    effect = "When the Pokémon is reduced to 0 HP or less, they create a 5-meter Burst. Everything in the Burst loses 1/4 of their max HP." +
                        "Do not apply weakness or resistance. Do not apply stats. Does not activate if a Pokémon with the Damp ability is within the radius.";
                }
            }
        }

        private class AirLock
        {
            public string name { get { return name; } set { name = "Air Lock"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Cast_Hourly; } }
            public Keyword keyword { get { return keyword; } set { keyword = Keyword.Sustain; } }
            public string effect { get { return effect; } set { effect = "The weather is set to normal as long as the Pokémon with Air Lock wants it to remain that way."; } }
        }

        private class Analytic
        {
            public string name { get { return name; } set { name = "Analytic"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Cast_Hourly; } }
            public string effect
            {
                get { return effect; }
                set
                {
                    effect = "For the next 5 rounds, if the user's turn comes immediately after any of its target's, in the queue, the user deals +1 STAB on" +
" Moves with Damage Dice Rolles, ignoring the Type of Move used.";
                }
            }
        }

        private class AngerPoint
        {
            public string name { get { return name; } set { name = "Anger Point"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Trigger; } }
            public string effect { get { return effect; } set { effect = "When the Pokémon recieves a Critical Hit, raise their Attack 6 Combat Stages."; } }
        }

        private class Anticipation
        {
            public string name { get { return name; } set { name = "Anticipation"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Cast_Hourly; } }
            public string effect
            {
                get { return effect; }
                set
                {
                    effect = "During an encounter you may target a Pokémon. Roll 1d20; on roll, the target reveals if they have any Moves that are " +
"Super-Effective against the Pokémon with Anticipation; on 10 or lower, the target reveals up to 2 moves that are Super-Effective against the Pokémon with Anticipation; " +
"on 11 or better, the target reveals up to 3 moves that are Super-Effective against the Pokémon with Anticipation; on 16 " +
"or better, the target reveals up to 5 moves that are Super-Effective against the Pokémon with Anticipation and all of those Moves must roll +1 during Accuracy Check to hit the" +
"Pokémon with Anticipation.";
                }
            }
        }

        private class ArenaTrap
        {
            public string name { get { return name; } set { name = "Arena Trap"; } }
            public Activation activation { get { return activation; } set { activation = Activation.Cast_Daily; } }
            public string effect
            {
                get { return effect; }
                set
                {
                    effect = "A large wall of sand, 10-meters high surrounds the encounter. The diameter of the Arena Trap must be at least 10-meters but " +
"cannot be greater than 40-meters. There must be sufficient ground around to manipulate or the Ability cannot be used. The walls are constantly shifting making it impossible to " +
"climb. If a section of the wall is destroyed, it immediately restors itself. If the caster is felled or returned to a Poke Ball, the Arena Trap falls. The trapped Pokémon may " +
"not switch out or flee. The Arena Trap disappears when the target is felled.";
                }
            }
        }

        //        // B

        //        private class BadDreams
        //        {
        //            public string name { get { return name; } set { name = ; } }
        //            public Activation activation { get { return activation; } set { activation = ; } }
        //            public string effect { get { return effect; } set { effect = ; } }
        //        }

        //        private class BattleArmor
        //        {
        //            public string name { get { return name; } set { name = ; } }
        //            public Activation activation { get { return activation; } set { activation = ; } }
        //            public string effect { get { return effect; } set { effect = ; } }
        //        }

        //        private class BigPecks
        //        {
        //            public string name { get { return name; } set { name = ; } }
        //            public Activation activation { get { return activation; } set { activation = ; } }
        //            public string effect { get { return effect; } set { effect = ; } }
        //        }

        //        private class Blaze
        //        {
        //            public string name { get { return name; } set { name = ; } }
        //            public Activation activation { get { return activation; } set { activation = ; } }
        //            public string effect { get { return effect; } set { effect = ; } }
        //        }

        //        // C

        //        private class Chlorophyll
        //        {
        //            public string name { get { return name; } set { name = ; } }
        //            public Activation activation { get { return activation; } set { activation = ; } }
        //            public string effect { get { return effect; } set { effect = ; } }
        //        }
    }

    public enum Activation
    {
        Static, Cast_Hourly, Cast_Daily, Cast_Weekly, Trigger
    }

    public enum Keyword
    {
        Immune, // Abilities with the keyword Immune cannot be affected by a certain status effect. This is described per Move. Immuve Abilities are usually Constant.
        LastChance, // Abilities with the keyword Last Chance trigger when the Pokémon's HP has been lowered to 1/3 of thier max HP or less. When activated, one elemental Type, defined per Ability,
                    // receives a boost for Moves performed by the Pokémon with the Last Chance Ability. All Moves that are the Type defined in the Ability receive an additional STAB when dealing damage (If a 
                    // Pokémon's STAB is 4, the attack with deal 4 STAB + 4 more for the Last Chance Ability).
        Pickup, // The Ability with the Keyword Pickup is Pickup. When Pickup is used, you might find an item on the ground. The GM decides what the item is; the roll determines what kind of items it is.
                // Roll                          Item Type                                 Other
                // 1-5                           None                                      You find nothing
                // 6-8                           Battle Enhancers                          One X Attack, or X Defense, Etc.
                // 9-10                          Berries                                   Any Random Berry
                // 11-12                         Poke Ball                                 Any Random Poke Ball
                // 13-16                         Status/Healing                            Any Random Status healing item or HP healing item
                // 17                            Evolutionary Stones                       Any Random Evolutionary Stone
                // 18                            Performance Enhancers                     Any Random Vitamin
                // 19                            Hold Item                                 Any Random Hold Item
                // 20                            TM                                        Any Random TM
        Sustain // Abilities with the keyword Sustain have their effects last as long as the user wants them to. Usually the Pokémon must remain out to Sustain the Ability. The requirements of 
                // Sustaining an effect, if any, are defined per Ability.
    }
}


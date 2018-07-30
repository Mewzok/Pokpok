using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokpok
{
    public enum kantoBadges
    {
        BoulderBadge, CascadeBadge, ThunderBadge, RainbowBadge, SoulBadge, MarshBadge, VolcanoBadge, EarthBadge
    };

    enum johtoBadges
    {
        ZephyrBadge, HiveBadge, PlainBadge, FogBadge, StormBadge, MineralBadge, GlacierBadge, RisingBadge
    }

    enum hoennBadges
    {
        StoneBadge, KnuckleBadge, DynamoBadge, HeatBadge, BalanceBadge, FeatherBadge, MindBadge, RainBadge
    }

    enum sinnohBadges
    {
        CoalBadge, ForestBadge, CobbleBadge, FenBadge, RelicBadge, MineBadge, IcicleBadge, BeaconBadge
    }

    enum unovaBadges
    {
        BasicBadge, ToxicBadge, InsectBadge, BoltBadge, QuakeBadge, JetBadge, LegendBadge, WaveBadge
    }

    enum kalosBadges
    {
        BugBadge, CliffBadge, RumbleBadge, PlantBadge, VoltageBadge, FairyBadge, PsychicBadge, IcebergBadge
    }

    public class NumOfBadges
    {
        int numOfBadges;
        public void setNumOfBadges(trainer t)
        {
            numOfBadges = t.KBadges.Capacity + t.JBadges.Capacity + t.HBadges.Capacity + t.SBadges.Capacity + t.UBadges.Capacity + t.KLBadges.Capacity;
        }

        public int getNumOfBadges()
        {
            return numOfBadges; 
        }


    }
}



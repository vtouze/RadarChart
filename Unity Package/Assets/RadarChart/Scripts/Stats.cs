using System;
using UnityEngine;

public class Stats {

    public event EventHandler OnStatsChanged;

    public static int STAT_MIN = 0;
    public static int STAT_MAX = 20;

    public enum Type {
        Attack,
        Defence,
        Speed,
        Mana,
        Health,
        Power,
        Agility,
        Luck,
        Intelligence
    }


    private SingleStat attackStat;
    private SingleStat defenceStat;
    private SingleStat speedStat;
    private SingleStat manaStat;
    private SingleStat healthStat;
    private SingleStat powerStat;
    private SingleStat agilityStat;
    private SingleStat luckStat;
    private SingleStat intelligenceStat;

    public Stats(int attackStatAmount, int defenceStatAmount, int speedStatAmount, int manaStatAmount, int healthStatAmount, int powerStatAmount, int agilityStatAmount, int luckStatAmount, int intelligenceStatAmount) {
        attackStat = new SingleStat(attackStatAmount);
        defenceStat = new SingleStat(defenceStatAmount);
        speedStat = new SingleStat(speedStatAmount);
        manaStat = new SingleStat(manaStatAmount);
        healthStat = new SingleStat(healthStatAmount);
        powerStat = new SingleStat(powerStatAmount);
        agilityStat = new SingleStat(agilityStatAmount);
        luckStat = new SingleStat(luckStatAmount);
        intelligenceStat = new SingleStat(intelligenceStatAmount);
}



    private SingleStat GetSingleStat(Type statType) {
        switch (statType) {
        default:
        case Type.Attack:       return attackStat;
        case Type.Defence:      return defenceStat;
        case Type.Speed:        return speedStat;
        case Type.Mana:         return manaStat;
        case Type.Health:       return healthStat;
        case Type.Power:        return powerStat;
        case Type.Agility:      return agilityStat;
        case Type.Luck:         return luckStat;
        case Type.Intelligence: return intelligenceStat;
        }
    }
    
    public void SetStatAmount(Type statType, int statAmount) {
        GetSingleStat(statType).SetStatAmount(statAmount);
        if (OnStatsChanged != null) OnStatsChanged(this, EventArgs.Empty);
    }

    public void IncreaseStatAmount(Type statType) {
        SetStatAmount(statType, GetStatAmount(statType) + 1);
    }

    public void DecreaseStatAmount(Type statType) {
        SetStatAmount(statType, GetStatAmount(statType) - 1);
    }

    public int GetStatAmount(Type statType) {
        return GetSingleStat(statType).GetStatAmount();
    }

    public float GetStatAmountNormalized(Type statType) {
        return GetSingleStat(statType).GetStatAmountNormalized();
    }

    private class SingleStat {

        private int stat;

        public SingleStat(int statAmount) {
            SetStatAmount(statAmount);
        }

        public void SetStatAmount(int statAmount) {
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
        }

        public int GetStatAmount() {
            return stat;
        }

        public float GetStatAmountNormalized() {
            return (float)stat / STAT_MAX;
        }
    }
}

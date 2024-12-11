using UnityEngine;
using CodeMonkey;

public class Testing : MonoBehaviour {

    [SerializeField] private UI_StatsRadarChart uiStatsRadarChart;
    [SerializeField] private UI_TestStatsRadarChart uiTestStatsRadarChart;

    private void Start() {
        Stats stats = new Stats(7, 7, 7, 7, 7, 7, 7, 7, 7);

        uiStatsRadarChart.SetStats(stats);
        uiTestStatsRadarChart.SetStats(stats);

        
        CMDebug.ButtonUI(new Vector2(100, +20), "ATK++", () => stats.IncreaseStatAmount(Stats.Type.Attack));
        CMDebug.ButtonUI(new Vector2(100, -20), "ATK--", () => stats.DecreaseStatAmount(Stats.Type.Attack));
        
        CMDebug.ButtonUI(new Vector2(180, +20), "DEF++", () => stats.IncreaseStatAmount(Stats.Type.Defence));
        CMDebug.ButtonUI(new Vector2(180, -20), "DEF--", () => stats.DecreaseStatAmount(Stats.Type.Defence));
        
        CMDebug.ButtonUI(new Vector2(260, +20), "SPD++", () => stats.IncreaseStatAmount(Stats.Type.Speed));
        CMDebug.ButtonUI(new Vector2(260, -20), "SPD--", () => stats.DecreaseStatAmount(Stats.Type.Speed));
        
        CMDebug.ButtonUI(new Vector2(340, +20), "MAN++", () => stats.IncreaseStatAmount(Stats.Type.Mana));
        CMDebug.ButtonUI(new Vector2(340, -20), "MAN--", () => stats.DecreaseStatAmount(Stats.Type.Mana));
        
        CMDebug.ButtonUI(new Vector2(420, +20), "HEL++", () => stats.IncreaseStatAmount(Stats.Type.Health));
        CMDebug.ButtonUI(new Vector2(420, -20), "HEL--", () => stats.DecreaseStatAmount(Stats.Type.Health));
        
        CMDebug.ButtonUI(new Vector2(420, +20), "POW++", () => stats.IncreaseStatAmount(Stats.Type.Power));
        CMDebug.ButtonUI(new Vector2(420, -20), "POW--", () => stats.DecreaseStatAmount(Stats.Type.Power));

        CMDebug.ButtonUI(new Vector2(420, +20), "AGL++", () => stats.IncreaseStatAmount(Stats.Type.Agility));
        CMDebug.ButtonUI(new Vector2(420, -20), "AGL--", () => stats.DecreaseStatAmount(Stats.Type.Agility));

        CMDebug.ButtonUI(new Vector2(420, +20), "LCK++", () => stats.IncreaseStatAmount(Stats.Type.Luck));
        CMDebug.ButtonUI(new Vector2(420, -20), "LCK--", () => stats.DecreaseStatAmount(Stats.Type.Luck));

        CMDebug.ButtonUI(new Vector2(420, +20), "INT++", () => stats.IncreaseStatAmount(Stats.Type.Intelligence));
        CMDebug.ButtonUI(new Vector2(420, -20), "INT--", () => stats.DecreaseStatAmount(Stats.Type.Intelligence));
    }
}
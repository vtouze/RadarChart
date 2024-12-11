using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_TestStatsRadarChart : MonoBehaviour {

    [SerializeField] private Material radarMaterial;
    private Color baseMaterialColor;
    private Stats stats;

    public void SetStats(Stats stats) {
        this.stats = stats;

        transform.Find("attack").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Attack);
        transform.Find("attack").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Attack);

        transform.Find("defence").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Defence);
        transform.Find("defence").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Defence);

        transform.Find("speed").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Speed);
        transform.Find("speed").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Speed);

        transform.Find("mana").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Mana);
        transform.Find("mana").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Mana);

        transform.Find("health").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Health);
        transform.Find("health").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Health);

        transform.Find("power").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Power);
        transform.Find("power").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Power);

        transform.Find("agility").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Agility);
        transform.Find("agility").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Agility);

        transform.Find("luck").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Luck);
        transform.Find("luck").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Luck);

        transform.Find("intelligence").Find("incBtn").GetComponent<Button_UI>().ClickFunc = () => stats.IncreaseStatAmount(Stats.Type.Intelligence);
        transform.Find("intelligence").Find("decBtn").GetComponent<Button_UI>().ClickFunc = () => stats.DecreaseStatAmount(Stats.Type.Intelligence);


        // Randomize all Stats
        transform.Find("randomBtn").GetComponent<Button_UI>().ClickFunc = () => {
            stats.SetStatAmount(Stats.Type.Attack, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Defence, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Speed, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Mana, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Health, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Power, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Agility, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Luck, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
            stats.SetStatAmount(Stats.Type.Intelligence, Random.Range(Stats.STAT_MIN, Stats.STAT_MAX));
        };

        // Animate Stats
        bool anim = false;
        FunctionPeriodic.Create(() => {
            if (anim) {
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Attack); else stats.DecreaseStatAmount(Stats.Type.Attack);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Defence); else stats.DecreaseStatAmount(Stats.Type.Defence);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Speed); else stats.DecreaseStatAmount(Stats.Type.Speed);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Mana); else stats.DecreaseStatAmount(Stats.Type.Mana);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Health); else stats.DecreaseStatAmount(Stats.Type.Health);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Power); else stats.DecreaseStatAmount(Stats.Type.Power);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Agility); else stats.DecreaseStatAmount(Stats.Type.Agility);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Luck); else stats.DecreaseStatAmount(Stats.Type.Luck);
                if (Random.Range(0, 100) < 50) stats.IncreaseStatAmount(Stats.Type.Intelligence); else stats.DecreaseStatAmount(Stats.Type.Intelligence);
            }
        }, .1f);

        transform.Find("animBtn").GetComponent<Button_UI>().ClickFunc = () => {
            anim = !anim;
            transform.Find("animBtn").Find("text").GetComponent<Text>().text = "ANIM: " + anim.ToString().ToUpper();
        };

        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsText();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e) {
        UpdateStatsText();
    }

    private void UpdateStatsText() {
        transform.Find("text").GetComponent<Text>().text =
            "ATTACK: " + stats.GetStatAmount(Stats.Type.Attack) + "\n" +
            "DEFENCE: " + stats.GetStatAmount(Stats.Type.Defence) + "\n" +
            "SPEED: " + stats.GetStatAmount(Stats.Type.Speed) + "\n" +
            "MANA: " + stats.GetStatAmount(Stats.Type.Mana) + "\n" +
            "HEALTH: " + stats.GetStatAmount(Stats.Type.Health) + "\n" +
            "POWER: " + stats.GetStatAmount(Stats.Type.Power) + "\n" +
            "AGILITY: " + stats.GetStatAmount(Stats.Type.Agility) + "\n" +
            "LUCK: " + stats.GetStatAmount(Stats.Type.Luck) + "\n" +
            "INT: " + stats.GetStatAmount(Stats.Type.Intelligence);

    }

}

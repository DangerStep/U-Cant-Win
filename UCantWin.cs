using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using UCantWin;

[assembly: MelonInfo(typeof(UCantWin.UCantWin), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace UCantWin;

public class UCantWin : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<UCantWin>("UCantWin loaded!");
    }

    public class TryMe : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => BaseRounds.Count;
        public override string DisplayName => "I Bet You Can't Win";
        public override string Icon => VanillaSprites.DartpointIcon;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {
            foreach (BloonGroupModel? group in roundModel.groups)
            {
                Il2CppAssets.Scripts.Models.Bloons.BloonModel bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isGrow = true, out string? regrowBloon))
                {
                    group.bloon = regrowBloon;
                }
            }
            foreach (BloonGroupModel? group in roundModel.groups)
            {
                Il2CppAssets.Scripts.Models.Bloons.BloonModel bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isCamo = true, out string? camoBloon))
                {
                    group.bloon = camoBloon;
                }
            }
            foreach (BloonGroupModel? group in roundModel.groups)
            {
                Il2CppAssets.Scripts.Models.Bloons.BloonModel bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isFortified = true, out string? fortifiedBloon))
                {
                    group.bloon = fortifiedBloon;
                }
            }
            foreach (BloonGroupModel? group in roundModel.groups)
            {
                Il2CppAssets.Scripts.Models.Bloons.BloonModel bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isMoab = true, out string? moabBloon))
                {
                    group.bloon = bloonType.BAD;
                }
            }
        }
    }

    public class BloonDeadGameMode : ModGameMode
    {
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.Impoppable;

        public override string DisplayName => "I Bet You Can't Win";

        public override string Icon => VanillaSprites.BADIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<TryMe>();
            gameModeModel.SetAllCashMultiplier(1);
            gameModeModel.SetStartingRound(30);
            gameModeModel.SetEndingRound(200);
            gameModeModel.SetMaxHealth(1);
            gameModeModel.SetReversed(true);
            gameModeModel.SetStartingHealth(1);
            gameModeModel.SetStartingCash(500);
            gameModeModel.SetPowersEnabled(false);
        }
    }
}

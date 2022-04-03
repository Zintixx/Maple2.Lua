﻿using LuaGenerator;

namespace Maple2.Lua; 

public partial class Lua {
    #region Stats
    [GlobalFunction(Name = "calc_msiR")]
    public partial float CalcMsiRate(long a0); // int a1 in IDA (ignored)
    
    [GlobalFunction(Name = "calc_rmsiR")]
    public partial float CalcRmsiRate(long a0);
    
    [GlobalFunction(Name = "calc_jmiR")]
    public partial float CalcJmiRate(long a0 = 0);
    
    /// <param name="rate">The additional rate over 100%. This value is divided by 1000</param>
    /// <param name="mode">If mode == 14, the cap is raised to 500%</param>
    /// <returns>
    /// CritDamage is normally capped at 2.5 (250%), if mode == 14, the is raised to 5.0 (500%)
    /// </returns>
    [GlobalFunction(Name = "calc_cad")]
    public partial float CalcCritDamage(float rate, int mode = 0);
    
    /// <param name="rate">The attack speed. This value is divided by 100</param>
    /// <param name="multiplier">Multiply the final result, not affected by the cap</param>
    /// <param name="mode">If mode == 14, the cap is raised to 300%</param>
    /// <returns>
    /// AttackSpeed is normally capped at 1.5 (150%), if mode == 14, the is raised to 3.0 (300%)
    /// </returns>
    [GlobalFunction(Name = "calc_pc_asiR")]
    public partial float CalcPlayerAttackSpeed(long rate, float multiplier, int mode = 0);
    
    /// <param name="rate">The attack speed. This value is divided by 100</param>
    /// <param name="multiplier">Multiply the final result</param>
    [GlobalFunction(Name = "calc_npc_asiR")]
    public partial float CalcNpcAttackSpeed(long rate, float multiplier);

    [GlobalFunction(Name = "calc_npc_cap")]
    public partial float CalcNpcCritRate(long a0, long a1, long a2);
    
    /// <param name="mode">If mode == 14, the cap is raised to 90%</param>
    /// <returns>
    /// CritRate is normally capped at 0.4 (40%), if mode == 14, the is raised to 0.9 (90%)
    /// </returns>
    [GlobalFunction(Name = "calc_pc_cap")]
    public partial float CalcPlayerCritRate(int a0, long a1, long a2, long a3, long a4, float a5, int mode = 0);
    
    [GlobalFunction(Name = "calc_pc_damage")]
    public partial long CalcPlayerDamage(long a0, long a1, long a2, float a3, float cap);
    
    [GlobalFunction(Name = "cale_pc_OffenseScore")]
    public partial long CalcPlayerOffenseScore(
        int jobCode, int a1, int a2, int a3, int weaponAttack, int bonusAttack, int physicalAttack, int magicalAttack,
        float piercing, float physicalPiercing, float magicalPiercing, int accuracy, int criticalRate, 
        float criticalDamage, float meleeDamage, float rangeDamage, float iceDamage, float fireDamage, float darkDamage,
        float holyDamage, float poisonDamage, float electricDamage, float bossDamage, float totalDamage, float a24,
        float attackSpeed, float cooldownReduce, int a27, int weaponGrade, int petBonusAttack, float a30, float a31);
    
    [GlobalFunction(Name = "cale_pc_DefenseScore")]
    public partial long CalcPlayerDefenseScore(
        int jobCode, int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10, int a11, int a12,
        int a13, int a14, int a15, int a16, int a17, int a18, int a19);
    #endregion
    
    #region Black Market
    // a3 = option_diff[3] related...
    [GlobalFunction(Name = "calc_blackMarketBuyFeeCost")]
    public partial long CalcBlackMarketBuyFeeCost(long a0, int grade, ushort levelLimit, int a3);
    
    [GlobalFunction(Name = "calc_blackMarketCostRate")]
    public partial float CalcBlackMarketCostRate(int a0 = 1);
    
    [GlobalFunction(Name = "calc_blackMarketRegisterDeposit")]
    public partial long CalcBlackMarketRegisterDeposit(long a0);
    
    [GlobalFunction(Name = "calc_blackMarketRegisterDepositPercent")]
    public partial float CalcBlackMarketRegisterDepositPercent();
    
    [GlobalFunction(Name = "calc_blackMarketRegisterDepositMax")]
    public partial long CalcBlackMarketRegisterDepositMax();
    #endregion
    
    [GlobalFunction(Name = "calcResolvePaneltyPrice")]
    public partial int CalcResolvePenaltyPrice(ushort level, int a1, int zero_or_one);
    
    [GlobalFunction(Name = "calcKillCountBonusExpRate")]
    public partial float CalcKillCountBonusExpRate(int killCount);
    
    [GlobalFunction(Name = "calcKillCountGrade")]
    public partial int CalcKillCountGrade(int killCount);
    
    [GlobalFunction(Name = "calcKillCountMsg")]
    public partial string CalcKillCountMsg(int killCount);
    
    [GlobalFunction(Name = "calcKillCount")]
    public partial int CalcKillCount(ushort npcLevel, ushort pcLevel, int timeElapsed, int killCount); // a2 is absolute value from IDA?
    
    [GlobalFunction(Name = "calcSendMailFee")]
    public partial long CalcSendMailFee(long a0, long a1, long a2, long a3, long a4, long a5, long a6);
    
    [GlobalFunction(Name = "calcNpcSpawnWeight")]
    public partial int CalcNpcSpawnWeight(int a0, int a1, int a2, int a3);
    
    [GlobalFunction(Name = "calcTaxiCharge")]
    public partial int CalcTaxiCharge(int mapCount, ushort level);
    
    [GlobalFunction(Name = "calcAirTaxiCharge")]
    public partial int CalcAirTaxiCharge(ushort level);
    
    /// <param name="level">player level</param>
    /// <param name="dailyCount">count of revivals today: 1,2,3,...</param>
    [GlobalFunction(Name = "calcRevivalMerat")]
    public partial int CalcRevivalMeret(ushort level, int dailyCount);
    
    /// <param name="level">player level</param>
    /// <param name="dailyRemain">remaining revivals for the day</param>
    /// <param name="dailyCount">count of revivals today: 1,2,3,...</param>
    [GlobalFunction(Name = "calcRevivalMeso")]
    public partial int CalcRevivalMeso(ushort level, int dailyRemain, int dailyCount);

    [GlobalFunction(Name = "calcManufactureCompleteByMerat")]
    public partial int CalcManufactureCompleteByMeret(int a0);
    
    [GlobalFunction(Name = "calcGetExtendCapacity")]
    public partial int CalcGetExtendCapacity(int a0);
    
    [GlobalFunction(Name = "calcGetExtendCapacityPrice")]
    public partial long CalcGetExtendCapacityPrice(int a0);
    
    [GlobalFunction(Name = "calcGuildFundMax")]
    public partial int CalcGuildFundMax(int a0);
    
    [GlobalFunction(Name = "calcGuildSkillCost")]
    public partial int CalcGuildSkillCost(int a0, int a1, int a2);
    
    // Private
    // isItemRemakeArmor:       (int) -> bool
    // isItemRemakeWeapon:      (int) -> bool
    // isItemRemakeAccessory:   (int) -> bool
    
    // a2 = pet related
    /// <returns>
    /// string, int: Crystal tag, Crystal count
    /// string, int: CrystalChip tag, CrystalChip count
    /// string, int: Metacell tag, Metacell count
    /// </returns>
    [GlobalFunction(Name = "calcGetPetRemakeIngredient")]
    public partial (string, int, string, int, string, int) CalcGetPetRemakeIngredient(int timesChanged, int grade, int a2);
    
    /// <returns>
    /// string, int: CrystalChip tag, CrystalChip count
    /// </returns>
    [GlobalFunction(Name = "calcGetGemStonePutOffPrice")]
    public partial (string, int) CalcGetGemStonePutOffPrice(int grade, ushort level, int skinType);
    
    [GlobalFunction(Name = "calcMeratSkinItemBreakReward")]
    public partial (string, int, int?, int?, string?) CalcMeretSkinItemBreakReward(ushort levelLimit, int grade, int a2, int skinType);
    
    [GlobalFunction(Name = "calcMeratSkinItemBreakRefundPercent")]
    public partial float CalcMeretSkinItemBreakRefundPercent();

    // a3 = socket related (field_18)
    [GlobalFunction(Name = "calcItemSocketUnlockIngredient")]
    public partial(int, string, int) CalcItemSocketUnlockIngredient(int type, int grade, ushort levelLimit, int a3, int skinType);
    
    // return int, [string, int]
    [GlobalFunction(Name = "calcItemSocketTransferPrice")]
    public partial (int, string?, int?) CalcItemSocketTransferPrice(int gemLevel, int skinType);
    
    [GlobalFunction(Name = "calcItemSocketMaxCount")]
    public partial int CalcItemSocketMaxCount(int type, int grade, ushort levelLimit, int skinType);
    
    [GlobalFunction(Name = "calcGatheringReceipeRewardItemCount")]
    public partial long CalcGatheringRecipeRewardItemCount(int a0, int a1, int a2);
    
    [GlobalFunction(Name = "calcCraftReceipeRequireItemCount")]
    public partial long CalcCraftRecipeRequireItemCount(int a0, int a1, int a2);
    
    // a0 = X+100 or X+104
    // a1 = X+100
    // a2 = X+104 or X+100
    // a3 = 1
    [GlobalFunction(Name = "calcGatheringObjectgSuccessProp")]
    public partial float CalcGatheringObjectSuccessRate(int a0, int a1, int a2, int a3 = 1);
    
    // a0 = X+100 unknown
    // a1 = X+104 unknown
    [GlobalFunction(Name = "calcGatheringObjectgMaxCount")]
    public partial long CalcGatheringObjectMaxCount(int a0, int a1);
    
    [GlobalFunction(Name = "calcGatheringActionCount")]
    public partial long CalcGatheringActionCount(float a0, int a1, int a2, int a3, int a4);
    
    // a2 = option_diff[3] related...
    [GlobalFunction(Name = "calcEnchantExpGainExp")]
    public partial int CalcEnchantExpGainExp(ushort levelLimit, int grade, int a2, int type);
    
    // a2 = option_diff[3] related...
    [GlobalFunction(Name = "calcEnchantExpGainExpNew")]
    public partial int CalcEnchantExpGainExpNew(ushort levelLimit, int grade, int a2, int type);
    
    // a3 = option_diff[3] related...
    [GlobalFunction(Name = "calcItemLevel")]
    public partial (int, int) CalcItemLevel(float gearScore, int grade, int type, int a3, int levelLimit);
    
    [GlobalFunction(Name = "calcOHItemAdditionalLevel")]
    public partial (int, int) CalcOHItemAdditionalLevel(int a0, int a1, int a2, int a3);
    
    [GlobalFunction(Name = "calcUnlimitedEnchantItemLevel")]
    public partial int CalcUnlimitedEnchantItemLevel(int a0, int maxGrade, int type);
    
    [GlobalFunction(Name = "calcLapenshardLevel")]
    public partial ushort CalcLapenshardLevel(ushort level1, ushort level2, ushort level3);
    
    [GlobalFunction(Name = "calc_TamingPetRank")]
    public partial int CalcTamingPetRank(ushort petLevel);
    
    [GlobalFunction(Name = "calcItemMergeRevertMeso")]
    public partial int CalcItemMergeRevertMeso(int grade, int type);
    
    [GlobalFunction(Name = "calcItemMergeMaterialCount")]
    public partial int CalcItemMergeMaterialCount(int grade, int type);
    
    [GlobalFunction(Name = "calcItemMergeRequireMeso")]
    public partial int CalcItemMergeRequireMeso(int grade, int type);
    
    // a0 = X+104 (rank?)
    // a1 = X+100 related
    // a2 = X+408+44 or X+544+44
    // a3 = X+100
    [GlobalFunction(Name = "calcQuestRewardFamePoint")]
    public partial int CalcQuestRewardFamePoint(int rank, int a1, int a2, int a3);
    
    // a0 = X+28
    // a1 = X+104 (rank?)
    // a2 = X+488 or X+624
    // a3 = X+100
    /// <param name="rank">0,1,2,3,4</param>
    [GlobalFunction(Name = "calcQuestRewardExpFactorRateByRank")]
    public partial float CalcQuestRewardExpFactorRateByRank(int a0, int rank, int a2, int a3);
    
    // a0 = X+100 unknown
    // a1 = X+104 (rank? 0=S,1=A,2=B,3=C,4=D)
    /// <param name="rank">0,1,2,3,4</param>
    [GlobalFunction(Name = "calcFameCompletionTicketCount")]
    public partial int CalcFameCompletionTicketCount(int a0, int rank);
    
    /// <remarks>unverifiable, not called by client. see: sub_65E530 for third value</remarks>
    [GlobalFunction(Name = "calc_blueprintCreateCost")]
    public partial (int, int) CalcBlueprintCreateCost();
    
    [GlobalFunction(Name = "calcRevivalPrice")]
    public partial int CalcRevivalPrice(ushort level);
    
    [GlobalFunction(Name = "calcAvailableSkillPoint")]
    public partial int CalcAvailableSkillPoint(ushort level);
    
    #region Survival
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalExp")]
    public partial int CalcSurvivalExp(int a0, int a1, int a2, int a3, float a4, float a5);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalCoin")]
    public partial (int, int, int) CalcSurvivalCoin(int a0, int a1, int a2, int a3);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalCharacterExp")]
    public partial int CalcSurvivalCharacterExp(int a0, int a1, int a2, int a3, int a4);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalAdventureFactor")]
    public partial float CalcSurvivalAdventureRate(int a0, int a1, int a2, int a3);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalObservingExp")]
    public partial int CalcSurvivalObservingExp(int a0, int a1);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalObservingCoin")]
    public partial (int, int, int) CalcSurvivalObservingCoin(int a0, int a1);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalObservingCharacterExp")]
    public partial int CalcSurvivalObservingCharacterExp(int a0, int a1, int a2);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalObservingAdventureFactor")]
    public partial float CalcSurvivalObservingAdventureRate(int a0, int a1);
    
    /// <remarks>unverifiable, not called by client</remarks>
    [GlobalFunction(Name = "calc_SurvivalMatchingInfo")]
    public partial (int, int) CalcSurvivalMatchingInfo(int a0, int a1);
    #endregion

    #region Pet
    /// <remarks>grade is used to lookup exp from exptable. see: sub_6DA110</remarks>
    [GlobalFunction(Name = "calc_petExp")]
    public partial long CalcPetExp(long exp, ushort levelLimit);
    
    [GlobalFunction(Name = "calc_petEnchantExp")]
    public partial (long, long) CalcPetEnchantExp(int grade, int petGrade, ushort petLevel, long petExp, int const1, int const2, ushort levelLimit);
    
    [GlobalFunction(Name = "calc_petEnchantBookCost")]
    public partial long CalcPetEnchantBookCost(int grade);
    
    [GlobalFunction(Name = "calc_petEnchantCost")]
    public partial long CalcPetEnchantCost(int grade, int petGrade, ushort petLevel, long petExp);
    
    [GlobalFunction(Name = "calc_petEvolutionCost")]
    public partial long CalcPetEvolutionCost(int grade);
    
    /// <remarks>grade offset by +1</remarks>
    [GlobalFunction(Name = "calc_petEvolutionResultLevel")]
    public partial ushort CalcPetEvolutionResultLevel(int grade, ushort levelLimit);
    #endregion
}

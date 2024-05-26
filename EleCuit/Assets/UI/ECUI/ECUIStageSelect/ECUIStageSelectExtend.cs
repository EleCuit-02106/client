// -----------------------------------
// このファイルは初回のみの自動生成スクリプトです
// 生成後は手動編集が可能です
// -----------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using du.dUI;

namespace EC.ECUI
{
    /// <summary>
    /// </summary>
    public sealed partial class ECUIStageSelect
    {
        #region field
        private MD.MasterSudokuStage CurrentStage { get; set; } = null;
        private int? CurrentIndex { get; set; } = null;
        #endregion

        #region mono
        private void Start()
        {
            Set(CreateEntity());
        }
        private Entity CreateEntity()
        {
            return new Entity
            {
                stageTemplate00Visible = IsOpened("sudoku.stage_1"),
                stageTemplate01Visible = IsOpened("sudoku.stage_2"),
                stageTemplate02Visible = IsOpened("sudoku.stage_3"),
                stageTemplate03Visible = IsOpened("sudoku.stage_4"),
                stageTemplate04Visible = IsOpened("sudoku.stage_5"),
                stageTemplate05Visible = IsOpened("sudoku.stage_6"),
                stageTemplate06Visible = IsOpened("sudoku.stage_7"),
                stageTemplate07Visible = IsOpened("sudoku.stage_8"),
                stageTitle00 = GetStageOrNull("sudoku.stage_1").Difficulty.ToString(),
                stageTitle01 = GetStageOrNull("sudoku.stage_2").Difficulty.ToString(),
                stageTitle02 = GetStageOrNull("sudoku.stage_3").Difficulty.ToString(),
                stageTitle03 = GetStageOrNull("sudoku.stage_4").Difficulty.ToString(),
                stageTitle04 = GetStageOrNull("sudoku.stage_5").Difficulty.ToString(),
                stageTitle05 = GetStageOrNull("sudoku.stage_6").Difficulty.ToString(),
                stageTitle06 = GetStageOrNull("sudoku.stage_7").Difficulty.ToString(),
                stageTitle07 = GetStageOrNull("sudoku.stage_8").Difficulty.ToString(),
                stageTitle = CurrentStage?.Label ?? "ステージを選択してください",
                difficultyValue = CurrentStage?.Difficulty.ToString() ?? "-",
                clearCountValue = "0",
                stageTemplate00 = () => { SelectStage(0); },
                stageTemplate01 = () => { SelectStage(1); },
                stageTemplate02 = () => { SelectStage(2); },
                stageTemplate03 = () => { SelectStage(3); },
                stageTemplate04 = () => { SelectStage(4); },
                stageTemplate05 = () => { SelectStage(5); },
                stageTemplate06 = () => { SelectStage(6); },
                stageTemplate07 = () => { SelectStage(7); },
                gameStartButton = ClearStageTemp,
            };
        }
        private void SelectStage(int index)
        {
            if (CurrentIndex == index)
            {
                return;
            }

            CurrentIndex = index;
            CurrentStage = MD.MasterSudokuStageRepository.Instance.GetOrNull(10000000 + index + 1);
            Set(CreateEntity());
        }
        private void ClearStageTemp()
        {
            if (CurrentIndex == null)
            {
                return;
            }

            du.Debug.LLog.Debug.Log($"clear stage {CurrentStage.Label}");
            Set(CreateEntity());
        }
        private MD.MasterSudokuStage GetStageOrNull(string stageLabel)
            => MD.MasterSudokuStageRepository.Instance.GetOrNull(stageLabel);
        private bool IsOpened(string stageLabel)
        {
            var period = MD.MasterPeriodRepository.Instance.GetOrNull(GetStageOrNull(stageLabel).Period);

            // 現在時刻を取得
            DateTime currentTime = DateTime.Now;

            // 現在時刻をUnixタイムに変換
            DateTimeOffset currentTimeOffset = new DateTimeOffset(currentTime);
            long currentUnixTime = currentTimeOffset.ToUnixTimeSeconds();

            // 現在のUnixタイムと比較対象のUnixタイムを比較
            if (currentUnixTime < period.OpenAt)
            {
                du.Debug.LLog.Debug.Log($"{stageLabel} is not open yet (now:{currentUnixTime} < open:{period.OpenAt})");
                return false;
            }
            if (0 < period.CloseAt && period.CloseAt < currentUnixTime)
            {
                du.Debug.LLog.Debug.Log($"{stageLabel} is closed already (close:{period.CloseAt} < now:{currentUnixTime})");
                return false;
            }
            du.Debug.LLog.Debug.Log($"{stageLabel} is open now! (now:{currentUnixTime})");
            return true;
        }
        #endregion
    }
}

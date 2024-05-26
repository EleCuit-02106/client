// -----------------------------------
// このファイルは初回のみの自動生成スクリプトです
// 生成後は手動編集が可能です
// -----------------------------------
using System;
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
                stageTitle00 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_1").Difficulty.ToString(),
                stageTitle01 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_2").Difficulty.ToString(),
                stageTitle02 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_3").Difficulty.ToString(),
                stageTitle03 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_4").Difficulty.ToString(),
                stageTitle04 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_5").Difficulty.ToString(),
                stageTitle05 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_6").Difficulty.ToString(),
                stageTitle06 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_7").Difficulty.ToString(),
                stageTitle07 = MD.MasterSudokuStageRepository.Instance.GetOrNull("sudoku.stage_8").Difficulty.ToString(),
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
        #endregion
    }
}

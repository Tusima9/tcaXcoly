using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Puzzle.Coordinator
{
    public class Coordinator : MonoBehaviour
    {
        private static List<CharacterBase> characters = new List<CharacterBase>();

        private static bool roundProgressing = false;

        private static bool skillUsedInCurrentRound = false;

        private static string skillUsed;

        private static bool dialogActive = false;

        private static int maxGame = 3;

        private static bool playerLost = false;

        private static int damage;

        public static void RegisterCharacter(CharacterBase character)
        {
            characters.Add(character);
        }

        public static bool RegisterSkillActivation()
        {
            return !roundProgressing && !skillUsedInCurrentRound;
        }

        public static void NotifyRoundStarted()
        {
            roundProgressing = true;
        }

        public static void NotifyRoundEnded(bool validRound)
        {
            bool ended = false;

            if (validRound)
            {
                bool roundDepleted = HealthBar.instance.PlayerLost();
                bool dead = UI.Canvas.Enemy.instance.Attack(skillUsed, EnemyHp);

                if (dead)
                {
                    Sound.SoundSystem.instance.PlayStageClear();

                    UI.Canvas.ClearText.instance.DisplayClearText();
                    UI.Canvas.ClearDialogueBox.instance.EndGame(StageManager.instance.GetGameUUID());

                    ended = true;
                }
                else if (roundDepleted)
                {
                    playerLost = true;
                    Sound.SoundSystem.instance.PlayStageFail();
                    UI.Canvas.LostDialogueBox.instance.EndGame();
                    ended = true;
                }
                else
                {
                    Sound.SoundSystem.instance.PlayTransition();
                }
            }
            if (!ended)
            {
                foreach (CharacterBase character in characters)
                {
                    character.ReactivateSkill();
                }
            }
            roundProgressing = false;
            skillUsedInCurrentRound = false;
        }

        public static void NotifyDialogActive()
        {
            dialogActive = true;
        }

        public static void NotifyDialogDeactive()
        {
            dialogActive = false;
        }

        public static void NotifyIncrementCombo()
        {
        }

        public static void NotifyEndGame()
        {
            UI.Canvas.Fader.instance.FadeOut();
        }

        public static void NotifyFadeOut()
        {
            if (!playerLost)
            {
                External.GameSelection.LoadButtonMaster.currentProgress = StageManager.gameIndex + 1;
            }
            if (External.GameSelection.LoadButtonMaster.currentProgress > maxGame)
            {
                SceneManager.LoadScene("Credits");
            }
            else
            {
                SceneManager.LoadScene("mainScene");
            }
            ResetStatics();
        }

        public static bool GetOrbMovable()
        {
            return !dialogActive;
        }

        public static List<CharacterBase> GetCharacters()
        {
            return characters;
        }

        public static void Reset()
        {
            characters.Clear();
            roundProgressing = false;
            skillUsedInCurrentRound = false;
            skillUsed = null;
            dialogActive = false;
            playerLost = false;
        }

        private static void ResetStatics()
        {
            Reset();
            TeamManager.Reset();
            StageManager.Reset();
        }
    }
}
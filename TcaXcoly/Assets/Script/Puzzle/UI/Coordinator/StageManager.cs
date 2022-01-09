using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Puzzle.Coordinator
{
    public class StageManager : MonoBehaviour
    {
        public static int gameIndex = 0;

        public static StageManager instance;

        private static int stageIndex = 0;

        private static int maxStage = 0;

        // Start is called before the first frame update
        private void Start()
        {
            instance = this;

            maxStage = Scripts.Data.Games.GetMaxStage(gameIndex);
            List<UI.Canvas.Character> characters = Coordinator.GetCharacters();
            Character.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));
            List<string> selectedCharacter = TeamManager.GetMembers();
            for (int i = 0; i < characters.Count; i++)
            {
                if (i < selectedCharacter.Count)
                {
                    characters[i].InitSprite(selectedCharacter[i]);
                    characters[i].skill = Scripts.Data.Characters.GetSkill(selectedCharacter[i]);
                }
                else
                {
                    characters[i].InitSprite(null);
                }
            }
            LoadStage();
        }

        public string getGameUUID()
        {
            return Scripts.Data.Games.GetUUID(gameIndex);
        }

        public bool NotifyNextStage()
        {
            stageIndex += 1;
            if (stageIndex < maxStage)
            {
                UI.Canvas.Enemy.instance.animationEvent.AnimationCompleted += LoadStagePre;
                UI.Canvas.Enemy.instance.FadeOut();

                if (stageIndex == maxStage - 1)
                {
                    Sound.SoundSystem.instance.PlayBossBGM();
                }
                return false;
            }
            else
            {
                UI.Canvas.Enemy.instance.FadeOut();
                return true;
            }
        }

        public static void Reset()
        {
            gameIndex = 0;
            instance = null;
            stageIndex = 0;
            maxStage = 0;
        }

        private void LoadStagePre(object sender, EventArgs e)
        {
            LoadStage();
        }

        private void LoadStageTransition()
        {
            UI.Canvas.StageText.instance.animationEvent.AnimationCompleted += LoadStagePost;
            UI.Canvas.StageText.instance.Transition(stageIndex, maxStage);
        }

        private void LoadStagePost(object sender, EventArgs e)
        {
            Scripts.Data.Stage stage = Scripts.Data.Games.GetStage(gameIndex, stageIndex);
            UI.Canvas.Enemy.instance.InitEnemy("Enemy/" + stage.EnemyID, stage.enemyHP, +stage.enemyAttack, +stage.enemyDefence, +stage.turnBeforeAttack);
            UI.Canvas.Enemy.instance.FadeIn();
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
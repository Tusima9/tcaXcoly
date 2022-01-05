using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Puzzle.Sound
{
    //sound in minigame
    public class SoundSystem : MonoBehaviour
    {
        public static SoundSystem instance;

        public AudioSource bgm; //background music

        public AudioSource bgmBoss; // boss background music

        public PieceDestructionSFX PieceDestructionTemplate; // template for the PieceDestructionSFX sound player

        public int StartingPitch = 1; //starting pitch for destruction sound

        public float incrementPitch = 0.1f; // incresement of pitch per combo

        public AudioSource pieceMouvement; //sound when moving piece

        public AudioSource skillReady; // sound when the kill is ready

        public AudioSource skillUse; //Sound when the skill is used

        public AudioSource PlayerHit; //sound when the player attack

        public AudioSource stageTransition; // sound when changing the stage

        public AudioSource stageClear; // sound when the stage is clear

        public AudioSource stageFailed; // sound when the stage is failed

        public AudioSource tap; // sound when you click on the screen

        public AudioSource tapBack; // sound when you get back

        public AudioSource tapError; // sound when their is an error

        public void Start()
        {
            instance = this;

            PieceDestructionTemplate.SetEternal();

            bgm.PlayDelayed(4);
        }

        public void PlayMovementSFX() // play movement sfx
        {
            pieceMouvement.Play();
        }

        public void PlaySkillReady() // play skill ready sfx
        {
            skillReady.Play();
        }

        public void PlaySkillUse() // play skill used sfx
        {
            skillUse.Play();
        }

        public void PlayTransition()// play sfx for transition and when player attack
        {
            PlayerHit.Play();
            stageTransition.PlayDelayed(1);//play transition 1 second later
        }

        public void PlayStageClear()// play the sfx for clear stage and pause the bgm
        {
            bgm.Pause();
            bgmBoss.Pause();
            stageClear.Play();
        }

        public void PlayStageFail()// play the sfx for failed stage and pause the bgm
        {
            bgm.Pause();
            bgmBoss.Pause();
            stageFailed.Play();
        }

        public void PlayTapSFX()// play the tap sfx
        {
            tap.Play();
        }

        public void PlayTapBackSFX()// play the tap back sfx
        {
            tapBack.Play();
        }

        public void PlayTapErrorSFX()// play the tap error sfx
        {
            tapError.Play();
        }

        public void PlayBossBGM()//pause the normal bgm and play the boss bgm
        {
            bgm.Pause();
            bgmBoss.PlayDelayed(3);
        }

        public void PlayMatchSFX(int match, float delay)
        {
            PieceDestructionSFX pdsfx = Instantiate(PieceDestructionTemplate);// clone template

            pdsfx.PlaySound(StartingPitch + incrementPitch * match, delay); // play sfx for certain pitch and delay on the cloned sound system
        }
    }
}
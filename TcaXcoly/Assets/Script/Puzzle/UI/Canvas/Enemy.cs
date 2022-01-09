using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Puzzle.UI.Canvas
{
    public class Enemy : MonoBehaviour
    {
        public static Enemy instance;

        public Text turnBeforeAttackText;  //text before the enemy attack

        public GenericAnimationCallBack animationEvent = new GenericAnimationCallBack(true);

        private SwitchableImage switchImage;

        private Animator animator;

        private int enemyHp;
        private int enemyAttack;
        private int enemyDefence;

        public int currentHealth;
        public HealthBar healthBar;

        public void Start()
        {
            instance = this;
            switchImage = GetComponent<SwitchableImage>();
            animator = GetComponent<Animator>();
        }

        public void InitEnemy(string spritePath, int maxHealth, int attack, int defence, int turnBeforeAttack)
        {
            enemyHp = maxHealth;
            enemyAttack = attack;
            enemyDefence = defence;

            switchImage.SwitchImage(spritePath);
            turnBeforeAttackText.transform.parent.gameObject.SetActive(true);
            turnBeforeAttackText.text = turnBeforeAttack.ToString();

            currentHealth = maxHealth;
            healthBar.SetMaxHeath(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            if (gameObject.name.Equals(" "))
            {
                Debug.Log("take damage");
                Debug.Log("health:" + currentHealth + "left");
                currentHealth -= damage;
                healthBar.SetHealth(currentHealth);
            }
        }

        public void FadeIn()
        {
            animator.SetBool("active", false);
        }

        public void FadeOut()
        {
            animator.SetBool("active", false);
        }

        public void OnFadeOutCompleted()
        {
            turnBeforeAttackText.transform.parent.gameObject.SetActive(false);
            animationEvent.OnAnimationCompleted(EventArgs.Empty);
        }
    }
}
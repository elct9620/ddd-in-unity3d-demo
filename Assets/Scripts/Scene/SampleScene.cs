using System.Collections;
using System.Collections.Generic;
using BattleSystem.Result;
using BattleSystem.UseCase;
using UI;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Timeline;

namespace Scene
{
    public class SampleScene : MonoBehaviour
    {
        public HealthPointUI playerHealthPoint;
        public HealthPointUI enemyHealthPoint;

        private int _battleID;
        private BattleUseCase _usecase;

        private float _deltaTime = 0;

        public void Attack()
        {
            AttackResult result = _usecase.Attack(_battleID, 10);
            UpdateHealthPoint(result);
        }

        public void Recovery()
        {
            RecoveryResult result = _usecase.Recovery(_battleID, 10);
            UpdateHealthPoint(result);
        }

        void Start()
        {
            _usecase = Game.Instance.BattleUseCase;

            BattleInitResult result = _usecase.Init();
            _battleID = result.id;
            UpdateHealthPoint(result);
        }

        void Update()
        {
            _deltaTime += Time.deltaTime;
            if (_deltaTime >= 1)
            {
                EnemyAttack();
                AutoRecovery();
                _deltaTime = 0;
            }
        }


        void EnemyAttack()
        {
            AttackResult result = _usecase.EnemyAction(_battleID);
            UpdateHealthPoint(result);
        }

        void AutoRecovery()
        {
            RecoveryResult result = _usecase.AutoRecovery(_battleID);
            UpdateHealthPoint(result);
        }

        void UpdateHealthPoint(AttackResult result)
        {
            playerHealthPoint.Refresh(result.playerHP, result.playerMaxHP);
            enemyHealthPoint.Refresh(result.enemyHP, result.enemyMaxHP);
        }

        void UpdateHealthPoint(RecoveryResult result)
        {
            playerHealthPoint.Refresh(result.playerHP, result.playerMaxHP);
            enemyHealthPoint.Refresh(result.enemyHP, result.enemyMaxHP);
        }

        void UpdateHealthPoint(BattleInitResult result)
        {
            playerHealthPoint.Refresh(result.playerHP, result.playerMaxHP);
            enemyHealthPoint.Refresh(result.enemyHP, result.enemyMaxHP);
        }
    }
}
using System;
using Battle.Action;
using UnityEngine;
using UnityEngine.UI;

namespace Attack.AllOutAttack.AllOutAttackAction
{
    public class AllOutAttackButtonListener : MonoBehaviour
    { 
        [SerializeField] private BattleDataProvider _battleDataProvider;
        [SerializeField] private PersonaAllOutAttack _allOutAttack;

        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(AllOutAttackAction);
        }

        private void AllOutAttackAction()
        {
            _allOutAttack.AttackAction(_battleDataProvider.GetActivePersona(),
                _battleDataProvider.GetAllShadows());
            this.gameObject.SetActive(false);
        }
    }
}

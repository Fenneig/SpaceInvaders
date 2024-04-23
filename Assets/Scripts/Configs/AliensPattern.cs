using System;
using System.Collections.Generic;
using SpaceInvaders.Components.Units;
using UnityEngine;

namespace SpaceInvaders.Configs
{
    [CreateAssetMenu(fileName = "Aliens Pattern", menuName = "Configs/Aliens Pattern")]
    public class AliensPattern : ScriptableObject
    {
        [SerializeField] private List<AliensStage> _stages;

        public List<AliensStage> Stages => _stages;
    }

    [Serializable]
    public struct AliensStage
    {
        public List<Alien> AlienRows;
        public int AliensInRow;
        public float MovementSpeed;
        public float AttacksPerSecond;
    }
}
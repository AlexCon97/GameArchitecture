using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeLogic.Dialogue_Manager
{
    [CreateAssetMenu(menuName = "Dialogue_Manager/Dialogue", fileName = "New_Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private DialogueTitle Title;
        [SerializeField] private List<DialogueReplica> Replicas;

        public DialogueTitle GetTitle => Title;
        public List<DialogueReplica> GetReplicas => Replicas;
    }
}
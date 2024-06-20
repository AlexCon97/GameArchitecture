using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrototypeLogic.Task_Manager;

namespace PrototypeLogic.Popup_Manager
{
    public class PopupTaskRow : MonoBehaviour
    {
        [SerializeField] private Image TaskImage;
        [SerializeField] private TextMeshProUGUI TaskName;

        public TaskTitle TaskTitle { get; set; }
        public void SetTaskIcon(Sprite icon) => TaskImage.sprite = icon;
        public void SetTaskName(string taskName) => TaskName.text = taskName;
    }
}
using System.Threading.Tasks;

namespace PrototypeLogic.Popup_Manager
{
    public interface IPopupHideBehavior
    {
        Task Hide(PopupBase popup);
    }
}
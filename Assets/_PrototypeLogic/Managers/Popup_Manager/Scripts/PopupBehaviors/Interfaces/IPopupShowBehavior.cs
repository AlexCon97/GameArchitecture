using System.Threading.Tasks;

namespace PrototypeLogic.Popup_Manager
{
    public interface IPopupShowBehavior
    {
       Task Show(PopupBase popup);
    }
}
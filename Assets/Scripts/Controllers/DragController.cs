using UnityEngine.EventSystems;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DragController : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta;
        }
    }
}

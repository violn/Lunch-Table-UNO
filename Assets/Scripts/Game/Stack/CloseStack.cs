using UnityEngine;
using UnityEngine.EventSystems;

public class CloseStack : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            StackHolder.UnDisplayStack();
        }
    }
}
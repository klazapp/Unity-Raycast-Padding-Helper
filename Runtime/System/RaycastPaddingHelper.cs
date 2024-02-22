using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace com.klazapp.utility
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class RaycastPaddingHelper : UIBehaviour
    {
#if UNITY_EDITOR
        #region Variables
        private static readonly float2 shadowOffset = new float2(1, -1);
        private static readonly Color shadowColor = new Color(0, 0, 0, 0.5f);
        private const float DOTTED_LINE_WIDTH = 15f;
        #endregion

        #region Lifecycle Flow
        private void OnDrawGizmos()
        {
            var image = GetComponent<Image>();
            var gui = GetComponent<RectTransform>();

            var rectInOwnSpace = gui.rect;
            var rectInParentSpace = rectInOwnSpace;
            var ownSpace = gui.transform;
          
            var parentSpace = ownSpace;
            if (ownSpace.parent != null)
            {
                parentSpace = ownSpace.parent;
                rectInParentSpace.x += ownSpace.localPosition.x;
                rectInParentSpace.y += ownSpace.localPosition.y;

                parentSpace.GetComponent<RectTransform>();
            }
            
            //Image.raycastPadding order of the Vector4 is:
            //X = Left
            //Y = Bottom
            //Z = Right
            //W = Top

            var paddingRect = new Rect(rectInParentSpace);
            paddingRect.xMin += image.raycastPadding.x;
            paddingRect.xMax -= image.raycastPadding.z;
            paddingRect.yMin += image.raycastPadding.y;
            paddingRect.yMax -= image.raycastPadding.w;

            //Uncomment to show only when rect tool is active
            //if (Tools.current == Tool.Rect)
            {
                //Set handle color
                Handles.color = Color.green;
                DrawRect(paddingRect, parentSpace, true);
            }
        }
        #endregion
        
        #region Modules
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DrawRect(Rect rect, Transform space, bool dotted)
        {
            float3 p0 = space.TransformPoint(new Vector2(rect.x, rect.y));
            float3 p1 = space.TransformPoint(new Vector2(rect.x, rect.yMax));
            float3 p2 = space.TransformPoint(new Vector2(rect.xMax, rect.yMax));
            float3 p3 = space.TransformPoint(new Vector2(rect.xMax, rect.y));
            
            if (!dotted)
            {
                Handles.DrawLine(p0, p1);
                Handles.DrawLine(p1, p2);
                Handles.DrawLine(p2, p3);
                Handles.DrawLine(p3, p0);
            }
            else
            {
                DrawDottedLineWithShadow(shadowColor, shadowOffset, p0, p1, DOTTED_LINE_WIDTH);
                DrawDottedLineWithShadow(shadowColor, shadowOffset, p1, p2, DOTTED_LINE_WIDTH);
                DrawDottedLineWithShadow(shadowColor, shadowOffset, p2, p3, DOTTED_LINE_WIDTH);
                DrawDottedLineWithShadow(shadowColor, shadowOffset, p3, p0, DOTTED_LINE_WIDTH);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DrawDottedLineWithShadow(Color shadowCol, Vector2 screenOffset, Vector3 p1, Vector3 p2, float screenSpaceSize)
        {
            var cam = Camera.current;
            if (!cam || Event.current.type != EventType.Repaint)
                return;

            var oldColor = Handles.color;

            shadowCol.a *= oldColor.a;
            Handles.color = shadowCol;
            Handles.DrawDottedLine(
                cam.ScreenToWorldPoint(cam.WorldToScreenPoint(p1) + (Vector3)screenOffset),
                cam.ScreenToWorldPoint(cam.WorldToScreenPoint(p2) + (Vector3)screenOffset), screenSpaceSize);

            Handles.color = oldColor;
            Handles.DrawDottedLine(p1, p2, screenSpaceSize);
        }
        #endregion
#endif
    }
}

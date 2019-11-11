using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using UnityEditor;
using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

[CustomNodeEditor(typeof(ActNode))]
public class ActNodeEditor : SimpleNodeEditor
{
    ActNode node;

    public Vector2 nodeposition;

    
    public override void OnHeaderGUI()
    {
        if (node == null)
            node = target as ActNode;

        GUILayout.Label(node.sourceAction.GetType().ToString(), NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
    }

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
        //nodeposition = NodeEditorWindow.current.lastMousePosition;

        if (node == null)
            node = target as ActNode;

        drawFilter(node.nodeInFilter);

        SirenixEditorGUI.BeginBox();
      
        SirenixEditorGUI.EndBox();
       
        drawFilter(node.nodeOutFilter);
    }

    
    
    public void resize(Rect rect)
    {
        while (GetWidth() - rect.width < 40)
        {
            resizeWidth(1);
            //yield return null;
            this.window.Repaint();
        }
    }

    
    
}

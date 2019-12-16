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
    public ActNode node;
    
    public override void OnHeaderGUI()
    {
        if (node == null)
            node = target as ActNode;

        if (node.sourceAction != null)
        {
            GUILayout.Label(node.sourceAction.GetType().ToString(), NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        }
        else
        {
            inspectStuff.Show();
            OdinEditorWindow.InspectObject(inspectStuff, node);
            //window.Repaint();
        }

        if (node == null)
            node = target as ActNode;

        if (node.nodeInFilter == null || node.nodeOutFilter==null)
        {
            node.initNode();
            window.Repaint();
        }

    }

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
        //nodeposition = NodeEditorWindow.current.lastMousePosition;

        if (node.nodeInFilter != null)
        {
            window.Repaint();
            drawFilter(node.nodeInFilter);
        }
        
        if (node.nodeOutFilter != null)
        {
            window.Repaint();
            drawFilter(node.nodeOutFilter);
        }
        
    }  
    
}

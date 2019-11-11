using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using XNode;
using System;
using Sirenix.OdinInspector;
using XNodeEditor;
using Sirenix.Utilities.Editor;

public enum PortOrientation
{
    In,
    Out
}

[NodeTint(250f, 250f, 250f, .2f)]
public class ActNode : CognitiveElementNode
{
  //  [ShowDrawerChain]
   // [ListDrawerSettings(OnEndListElementGUI = "AddPort", HideRemoveButton = true)]
    public List<mEntity> inFilter = new List<mEntity>();


    public List<mEntity> outFilter = new List<mEntity>();
   // [Output, HideInInspector] public int testPort;

  //  [OnValueChanged("updateFilter", true)]
    public NodeFilter nodeInFilter;
    //[OnValueChanged("")]
    public NodeFilter nodeOutFilter;

    //[HideInInspector]
    public MAction sourceAction;
    public Type actionType;

    bool reload = true;

  //  public Color color = new Color(200, 100, 200, 50);

    protected override void Init()
    {
        if(reload)
        {
            if (sourceAction != null)
            {
                if (nodeOutFilter != null)
                {
                    nodeOutFilter.Dispose();
                    nodeOutFilter = null;
                    nodeOutFilter = populateFilter(nodeOutFilter, sourceAction.outFilter, PortOrientation.Out);
                }
                if (nodeInFilter != null)
                {
                    nodeInFilter.Dispose();
                    nodeInFilter = null;
                    nodeInFilter = populateFilter(nodeInFilter, sourceAction.inFilter, PortOrientation.In);
                }
            }
        }
    }

    public void updateFilter()
    {
        Debug.Log("Change detected");
    }

    public void AddPort(int index)
    {
        //this.AddDynamicInput();
      //  NodeEditorGUILayout.AddPortField(this.GetPort("testPort"));
        //SirenixEditorGUI.
    }

}

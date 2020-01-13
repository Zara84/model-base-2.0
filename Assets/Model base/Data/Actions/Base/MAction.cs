using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEditor;
using Sirenix.Utilities.Editor;

public abstract class MAction : SerializedScriptableObject
{
    //  [OdinSerialize]
    [BoxGroup("In filter")]
    [OdinSerialize]
    [ListDrawerSettings( CustomRemoveElementFunction ="customRemove", CustomAddFunction ="addCustomEntity")]
   // [ListDrawerSettings(CustomAddFunction = "addCustomEntity")]
    public List<mEntity> inFilter = new List<mEntity>();
    [BoxGroup("In filter")]
    [Button("Add new entity to in filter")]
    private void addInEntity()
    {
        addEntity(inFilter, "InFilter");
    }

    [BoxGroup("Out filter")]
    [OdinSerialize]
    [ListDrawerSettings(CustomAddFunction = "addCustomEntity")]
    public List<mEntity> outFilter = new List<mEntity>();
    [BoxGroup("Out Filter")]
    [Button("Add new entity to out filter")]
    private void addOutEntity()
    {
        addEntity(outFilter, "OutFilter");
    }

    void addEntity(List<mEntity> list, string folderName)
    {
        //  EntityAdder.AddEntity(list, folderName);
        mEntity entity = CreateInstance<mEntity>();
        EditorGUIUtility.ShowObjectPicker<mEntity>(entity, false, "", 0);

        entity = (mEntity)EditorGUIUtility.GetObjectPickerObject();

        AssetDatabase.AddObjectToAsset(entity, this);
        AssetDatabase.SaveAssets();

        list.Add(entity);
    }

    public void addCustomEntity()
    {
        Debug.Log("custom add");
       /* if (SirenixEditorGUI.ToolbarButton(EditorIcons.Plus))
        {
            Debug.Log("custom add");
            EditorGUIUtility.ShowObjectPicker<mEntity>(null, false, "", 0);

            if(Event.current.commandName=="ObjectSelectorUpdated")
            {
                Debug.Log("finally");
            }
        }*/
    }

    public void customRemove(mEntity e)
    {
        Debug.Log(e.entityName);
    }
    
    public abstract bool  isDoable(MonoBehaviour owner);

    public abstract float distanceToGoal(MonoBehaviour owner, MGoal goal);

    public abstract void execute(MonoBehaviour owner);

    public abstract List<mEntity> getTargets(MonoBehaviour owner);

    public abstract bool canBeAppliedTo(MonoBehaviour owner, mEntity entity);


}

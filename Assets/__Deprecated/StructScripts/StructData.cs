using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using System;
using static Components;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using Sirenix.Utilities;
using System.Reflection;
using Sirenix.Serialization;

public interface IComponent
{
    
};


public struct Component: IComponent
{
    public string name;
    public int value;

    public string getName()
    {
        return name;
    }
}
[System.Serializable]
public struct OtherComponent: IComponent
{
    public string name;
    public int value;
    public float otherValue;

    public string getName()
    {
        return name;
    }
}

[System.Serializable]
public struct CompositeComponent : IComponent
{
   
    public IComponent component;
    public OtherComponent otherComponent;
    public string getName()
    {
        throw new System.NotImplementedException();
    }
}

public class StructData: SerializedMonoBehaviour
{
    public Component component1;
    public OtherComponent component2;
    public CompositeComponent composite;

    [OdinSerialize]
    public List<IComponent> list = new List<IComponent>();

    [OdinSerialize]
    public List<IComponent> internals = new List<IComponent>();

  //  [CustomValueDrawer("SomethingSomething")]
    public float testTest;
    public List<Entity> entities = new List<Entity>();

    public struct Entity
    {
        public int ID;
        public string name;
        public List<Component> components;

        public Entity(int id, string name, List<Component> list)
        {
            ID = id;
            this.name = name;
            components = list;
        }
    }

    public struct shamEntity : IComponent
    {
        public int ID;
        public string name;
        //public List<Component> components;

        
    }

    public Entity entity = new Entity(-1, "empty", new List<Component>());
    public shamEntity sham;
    

    void Start()
    {
        sham.name = "sham";
        sham.ID = -1;
        Debug.Log("Component list length: " + list.Count);
        Debug.Log("Entity list length: " + entities.Count);
        component1 = new Component();
        component1.name = "component1";
        component1.value = 5;
        internals.Add(component1);

        component2 = new OtherComponent();
        component2.name = "component2";
        component2.value = 1;
        component2.otherValue = 3f;
        internals.Add(component2);

        Component component3 = new Component();
        component3.name = "test";
        component3.value = 5;

        composite.component = (IComponent)component1;
        composite.otherComponent = component2;

        for(int i = 0; i< internals.Count; i++)
        {
            Debug.Log(internals[i].GetType());
        }
        IComponent castTest = (IComponent)composite;
        System.Type type = composite.GetType();

        var reverseCast = Convert.ChangeType(castTest, type);

        Debug.Log("Cast test: " + type + " " + reverseCast.GetType());

        Debug.Log(testComponent(component2).name);

        Meh meh = new Meh();
        meh.mehmeh = 7;

        Meh mmm = new Meh();
        mmm.mehmeh = 3;

        Debug.Log(mmm.mehmeh + " " + meh.mehmeh);
    }

    private void FixedUpdate()
    {
        //component1.value += 5;
        //component2.value++;
        //component2.otherValue += 3;
        
        {
            filter1(internals);
            Debug.Log("Component values: " + ((Component)internals[0]).value);


        }

       // Debug.Log("Component values: " + component1.value + " " + component2.value + " " + component2.otherValue);
    }

    void filter1 (List<IComponent> compList)
    {
        
    }

    Component testComponent(IComponent comp)
    {
        if (comp is Component)
        {
            Component c = (Component)comp;
            c.name = "test pass";
            return c;
        }
        else return new Component { name = null, value = 0 };
    }

    void duplicate<T, U>(U u)
    {
       //return null; // this is stupid, what did I even mean to do about this?
    }
}
/*
public class DrawIComponent<T> : OdinValueDrawer<T> where T : IComponent
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        Rect rect = EditorGUILayout.GetControlRect();

        if (label != null)
        {
            rect = EditorGUI.PrefixLabel(rect, label);
        }

        T value = this.ValueEntry.SmartValue;

        Type type = value.GetType();
        var val = Convert.ChangeType(value, type);
       // Debug.Log(type);

        FieldInfo[] fields = type.GetFields();

        PropertyInfo[] properties = type.GetProperties();

        //Array.ForEach(fields, (p) => Debug.Log(p));

        GUIHelper.PushLabelWidth(20);

        /* Array.ForEach(fields, (property) =>
         {
             Type pt = property.GetType();
             var pv = Convert.ChangeType(property, pt);

            // SerializedObject obj = new SerializedObject(value as UnityEngine.Object);
           // property.SetValue(property.GetValue(value), EditorGUI.PropertyField(rect.AlignLeft(rect.width * .5f), ;
         });
        // var value = Convert.ChangeType(interValue, interValue.GetType());

        val = EditorGUI.PropertyField(rect.AlignLeft(rect.width *.5f), val);
      //  value.X = EditorGUI.Slider(rect.AlignLeft(rect.width * 0.5f), "X", value.X, 0, 1);
      //  value.Y = EditorGUI.Slider(rect.AlignRight(rect.width * 0.5f), "Y", value.Y, 0, 1);
        GUIHelper.PopLabelWidth();

        this.ValueEntry.SmartValue = value;
    }
}
*/
    
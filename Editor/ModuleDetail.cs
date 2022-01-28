namespace Field.Editor
{
    using UnityEngine;
    using Sirenix.OdinInspector;
    using System.Collections;
    public class ModuleDetail<T> where T : ScriptableObject
    {
        [TabGroup("Main")]
        [VerticalGroup("Main/Details")]
        [ReadOnly]
        public string moduleName;
        [TabGroup("Main")]
        [VerticalGroup("Main/Details")]
        [ReadOnly]
        public string modulePath;
        [TabGroup("Main")]
        [VerticalGroup("Main/Details")]
        [ReadOnly]
        public string moduleDescription;
        [TabGroup("Detail")]
        [VerticalGroup("Detail/Left")]
        [ReadOnly]
        [ProgressBar(0, 100), ShowInInspector]
        public int created;
        [TabGroup("Detail")]
        [VerticalGroup("Detail/Right")]
        public string placeholderTwo;
         
        public ModuleDetail(string _moduleName, string _modulePath, string _moduleDescription)
        {
            moduleName = _moduleName;
            modulePath = _modulePath;
            moduleDescription = _moduleDescription;
        }

        [Button("Create")]
        public void CreateModule()
        {
            ScriptableObjectCreator.ShowDialog<T>(this.modulePath, obj =>
            {

            });
        }
    }
}
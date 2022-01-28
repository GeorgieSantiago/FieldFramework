#if UNITY_EDITOR
namespace Field.Editor
{
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using Sirenix.Utilities;
    using Sirenix.Utilities.Editor;
    using UnityEditor;
    using System.Linq;
    using Survival;
    using UnityEngine;
    using GameCreator.Melee;
    using Network;
    public class FieldEditor : OdinMenuEditorWindow
    {
        [ReadOnly]
        public string instructions = "Be sure any new module gets registered in both FieldEditor.cs and the main LevelController that brings everything online";
        private OdinMenuTree treeRef;

        public string resourcePath = "Assets/Resources";
        public float borderPadding;
        public float offset;
        public int height;
        [MenuItem("Tools/Field Editor")]
        private static void Open()
        {
            var window = GetWindow<FieldEditor>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var survivalModeResourcePath = this.resourcePath + "/SurvivalMode/";
            var routesResourcePath = this.resourcePath + "/Network/Routes/";
            var controllerResourcePath = this.resourcePath + "/Network/Controllers/";
            var tree = new OdinMenuTree(false)
            {
                { "Welcome", null, EditorIcons.UnityGameObjectIcon },
                { "Survival", new ModuleDetail<SurvivalMode>("Survival Modes", survivalModeResourcePath, "Control the details of each planet and house the related quests"), EditorIcons.Globe },
                { "Network/Routes", new ModuleDetail<Route>("Routes", routesResourcePath, "Network Routes") },
                { "Hurricane", Resources.LoadAll("Assets/HurricaneVR") },
                { "Settings", this, EditorIcons.SettingsCog },
            };
            tree.AddAllAssetsAtPath("Survival/", survivalModeResourcePath);
            tree.AddAllAssetsAtPath("Network/Routes", routesResourcePath);
            tree.AddAllAssetsAtPath("Hurricane/", "Assets/HurricaneVR", true, false);

            //tree.AddAllAssetsAtPath("Quests/",this.resourcePath + "/Quests/");
            var customMenuStyle = new OdinMenuStyle
            {
                BorderPadding = this.borderPadding,
                AlignTriangleLeft = true,
                TriangleSize = 16f,
                TrianglePadding = 0f,
                Offset = this.offset,
                Height = this.height,
                IconPadding = 0f,
                BorderAlpha = 0.323f,
                IconSize = 28.00f
            };

            var customMenuConfig = new OdinMenuTreeDrawingConfig()
            {
                DrawSearchToolbar = true,
            };

            //Add the icon option to Planet Faction and Squad
            //            tree.AddAllAssetsAtPath("", this.resourcePath, false, true);
            //            tree.EnumerateTree().AddIcons<Weapon>(x => x.Icon);
            tree.DefaultMenuStyle = customMenuStyle;
            tree.Config = customMenuConfig;
            //            tree.EnumerateTree().AddIcons<Faction>(x => x.Icon);
            return tree;
        }

        private void AddDragHandles(OdinMenuItem menuItem)
        {
            menuItem.OnDrawItem += x => DragAndDropUtilities.DragZone(menuItem.Rect, menuItem.Value, false, false);
        }

        protected override void OnBeginDrawEditors()
        {
            var selected = this.MenuTree.Selection.FirstOrDefault();
            var toolbarHeight = this.MenuTree.Config.SearchToolbarHeight;

            // Draws a toolbar with the name of the currently selected menu item.
            SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
            {
                if (SirenixEditorGUI.ToolbarButton(new GUIContent("Create A New Model")))
                {
                    ScriptableObjectCreator.ShowDialog<Model>("Assets/Resources/", obj =>
                    {
                        base.TrySelectMenuItemWithObject(obj); // Selects the newly created item in the editor
                    });
                }
            }
            SirenixEditorGUI.EndHorizontalToolbar();
        }
    }
}
#endif
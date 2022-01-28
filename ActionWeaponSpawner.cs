namespace Field.Weapon
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
    using GameCreator.Core;
	using GameCreator.Inventory;
	[AddComponentMenu("")]
	public class ActionWeaponSpawner : IAction
	{
		private Item[] spawnables;
		private void Start()
		{
			spawnables = InventoryManager.Instance.itemsCatalogue.Values.Where((Item pred) => pred.itemTypes == 0).ToArray();
		}
		
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            GameObject spawned = this.spawnables[0].prefab;
			spawned.AddComponent<Rigidbody>();
			Instantiate(spawned, this.transform);
            return true;
        }

		#if UNITY_EDITOR
        public static new string NAME = "Field/Spawn Weapon";
		#endif
	}
}

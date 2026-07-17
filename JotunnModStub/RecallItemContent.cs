using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace RecallMod
{
    internal class RecallItemContent
    {
        public static void Register(AssetBundle bundle)
        {
            CustomStatusEffect recallEffect = RegisterRecallEffect();
            RegisterRecallItem(bundle, recallEffect);
        }
        private static CustomStatusEffect RegisterRecallEffect()
        {
            SE_Recall effect = ScriptableObject.CreateInstance<SE_Recall>();
            effect.name = "SE_Recall";
            effect.m_name = "Recall";
            effect.m_recallChannelTime = 6f;

            CustomStatusEffect customEffect = new CustomStatusEffect(effect, fixReference: false);
            ItemManager.Instance.AddStatusEffect(customEffect);
            return customEffect;
        }

        private static void RegisterRecallItem(AssetBundle bundle, CustomStatusEffect recallEffect)
        {
            GameObject prefab = bundle.LoadAsset<GameObject>("recallItem");
            ItemDrop itemDrop = prefab.GetComponent<ItemDrop>();
            itemDrop.m_itemData.m_shared.m_itemType = ItemDrop.ItemData.ItemType.Consumable;
            itemDrop.m_itemData.m_shared.m_consumeStatusEffect = recallEffect.StatusEffect;

            ItemConfig recalConfig = new ItemConfig
            {
                Name = "Recall",
                Description = "Go home after a short channeling",
                CraftingStation = CraftingStations.Workbench,
                StackSize = 10,
                Requirements = new[]
                {
                    new RequirementConfig("GreydwarfEye", 5),
                    new RequirementConfig("SurtlingCore", 2),
                    new RequirementConfig("FineWood", 1)
                }
            };

            CustomItem recalItem = new CustomItem(prefab, fixReference: false, recalConfig);
            ItemManager.Instance.AddItem(recalItem);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIListManager<T> : MonoBehaviour
{
    [SerializeField]
    protected GameObject itemPrefab;

    [SerializeField]
    protected Transform parentTransform;

    protected readonly List<T> ItemList = new List<T>();

    protected virtual void Start()
    {
        UpdateItems(GetOrderedIDList());
        Debug.Log("UIListManager Start");
    }

    protected void UpdateItems(List<int> orderedIds)
    {
        for (int i = 0; i < orderedIds.Count; i++)
        {
            if (HasItem(orderedIds[i]) == false) continue;

            if (i < ItemList.Count)
            {
                UpdateItem(i, orderedIds[i]);
            }
            else
            {
                GameObject item = Instantiate(itemPrefab, parentTransform);
                ItemList.Add(item.GetComponent<T>());
                UpdateItem(ItemList.Count() - 1, orderedIds[i]);
            }
        }
    }

    protected abstract bool      HasItem(int id);    // このメソッドは、リストにアイテムが存在するかどうかを確認するために使用されます。
    
    /// <summary>
    ///   このメソッドは、アイテムのID順。
    /// </summary>
    /// <returns></returns>
    protected abstract List<int> GetOrderedIDList(); 

    protected abstract List<int> GetOrderedIDByHaveCountList(); // このメソッドは、アイテム所有数順。

    protected abstract List<int> GetOrderedIDByRerity();        // このメソッドは、アイテムのレアリティ順。
    protected abstract void      UpdateItem(int index, int id); // index番目のアイテムを渡されたIDを使用して、アイテムの情報を更新します。
}
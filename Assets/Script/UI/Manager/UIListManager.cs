using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class UIListManager<T> : MonoBehaviour
{
    [SerializeField]
    protected GameObject itemPrefab;

    [SerializeField]
    protected Transform parentTransform;

    private readonly List<T> _itemList = new List<T>();

    protected virtual void Start()
    {
        UpdateItems(GetOrderedIDList());
    }

    protected void UpdateItems(List<int> orderedIds)
    {
        for (int i = 0; i < orderedIds.Count; i++)
        {
            if (HasItem(orderedIds[i]) == false) continue;

            if (i < _itemList.Count)
            {
                UpdateItem(i);
            }
            else
            {
                GameObject item = Instantiate(itemPrefab, parentTransform);
                _itemList.Add(item.GetComponent<T>());
                UpdateItem(i);
            }
        }
    }

    protected abstract bool      HasItem(int id);    // このメソッドは、リストにアイテムが存在するかどうかを確認するために使用されます。
    protected abstract List<int> GetOrderedIDList(); // このメソッドは、アイテムのID順。

    protected abstract List<int> GetOrderedIDByHaveCountList(); // このメソッドは、アイテム所有数順。

    protected abstract List<int> GetOrderedIDByRerity(); // このメソッドは、アイテムのレアリティ順。
    protected abstract void      UpdateItem(int Id);     // このメソッドは、アイテムを更新するために使用されます。
}
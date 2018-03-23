/*
该脚本绑在拖拽结束后，要落入的物体
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class Drop : MonoBehaviour, IDropHandler
{

    public DetermineResult playerDetermine = DetermineResult.None;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (PlayerCtr.instance.playerDetermine!=DetermineResult.None&& PlayerCtr.instance.playerDetermine != playerDetermine)
            {
                return;
            }
            //Debug.Log(eventData.position);
            Image img = eventData.pointerDrag.GetComponent<Image>();
            if (img != null)
            {
                var num = int.Parse(eventData.pointerDrag.name);
                PlayerCtr.instance.playerDetermine = playerDetermine;
                PlayerCtr.instance.Money -= num;
                PlayerCtr.instance.StakeNum += num;
               // Debug.Log(eventData.pointerDrag.name);
               var go= Resources.Load<GameObject>("chip");
                var obj= Instantiate<GameObject>(go, eventData.position, Quaternion.identity, transform);
                obj.GetComponent<Image>().sprite = img.sprite;
                PlayerCtr.instance.chips.Add(obj);
                //GetComponent<Image>().color = new Color(1, 1, 1, 1);//我刚开始把图片设为了透明
            }
        }
    }
}

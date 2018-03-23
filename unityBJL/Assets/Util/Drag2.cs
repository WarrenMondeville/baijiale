/*
该脚本绑在要拖拽的物体上
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//要想用拖拽事件必须导入EventSystems
using UnityEngine.UI;
public class Drag2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{//实现开始拖拽，拖拽中和结束拖拽3个事件接口
    public Canvas canv;//场景中的canvas
    private GameObject dragObj;//拖拽生成的物品
    private RectTransform dragObjRect;//生成物品的方向等信息
    void Start()
    {
        dragObjRect = canv.transform as RectTransform;

    }
    public void OnBeginDrag(PointerEventData eventData)//开始拖拽
    {
        dragObj = new GameObject("icon");
        dragObj.transform.SetParent(canv.transform, false);//让这个物体在canvas上，此时物品在屏幕中心
        dragObj.transform.SetAsLastSibling();//将生成的物体设为canvas的最后一个子物体，一般来说最后一个子物体是可操作的
        Image img = dragObj.AddComponent<Image>();//给生成的拖拽物体添加一个Image组件并获得Image组件的控制权
        img.raycastTarget = false;//让该物体不接受鼠标的照射，目的是底下的物品也能操作
        img.sprite = GetComponent<Image>().sprite;//让生成物体的图片为按钮的图片
        dragObj.GetComponent<RectTransform>().sizeDelta =
            new Vector2(Screen.height * 0.1f, Screen.height * 0.1f);//设置新生成物品的尺寸
        ObjFollowMouse(eventData);//让生成的物体跟随鼠标
    }
    public void OnDrag(PointerEventData eventData)//拖拽中
    {
        ObjFollowMouse(eventData);//让生成的物体跟随鼠标
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObj != null)
        {
            Destroy(dragObj);//拖拽结束后销毁生成的物体
        }
    }//拖拽结束
    private void ObjFollowMouse(PointerEventData eventData)
    {
        if (dragObj != null)//检测生成的物体是否为空，保险起见
        {
            RectTransform rc = dragObj.GetComponent<RectTransform>();//得到生成物品的控制权
            Vector3 globalMousePos;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle
                (dragObjRect, eventData.position, eventData.pressEventCamera, out globalMousePos))
            {
                rc.position = globalMousePos;
                rc.rotation = dragObjRect.rotation;
            }
        }
    }
}
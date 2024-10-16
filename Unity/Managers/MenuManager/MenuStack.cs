using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuStack{

    private MenuItem currentMenu;
    private List<MenuItem> stack;
    private int _size;



    public MenuStack (){
        currentMenu = null;
        stack = new List<MenuItem>();
        _size = stack.Count;
    }

    public int getStackCount(){
        return _size;
    }

    public MenuItem getCurrentMenu(){
        return currentMenu;
    }

    public void Pop(){
        if(stack.Count == 0 ){
            Debug.Log("Sorry, Nothing else left to pop off!");
        }else if (stack.Count == 1){
            _size--;
            stack.RemoveAt(_size);
            currentMenu = null;
        }else if(stack.Count > 1){
            _size--;
            stack.RemoveAt(_size);
            currentMenu = stack[_size-1];
            
        }
    }

    public void Push(MenuItem item){
        stack.Add(item);
        currentMenu = item;
        _size++;
        Debug.Log("Pushed");
        Debug.Log(_size);
    }
}

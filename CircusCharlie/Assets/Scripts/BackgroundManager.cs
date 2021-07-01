using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject [] _Background;
    private Camera _mainCamera;
    private Vector2 _screenBounds;
    public Sprite[] sprites;

    private void Start()
    {
        _mainCamera = gameObject.GetComponent<Camera>();
        _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));

        foreach (GameObject obj in _Background)
        {
            loadChildObject(obj);
        }
            
        
    }
 
    void loadChildObject(GameObject obj)
    {
        float _objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int) Mathf.Ceil(_screenBounds.x * 2 / _objectHeight);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(_objectHeight * i,obj.transform.position.y, obj.transform.position.z);
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if(children.Length > 1)
        {
            GameObject _firstChild = children[1].gameObject;
            GameObject _lastChild = children[children.Length - 1].gameObject;
            float _halfObjectHeight = _lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if(transform.position.x + _screenBounds.x > _lastChild.transform.position.x + _halfObjectHeight)
            {
                int z = Random.Range(0, sprites.Length);
                _firstChild.GetComponent<SpriteRenderer>().sprite = sprites[z];
                _firstChild.transform.SetAsLastSibling();
                _firstChild.transform.position = new Vector3(_lastChild.transform.position.x + _halfObjectHeight * 2, _lastChild.transform.position.y, _lastChild.transform.position.z);

            } else if(transform.position.x - _screenBounds.x < _firstChild.transform.position.x - _halfObjectHeight)
            {
                _lastChild.transform.SetAsFirstSibling();
                _lastChild.transform.position = new Vector3(_firstChild.transform.position.x - _halfObjectHeight * 2, _firstChild.transform.position.y, _firstChild.transform.position.z);

            }

        }

    }

    private void LateUpdate()
    {
        foreach (GameObject obj in _Background)
        {
            repositionChildObjects(obj);
        }    
    }

    


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChenger : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int myY = (int)transform.position.y;
        

        foreach (Transform child in transform)
        {

            switch (myY)
            {

                case 1:

                    if (child.tag == "FireHeal")
                    {
                        child.transform.FindChild("火の輪_左").GetComponent<SpriteRenderer>().sortingOrder = 1;
                        child.transform.FindChild("火の輪_右").GetComponent<SpriteRenderer>().sortingOrder = 4;
                    }
                    else if (child.tag == "HPHeal")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 0;
                        child.transform.FindChild("Kirakira_0").GetComponent<SpriteRenderer>().sortingOrder = 0;
                    }
                    else if (child.tag == "Asiba")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = -1;
                    }
                    else if(child.GetComponent<SpriteRenderer>() != null)
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    }
                    break;

                case -1:

                    if (child.tag == "FireHeal")
                    {
                        child.transform.FindChild("火の輪_左").GetComponent<SpriteRenderer>().sortingOrder = 7;
                        child.transform.FindChild("火の輪_右").GetComponent<SpriteRenderer>().sortingOrder = 10;
                    }
                    else if (child.tag == "HPHeal")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 6;
                        child.transform.FindChild("Kirakira_0").GetComponent<SpriteRenderer>().sortingOrder = 6;
                    }
                    else if (child.tag == "Asiba")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 5;
                    }
                    else if (child.GetComponent<SpriteRenderer>() != null) child.GetComponent<SpriteRenderer>().sortingOrder = 6;

                    break;

                case -3:

                    if (child.tag == "FireHeal")
                    {
                        child.transform.FindChild("火の輪_左").GetComponent<SpriteRenderer>().sortingOrder = 13;
                        child.transform.FindChild("火の輪_右").GetComponent<SpriteRenderer>().sortingOrder = 16;
                    }
                    else if (child.tag == "HPHeal")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 12;
                        child.transform.FindChild("Kirakira_0").GetComponent<SpriteRenderer>().sortingOrder = 12;
                    }
                    else if (child.tag == "Asiba")
                    {
                        child.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    }
                    else if (child.GetComponent<SpriteRenderer>() != null) child.GetComponent<SpriteRenderer>().sortingOrder = 12;
                    break;
            }
            
                   
        }

    }
	
}

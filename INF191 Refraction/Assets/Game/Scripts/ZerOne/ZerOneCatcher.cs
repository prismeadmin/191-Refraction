﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Catching_Status { GREAT, GOOD, MISSED };

public class ZerOneCatcher : MonoBehaviour
{

    public Text Catching_text;

    public ParticleSystem ps;


    Bounds catcher_bounds;
    double catcher_area;

    GameObject zerOne_object;
    double cover_percent;
    Catching_Status catching_status;

    // Start is called before the first frame update
    void Start()
    {
        catcher_bounds = GetComponent<Collider2D>().bounds;
        catcher_area = (catcher_bounds.max.x - catcher_bounds.min.x) * (catcher_bounds.max.y - catcher_bounds.min.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called when user taps left/right shift
    public void Catch(int key)
    {
        if (zerOne_object)
        {
            if(cover_percent <= 0.7)
            {
                if ((key == 0 && zerOne_object.GetComponent<ZerOne>().zerOneType == ZerOneType.ZERO)
                    || (key == 1 && zerOne_object.GetComponent<ZerOne>().zerOneType == ZerOneType.ONE))
                {
                    catching_status = Catching_Status.GOOD;
                    ps.Play();
                }
                else
                    catching_status = Catching_Status.MISSED;
            }
            else
            {
                if ((key == 0 && zerOne_object.GetComponent<ZerOne>().zerOneType == ZerOneType.ZERO)
                    || (key == 1 && zerOne_object.GetComponent<ZerOne>().zerOneType == ZerOneType.ONE))
                {
                    catching_status = Catching_Status.GREAT;
                    ps.Play();
                }
                else
                    catching_status = Catching_Status.MISSED;
                
            }

            //separate data and UI updating
            ChangeCatchingText();

            //Reset
            ResetCatchingStatus();
        }
 
    }

    public void ChangeCatchingText()
    {
        switch (catching_status)
        {
            case Catching_Status.MISSED:
                Catching_text.text = "MISSED";
                return;
            case Catching_Status.GOOD:
                Catching_text.text = "GOOD";
                return;
            case Catching_Status.GREAT:
                Catching_text.text = "GREAT!";
                return;
            default:
                Catching_text.text = "NULL";
                return;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ZerOne"))
        {
            zerOne_object = other.gameObject;
            double min_x = (other.bounds.min.x > catcher_bounds.min.x) ? other.bounds.min.x : catcher_bounds.min.x;
            double max_x = (other.bounds.max.x < catcher_bounds.max.x) ? other.bounds.max.x : catcher_bounds.max.x;
            double dx = max_x - min_x;
            double min_y = (other.bounds.min.y > catcher_bounds.min.y) ? other.bounds.min.y : catcher_bounds.min.y;
            double max_y = (other.bounds.max.y < catcher_bounds.max.y) ? other.bounds.max.y : catcher_bounds.max.y;
            double dy = max_y - min_y;

            //Debug.Log("minx:" + min_x.ToString());
            //Debug.Log("max:" + max_x.ToString());
            //Debug.Log("dx:" + dx.ToString());
            //Debug.Log("dy:" + dy.ToString());

            cover_percent = (dx>0&&dy>0)? dx * dy / catcher_area : 0f;

            //if(Vector2.Distance(other.gameObject.transform.position,transform.position) < Vector2.kEpsilon) { 
            if (cover_percent > 0.99)
            {
                catching_status = Catching_Status.MISSED;
                ChangeCatchingText();
                ResetCatchingStatus();
            }
        }
    }

    private void ResetCatchingStatus()
    {
        if(zerOne_object)
            Destroy(zerOne_object);
        zerOne_object = null;
        cover_percent = 0;
    }



}

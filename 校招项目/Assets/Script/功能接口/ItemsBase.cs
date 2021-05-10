using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.功能接口
{
    public class ItemsBase: MonoBehaviour
    {
        public int item_fraction;

        public string item_name;

        public virtual void  OnTriggerEnter2D(Collider2D collision)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.功能接口
{
    public class Enemy: MonoBehaviour
    {
        public int enemy_score;

        public Animator anim;

        public float Speed;

        public void animDetah()
        {
            GetComponent<CircleCollider2D>().enabled = false;

            anim.SetTrigger("enemy_death");
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}

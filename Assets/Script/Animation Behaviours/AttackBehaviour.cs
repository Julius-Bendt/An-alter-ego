/**
 * Author: Julius Bendt
 * Author URI: www.juto.dk
 * Company: JutoGames
 * Company URI: www.juto.dk
 * Copyright 2015
 **/


using UnityEngine;
using System.Collections;

public class AttackBehaviour : StateMachineBehaviour {
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Character>().attack = true;
        animator.SetFloat("speed", 0);
    }

    override public void OnStateExit(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Character>().attack = false;
        animator.GetComponent<Character>().MeleeAttack();
        animator.ResetTrigger("attack");
        //animator.ResetTrigger("throw");
    }
}

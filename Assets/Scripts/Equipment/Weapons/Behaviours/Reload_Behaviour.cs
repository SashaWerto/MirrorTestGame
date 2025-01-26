using UnityEngine;

public class Reload_Behaviour : StateMachineBehaviour
{
    private Gun refGun;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        refGun = animator.GetComponent<Gun>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       refGun.Reload();
    }
}

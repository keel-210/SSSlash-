using UnityEngine;

namespace AnimatorParameter
{
	[System.Serializable]
	public class ThirdPersonAnimatorController
	{
		public Animator animator;

		protected readonly static int ForwardHash = 673977882; public float Forward{ get{ return animator.GetFloat(ForwardHash); } set{ animator.SetFloat(ForwardHash, value); }}
		protected readonly static int TurnHash = -2146256263; public float Turn{ get{ return animator.GetFloat(TurnHash); } set{ animator.SetFloat(TurnHash, value); }}
		protected readonly static int CrouchHash = -2015693266; public bool Crouch{ get{ return animator.GetBool(CrouchHash); } set{ animator.SetBool(CrouchHash, value); }}
		protected readonly static int OnGroundHash = 1602690925; public bool OnGround{ get{ return animator.GetBool(OnGroundHash); } set{ animator.SetBool(OnGroundHash, value); }}
		protected readonly static int JumpHash = 125937960; public float Jump{ get{ return animator.GetFloat(JumpHash); } set{ animator.SetFloat(JumpHash, value); }}
		protected readonly static int JumpLegHash = -1632016922; public float JumpLeg{ get{ return animator.GetFloat(JumpLegHash); } set{ animator.SetFloat(JumpLegHash, value); }}
		public static readonly int Base_Layer_Grounded = -648720422;
		public static readonly int Base_Layer_Crouching = 2069122584;
		public static readonly int Base_Layer_Airborne = 596608324;

	}
}
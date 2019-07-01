using UnityEngine;

namespace AnimatorParameter
{
	[System.Serializable]
	public class Rindou
	{
		public Animator animator;

		protected readonly static int OnGroundHash = 1602690925; public bool OnGround{ get{ return animator.GetBool(OnGroundHash); } set{ animator.SetBool(OnGroundHash, value); }}
		protected readonly static int JoyStickXZeroHash = -1654548903; public bool JoyStickXZero{ get{ return animator.GetBool(JoyStickXZeroHash); } set{ animator.SetBool(JoyStickXZeroHash, value); }}
		protected readonly static int JoyStickYZeroHash = -1610498071; public bool JoyStickYZero{ get{ return animator.GetBool(JoyStickYZeroHash); } set{ animator.SetBool(JoyStickYZeroHash, value); }}
		protected readonly static int SlashHash = -972068619; public bool Slash{ get{ return animator.GetBool(SlashHash); } set{ animator.SetBool(SlashHash, value); }}
		protected readonly static int JoyStickXHash = -1262477100; public float JoyStickX{ get{ return animator.GetFloat(JoyStickXHash); } set{ animator.SetFloat(JoyStickXHash, value); }}
		protected readonly static int JoyStickYHash = -1010364350; public float JoyStickY{ get{ return animator.GetFloat(JoyStickYHash); } set{ animator.SetFloat(JoyStickYHash, value); }}
		protected readonly static int VeloXHash = -1148102995; public float VeloX{ get{ return animator.GetFloat(VeloXHash); } set{ animator.SetFloat(VeloXHash, value); }}
		protected readonly static int VeloYHash = -862558661; public float VeloY{ get{ return animator.GetFloat(VeloYHash); } set{ animator.SetFloat(VeloYHash, value); }}
		public static readonly int Base_Layer_Rindou_idle = 2020792332;
		public static readonly int Base_Layer_Rindou_walk = 700913484;
		public static readonly int Base_Layer_Rindou_slash = 1661057372;
		public static readonly int Base_Layer_Rindou_preslash = 2064940219;
		public static readonly int Base_Layer_Rindou_InAir = 1469813937;
		public static readonly int Base_Layer_Rindou_jump = 65366799;
		public static readonly int WalkEffect_None = 2021540479;
		public static readonly int WalkEffect_RightWalk = -1877212026;
		public static readonly int WalkEffect_LeftWalk = -721029867;
		public static readonly int SwordEffect_Idle = 2115542404;
		public static readonly int SwordEffect_Slash = -2140874741;
		public static readonly int SwordEffect_PreSlash = -1843878824;

	}
}
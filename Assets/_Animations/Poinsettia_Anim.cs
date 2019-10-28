using UnityEngine;

namespace AnimatorParameter
{
	[System.Serializable]
	public class Poinsettia_Anim
	{
		public Animator animator;

		protected readonly static int HealthHash = -915003867; public int Health{ get{ return animator.GetInteger(HealthHash); } set{ animator.SetInteger(HealthHash, value); }}
		protected readonly static int IsDamagableHash = 2051096288; public bool IsDamagable{ get{ return animator.GetBool(IsDamagableHash); } set{ animator.SetBool(IsDamagableHash, value); }}
		protected readonly static int DamagedHash = 326473335; public bool Damaged{ get{ return animator.GetBool(DamagedHash); } set{ animator.SetBool(DamagedHash, value); }}
		protected readonly static int StateHash = 1649606143; public int State{ get{ return animator.GetInteger(StateHash); } set{ animator.SetInteger(StateHash, value); }}
		protected readonly static int IsChargingHash = -559571433; public bool IsCharging{ get{ return animator.GetBool(IsChargingHash); } set{ animator.SetBool(IsChargingHash, value); }}
		public static readonly int Base_Layer_Idle = 1432961145;
		public static readonly int Base_Layer_Charge = 1374949185;
		public static readonly int Base_Layer_Shot = 575307223;
		public static readonly int Base_Layer_Fall = 1914514016;
		public static readonly int Base_Layer_Summon = -923445604;
		public static readonly int Base_Layer_Stan = 1419244343;
		public static readonly int Base_Layer_Defeat = 204861808;

	}
}
using UnityEngine;

namespace AnimatorParameter
{
	[System.Serializable]
	public class Poinsettia_Anim
	{
		public Animator animator;

		protected readonly static int HealthHash = -915003867; public int Health{ get{ return animator.GetInteger(HealthHash); } set{ animator.SetInteger(HealthHash, value); }}
		protected readonly static int PosXHash = -933187760; public float PosX{ get{ return animator.GetFloat(PosXHash); } set{ animator.SetFloat(PosXHash, value); }}
		protected readonly static int PosYHash = -1083727930; public float PosY{ get{ return animator.GetFloat(PosYHash); } set{ animator.SetFloat(PosYHash, value); }}
		protected readonly static int PlayerXHash = 1162838906; public float PlayerX{ get{ return animator.GetFloat(PlayerXHash); } set{ animator.SetFloat(PlayerXHash, value); }}
		protected readonly static int PlayerYHash = 843625452; public float PlayerY{ get{ return animator.GetFloat(PlayerYHash); } set{ animator.SetFloat(PlayerYHash, value); }}
		protected readonly static int DiffXHash = 926028648; public float DiffX{ get{ return animator.GetFloat(DiffXHash); } set{ animator.SetFloat(DiffXHash, value); }}
		protected readonly static int DiffYHash = 1077224446; public float DiffY{ get{ return animator.GetFloat(DiffYHash); } set{ animator.SetFloat(DiffYHash, value); }}
		protected readonly static int IsDamasableHash = -283045982; public bool IsDamasable{ get{ return animator.GetBool(IsDamasableHash); } set{ animator.SetBool(IsDamasableHash, value); }}
		protected readonly static int StateHash = 1649606143; public int State{ get{ return animator.GetInteger(StateHash); } set{ animator.SetInteger(StateHash, value); }}
		public static readonly int Base_Layer_Idle = 1432961145;
		public static readonly int Base_Layer_Charge = 1374949185;
		public static readonly int Base_Layer_Shot = 575307223;
		public static readonly int Base_Layer_Fall = 1914514016;
		public static readonly int Base_Layer_Summon = -923445604;
		public static readonly int Base_Layer_Stan = 1419244343;
		public static readonly int Base_Layer_Defeat = 204861808;

	}
}
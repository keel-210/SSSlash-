using UnityEngine;

namespace AnimatorParameter
{
	[System.Serializable]
	public class JetPlane
	{
		public Animator animator;

		protected readonly static int GearStateHash = 195704262; public int GearState{ get{ return animator.GetInteger(GearStateHash); } set{ animator.SetInteger(GearStateHash, value); }}
		public static readonly int Base_Layer_Raising = -2023849816;
		public static readonly int Base_Layer_Lowering = 1706642163;
		public static readonly int Base_Layer_Raised = 355052738;
		public static readonly int Base_Layer_Lowered = 1251599115;

	}
}
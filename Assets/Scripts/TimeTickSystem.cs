using System;
using UnityEngine;

namespace Overheat.Game.TickSystem
{
	internal class TimeTickSystem : MonoBehaviour
	{
		internal class OnTickEventArgs : EventArgs
		{
			internal int tick;
		}

		internal static event EventHandler<OnTickEventArgs> OnTick;
		private const float TICK_TIMER_MAX = 1.5f;
		private int tick;
		private float tickTimer;

		private void Awake()
		{
			tick = 0;
		}

		private void Update()
		{
			tickTimer += Time.deltaTime;
			if( tickTimer >= TICK_TIMER_MAX )
			{
				tickTimer -= TICK_TIMER_MAX;
				tick++;
				if( OnTick != null ) OnTick( this, new OnTickEventArgs { tick = tick } );
			}
		}
	}
}


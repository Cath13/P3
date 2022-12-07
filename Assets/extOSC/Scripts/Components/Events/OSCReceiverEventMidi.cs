﻿/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

using extOSC.Core.Events;

namespace extOSC.Components.Events
{
	[AddComponentMenu("extOSC/Components/Receiver/Midi Event")]
	public class OSCReceiverEventMidi : OSCReceiverEvent<OSCEventMidi>
	{
		#region Protected Methods

		protected override void Invoke(OSCMessage message)
		{
			if (onReceive != null && message.ToMidi(out var value))
			{
				onReceive.Invoke(value);
			}
		}

		#endregion
	}
}
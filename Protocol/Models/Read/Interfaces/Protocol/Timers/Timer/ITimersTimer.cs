using System.Collections.Generic;
using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface ITimersTimer
	{
		/// <summary>
		/// Gets the options.
		/// </summary>
		TimerOptions GetOptions();

		/// <summary>
		/// Tries to get the groups in this timer.
		/// </summary>
		/// <param name="relationManager">The relation manager.</param>
		/// <returns>The groups that are in the content of this group.</returns>
		IEnumerable<IGroupsGroup> GetTimerContentGroups(RelationManager relationManager);
	}
}

namespace Skyline.DataMiner.CICD.Models.Protocol.Edit
{
    public partial class ParamsParamAlarm
    {
        static readonly string[] elementOrder = new string[] { "Monitored", "Info", "CL", "MaL", "MiL", "WaL", "Normal", "WaH", "MiH", "MaH", "CH" };

        public override string[] ElementOrder => elementOrder;

    }
}

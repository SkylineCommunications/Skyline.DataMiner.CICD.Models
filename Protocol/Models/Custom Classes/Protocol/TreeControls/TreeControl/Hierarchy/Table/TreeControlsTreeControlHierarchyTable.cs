namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class TreeControlsTreeControlHierarchyTable
    {
        public TableCondition GetCondition()
        {
            string conditionValue = Condition?.RawValue;
            if (conditionValue == null)
            {
                return null;
            }

            return new TableCondition(conditionValue);
        }
    }
}
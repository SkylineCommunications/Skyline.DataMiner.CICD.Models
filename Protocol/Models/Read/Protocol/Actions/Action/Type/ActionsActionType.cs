namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class ActionsActionType : IActionsActionType
    {
        public ActionTypeOptions GetOptions()
        {
            string optionValue = Options?.RawValue;
            if (optionValue == null)
            {
                return null;
            }

            return new ActionTypeOptions(optionValue);
        }

        public ActionTypeOptionsGrouped GetOptionsByType()
        {
            string optionValue = Options?.RawValue;
            if (optionValue == null)
            {
                return null;
            }

            return new ActionTypeOptionsGrouped(GetOptions());
        }
    }
}
namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    public partial interface IActionsActionType
    {
        ActionTypeOptions GetOptions();

        ActionTypeOptionsGrouped GetOptionsByType();
    }
}
using Application.Consumers.Configuration;
using Application.Extentions;
using MassTransit;
using System.Transactions;

namespace Application.Consumers;

public class OrganizationEntherpriseConsumerDefinition : ConsumerDefinition<OrganizationEntherpriseConsumer>
{
    public OrganizationEntherpriseConsumerDefinition()
    {
        ConcurrentMessageLimit = 2;
        Endpoint(x => x.Name = QueueNames.OrganizationEntherpriseQueue.EnviromentName());
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<OrganizationEntherpriseConsumer> consumerConfigurator)
    {
        //endpointConfigurator.UseMessageRetry(r => r.Immediate(2));
        endpointConfigurator.UseTransaction(x =>
        {
            x.Timeout = TimeSpan.FromSeconds(90);
            x.IsolationLevel = IsolationLevel.ReadCommitted;
        });
    }
}
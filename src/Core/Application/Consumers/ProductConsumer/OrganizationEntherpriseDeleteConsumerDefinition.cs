using Application.Consumers.Configuration;
using Application.Extentions;
using MassTransit;
using System.Transactions;

namespace Application.Consumers;

public class OrganizationEntherpriseDeleteConsumerDefinition : ConsumerDefinition<OrganizationEntherpriseDeleteConsumer>
{
    public OrganizationEntherpriseDeleteConsumerDefinition()
    {
        ConcurrentMessageLimit = 2;
        Endpoint(x => x.Name = QueueNames.OrganizationEntherpriseDeleteQueue.EnviromentName());
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<OrganizationEntherpriseDeleteConsumer> consumerConfigurator)
    {
        //endpointConfigurator.UseMessageRetry(r => r.Immediate(2));
        endpointConfigurator.UseTransaction(x =>
        {
            x.Timeout = TimeSpan.FromSeconds(90);
            x.IsolationLevel = IsolationLevel.ReadCommitted;
        });
    }
}
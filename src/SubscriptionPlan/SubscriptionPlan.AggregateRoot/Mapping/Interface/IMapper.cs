using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.DTO.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionPlan.AggregateRoot.Mapping.Interface
{
    public interface IMapper
    {
        SubscriptionPlanAggregateRoot RegisterRequestToEntity(RegisterSubscriptionCommand request);
        SubscriptionPlanAggregateRoot UpdateRequestToEntity(UpdateSubscriptionCommand request);

        SubscriptionPlanAggregateRoot RemoveRequestToEntity(RemoveSubscriptionCommand request);
        SubscriptionPlanAggregateRoot GetRequestToEntity(ViewSubscriptionQuery request);
    }
}

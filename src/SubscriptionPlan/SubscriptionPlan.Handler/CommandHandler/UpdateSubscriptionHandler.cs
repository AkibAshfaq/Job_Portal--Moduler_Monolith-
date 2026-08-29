using JobPortal.Shared.Exceptions;
using JobPortal.Shared.Interfaces.CommandHandler;
using SubscriptionPlan.AggregateRoot;
using SubscriptionPlan.AggregateRoot.Mapping.Interface;
using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.Repository.Repositories.Interfaces;

namespace SubscriptionPlan.Handler.CommandHandler
{
    public class UpdateSubscriptionHandler : ICommandHandler<UpdateSubscriptionCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionPlanRepository _subRepo;
        private readonly SubscriptionPlanAggregateRoot _SubRoot;

        public UpdateSubscriptionHandler(
            IMapper mapper,
            ISubscriptionPlanRepository subRepo,
            SubscriptionPlanAggregateRoot subRoot)
        {
            _mapper = mapper;
            _subRepo = subRepo;
            _SubRoot = subRoot;
        }
        public async Task HandleAsync(UpdateSubscriptionCommand command)
        {
            var subscriptionPlan = await _subRepo.GetSubscriptionPlanBySlug(command.Slug)
                ?? throw new Exception($"Subscription plan with slug '{command.Slug}' not found.");
            var entity = _mapper.UpdateRequestToEntity(command)
                ?? throw new Exception($"Failed to create entity for command '{command.GetType().Name}'.");

            _subRepo.Update(entity);
            var saveResult = await _subRepo.SaveChangeAsync();
            if (saveResult == 0)
            {
                throw new NotSavedException("Failed to save changes");
            }
        }
    }
}

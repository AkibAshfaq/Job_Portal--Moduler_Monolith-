using JobPortal.Shared.Exceptions;
using JobPortal.Shared.Interfaces.CommandHandler;
using SubscriptionPlan.AggregateRoot;
using SubscriptionPlan.AggregateRoot.Mapping.Interface;
using SubscriptionPlan.DTO.Command;
using SubscriptionPlan.Repository.Repositories.Interfaces;

namespace SubscriptionPlan.Handler.CommandHandler
{
    public class RegisterSubscriptionHandler : ICommandHandler<RegisterSubscriptionCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionPlanRepository _subRepo;
        private readonly SubscriptionPlanAggregateRoot _SubRoot;
        public RegisterSubscriptionHandler(
            IMapper mapper, 
            ISubscriptionPlanRepository subscriptionPlanRepository, 
            SubscriptionPlanAggregateRoot subscriptionPlanAggregateRoot)
        {
            _mapper = mapper;
            _subRepo = subscriptionPlanRepository;
            _SubRoot = subscriptionPlanAggregateRoot;
        }
        public Task HandleAsync(RegisterSubscriptionCommand command)
        {
            var plan = _subRepo.GetSubscriptionPlanBySlug(command.Slug) 
                ?? throw new NotFoundException("Subscription plan Already exists");

            var newplan = _mapper.RegisterRequestToEntity(command) 
                ?? throw new NotFoundException("Subscription Data Invalid");

            _subRepo.AddAsync(newplan);
            _subRepo.SaveChangeAsync();

            return Task.CompletedTask;
        }
    }
}

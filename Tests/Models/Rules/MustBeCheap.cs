using Validators.Types;

namespace Validators.Test.Models.Rules
{
    public class MustBeCheap : ICheckRule
    {
        private readonly Car car;

        public MustBeCheap(Car car)
        {
            this.car = car;
        }
        public CheckRuleState State { get; set; }

        public Task Run()
        {
            return Task.Run(() =>
            {
                if (car.Age > 5 && car.Price > 100)
                {
                    State = CheckRuleState.InValid;
                }
                else
                {
                    State = CheckRuleState.Valid;
                }
            });
        }
    }
}
